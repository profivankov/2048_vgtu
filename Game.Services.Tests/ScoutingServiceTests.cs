using Game.Contracts;
using NUnit.Framework;
using System;

namespace Game.Services.Tests
{
    public class ScoutingServiceTests
    {
        private IScoutingService scoutingService;
        private IGridService gridService;

        [SetUp]
        public void Setup()
        {
            scoutingService = new ScoutingService();
            gridService = new GridService();
        }

        [Test]
        public void CheckIfArraysEqual_ShouldReturnTrue_WhenEqual()
        {
            gridService.SetNewGrid();
            var firstArray = new int[4, 4];
            var random = new Random();
            var secondArray = new int[4,4];


            bool expected = true;
            var result = scoutingService.CheckIfArraysEqual(firstArray, secondArray);

            Assert.AreEqual(expected, result);
        }


    }
}