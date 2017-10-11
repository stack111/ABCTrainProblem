using System;
using System.Collections.Generic;

namespace AbcTrain
{
    /// <summary>
    /// Class which when given an input for car nums to be serviced will operate on physical functions to 
    /// service the cars
    /// </summary>
    public class TrainMaster
    {
        PhysicalOperator _operator;
        public TrainMaster(PhysicalOperator op)
        {
            _operator = op;
        }

        /// <summary>
        /// Assumption: Cars cannot have spaces between them.
        /// </summary>
        /// <param name="desiredCars">string of car numbers eg: "123" or "321"</param>
        public void ServiceCars(string desiredCars)
        {
            char[] desiredArr = desiredCars.ToCharArray();
            Queue<char> train = new Queue<char>(_operator.TrainCars);
            Stack<char> tempRail = new Stack<char>();
            int serviceCounter = 0;
            while(train.Count > 0 || tempRail.Count > 0)
            {
                if(train.Count > 0 && train.Peek() == desiredArr[serviceCounter])
                {
                     train.Dequeue();
                    _operator.AtoC();
                    serviceCounter++;
                }
                else if(tempRail.Count > 0 && tempRail.Peek() == desiredArr[serviceCounter])
                {
                    _operator.BtoC();
                    tempRail.Pop();
                    serviceCounter++;
                }
                else if(train.Count > 0)
                {
                    char car = train.Dequeue();
                    _operator.AtoB();
                    tempRail.Push(car);
                }
                else
                {
                    // this is a case where we can't service the request due to faulty input.
                    Console.WriteLine($"M: Cannot service request {desiredCars}, unserviced cars {string.Join("", tempRail.ToArray())} are on temporary track.");
                    break;
                }
            }
        }
    }
}
