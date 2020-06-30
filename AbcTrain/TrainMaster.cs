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
        /// <param name="serviceRequest">list of train car ids</param>
        public void ServiceCars(List<int> serviceRequest)
        {
            if (GreedyAlgorithm(serviceRequest, true))
            {
                GreedyAlgorithm(serviceRequest, false);
            }
        }

        /// <summary>
        /// Simple algorithm to process the list and provide a simulation to prevent physical world errors.
        /// </summary>
        /// <param name="serviceRequest">The list of car ids which should be services</param>
        /// <param name="simulate">This parameter could be implemented other ways the objective is to minimize impact on <see cref="PhysicalOperator"/></param>
        /// <returns></returns>
        private bool GreedyAlgorithm(List<int> serviceRequest, bool simulate)
        {
            Queue<int> train = new Queue<int>(_operator.TrainCars);
            Stack<int> tempRail = new Stack<int>();
            int counter = 0;
            while(train.Count > 0 || tempRail.Count > 0)
            {
                if(train.Count > 0 && train.Peek() == serviceRequest[counter])
                {
                    train.Dequeue();
                    if (!simulate)
                    {
                        _operator.AtoB();
                    }
                    
                    counter++;
                }
                else if(tempRail.Count > 0 && tempRail.Peek() == serviceRequest[counter])
                {
                    if (!simulate)
                    {
                        _operator.CtoB();
                    }

                    tempRail.Pop();
                    counter++;
                }
                else if(train.Count > 0)
                {
                    tempRail.Push(train.Dequeue());
                    if (!simulate)
                    {
                        _operator.AtoC();
                    }
                }
                else
                {
                    // this is a case where we can't service the request due to faulty input.
                    Console.WriteLine($"Cannot service request {serviceRequest}, unserviced cars {string.Join("", tempRail.ToArray())} are on temporary track.");
                    return false;
                }
            }

            return true;
        }
    }
}
