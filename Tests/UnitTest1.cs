using FlexyBox;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private readonly InstanceService instanceService;

        public UnitTest1()
        {
            instanceService = new InstanceService();
        }

        #region InstanceService.GetInstances tests
        [Fact]
        public void instanceService_GetInstances()
        {
            var p = (List<Vehicle>) instanceService.GetInstances<Vehicle>();

            Assert.Equal(4, p.Count);
        }
        #endregion

        #region InstanceService SearchTypes tests
        [Fact]
        public void instanceService_SearchTypes_positive_1()
        {
            var p = (List<Type>) instanceService.SearchTypes("car");

            Assert.Equal(2, p.Count);
        }

        [Fact]
        public void instanceService_SearchTypes_positive_2()
        {
            var p = (List<Type>) instanceService.SearchTypes("bi");

            Assert.Equal(1, p.Count);
        }
        [Fact]
        public void instanceService_SearchTypes_negative_1()
        {
            var p = (List<Type>) instanceService.SearchTypes("zx");

            Assert.Equal(0, p.Count);
        }
        #endregion  
    }
}
