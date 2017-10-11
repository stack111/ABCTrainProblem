using System;

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
            
        }
    }
}
