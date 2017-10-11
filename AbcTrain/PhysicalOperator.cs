using System;
using System.Collections.Generic;

namespace AbcTrain
{
    public class PhysicalOperator
    {
        /// <summary>
        /// Starting point entering into the station with all cars.
        /// </summary>
        Queue<char> A;

        /// <summary>
        /// A servicing rail has been provided to temporarily move the cars
        /// </summary>
        Stack<char> B;
        
        /// <summary>
        /// Physical operator wants all train cars on C in order of provided desired input.
        /// </summary>
        Queue<char> C;
        
        public string TrainCars { get; private set; }

        /// <summary>
        /// Constructs an operator, assumption is that traincars are always ascending.
        /// </summary>
        /// <param name="trainCars">ascending numerical values when they are at the entrance.</param>
        public PhysicalOperator(string trainCars)
        {
            // eg: 1234...
            A = new Queue<char>(trainCars);
            B = new Stack<char>();
            C = new Queue<char>();
            TrainCars = trainCars;
        }

        /// <summary>
        /// Put current car to temporary service rail
        /// </summary>
        public void AtoB()
        {
            if(A.Count > 0)
            {
                char car = A.Dequeue();
                B.Push(car);
                Console.WriteLine($"O: put {car} on temporary service rail");
            }
        }

        /// <summary>
        /// Takes most recent placed car on temporary rail and processes it in servicing
        /// </summary>
        public void BtoC()
        {
            if(B.Count > 0)
            {
                char car = B.Pop();
                C.Enqueue(car);
                Console.WriteLine($"O: service {car} from temporary rail");
            }
        }

        /// <summary>
        /// Takes the next car and processes it directly in servicing
        /// </summary>
        public void AtoC()
        {
            if(A.Count > 0)
            {
                char car = A.Dequeue();
                C.Enqueue(car);
                Console.WriteLine($"O: service {car} directly.");
            }
        }

        /// <summary>
        /// Checks to see if the servicing bay has the correct order of cars
        /// </summary>
        /// <param name="desiredOrder">string input of the cars to service</param>
        /// <returns>true if correct, otherwise false</returns>
        public bool IsServiceOrderCorrect(string desiredOrder)
        {
            char[] cArr = C.ToArray();
            char[] desiredOrderCars = desiredOrder.ToCharArray();
            if(cArr.Length != desiredOrderCars.Length)
            {
                return false;
            }

            for(int i = 0; i < desiredOrder.Length; i++)
            {
                if(cArr[i] != desiredOrderCars[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}