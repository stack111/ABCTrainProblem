using System;
using AbcTrain;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("123", "123", true)]
        [InlineData("123", "321", true)]
        [InlineData("123", "132", true)]
        [InlineData("123", "231", true)]
        [InlineData("123", "213", true)]
        public void DDTServicing(string trainCars, string inputServiceRequest, bool expectedAnswer)
        {
            PhysicalOperator op = new PhysicalOperator(trainCars);
            TrainMaster master = new TrainMaster(op);
            master.ServiceCars(inputServiceRequest);
            bool result = op.IsServiceOrderCorrect(inputServiceRequest);
            Assert.Equal(expectedAnswer, result);
        }
    }
}
