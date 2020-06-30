using System;
using System.Collections.Generic;
using System.Linq;
using AbcTrain;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1,2,3", "1,2,3", true)]
        [InlineData("1,2,3", "3,2,1", true)]
        [InlineData("1,2,3", "1,3,2", true)]
        [InlineData("1,2,3", "2,3,1", true)]
        [InlineData("1,2,3", "2,1,3", true)]
        [InlineData("1,2,3,4", "4,2,1,3", false)]
        [InlineData("1,2,3,4", "3,2,1,4", true)]
        public void DDTServicing(string trainCars, string inputServiceRequest, bool expectedAnswer)
        {
            var originalCars = trainCars.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            var serviceRequest = inputServiceRequest.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            PhysicalOperator op = new PhysicalOperator(originalCars);
            TrainMaster master = new TrainMaster(op);
            master.ServiceCars(serviceRequest);
            bool result = op.IsServiceOrderCorrect(serviceRequest);
            Assert.Equal(expectedAnswer, result);
        }
    }
}
