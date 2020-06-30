using System;
using System.Collections.Generic;

namespace AbcTrain
{
    public class PhysicalOperator
    {
        /// <summary>
        /// Starting point entering into the station with all cars.
        /// </summary>
        Queue<int> A;

        /// <summary>
        /// A servicing rail has been provided to temporarily move the cars
        /// </summary>
        Stack<int> C;
        
        /// <summary>
        /// Physical operator wants all train cars on C in order of provided desired input.
        /// </summary>
        Queue<int> B;
        
        public List<int> TrainCars { get; private set; }

        /// <summary>
        /// Constructs an operator, assumption is that traincars are always ascending.
        /// </summary>
        /// <param name="trainCars">ascending numerical values when they are at the entrance.</param>
        public PhysicalOperator(List<int> trainCars)
        {
            // eg: 1234...
            A = new Queue<int>(trainCars);
            C = new Stack<int>();
            B = new Queue<int>();
            TrainCars = trainCars;
        }

        /// <summary>
        /// Put current car to temporary service rail
        /// </summary>
        public void AtoC()
        {
            if(A.Count > 0)
            {
                int car = A.Dequeue();
                C.Push(car);
                Console.WriteLine($"O: put {car} on temporary service rail");
            }
        }

        /// <summary>
        /// Takes most recent placed car on temporary rail and processes it in servicing
        /// </summary>
        public void CtoB()
        {
            if(C.Count > 0)
            {
                int car = C.Pop();
                B.Enqueue(car);
                Console.WriteLine($"O: service {car} from temporary rail");
            }
        }

        /// <summary>
        /// Takes the next car and processes it directly in servicing
        /// </summary>
        public void AtoB()
        {
            if(A.Count > 0)
            {
                int car = A.Dequeue();
                B.Enqueue(car);
                Console.WriteLine($"O: service {car} directly.");
            }
        }

        /// <summary>
        /// Checks to see if the servicing bay has the correct order of cars
        /// </summary>
        /// <param name="desiredOrder">string input of the cars to service</param>
        /// <returns>true if correct, otherwise false</returns>
        public bool IsServiceOrderCorrect(List<int> desiredOrder)
        {
            int[] cArr = B.ToArray();
            int[] desiredOrderCars = desiredOrder.ToArray();
            if(cArr.Length != desiredOrderCars.Length)
            {
                return false;
            }

            for(int i = 0; i < desiredOrder.Count; i++)
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