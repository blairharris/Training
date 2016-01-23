using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockBandsWebApi.Models;
using RockBandsWebApi.Repository;
using FluentAssertions;

namespace RockBandsWebApi.Tests
{
    [TestClass]
    public class InMemoryDatabaseObjectContextTest
    {
        [TestMethod]
        public void GetBand1()
        {
            RockBand band1 = InMemoryDatabaseObjectContext.Instance.GetById(1);
            band1.Id.Should().Be(1);
        }

        [TestMethod]
        public void GetBand0DoesntExist()
        {
            RockBand band0 = InMemoryDatabaseObjectContext.Instance.GetById(0);
            band0.Should().BeNull();
        }

    }
}
