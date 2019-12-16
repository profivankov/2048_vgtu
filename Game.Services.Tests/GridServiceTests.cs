using Game.Contracts;
using NUnit.Framework;

namespace Game.Services.Tests
{
    public class GridServiceTests
    {
        private IGridService gridService;
        private IScoutingService scoutingService;

        [SetUp]
        public void Setup()
        {
            gridService = new GridService();
            scoutingService = new ScoutingService();
        }

        [Test]
        public void CheckIfGridIsFull_ShouldReturnTrue_WhenGridIsFull()
        {
            gridService.SetNewGrid();
            var mainGrid = gridService.mainGrid;
            // fill grid up with 1s
            for (int i = 0; i < mainGrid.GetLength(0); i++)
            {
                for (int j = 0; j < mainGrid.GetLength(1); j++)
                {
                    mainGrid[i, j] = 1;
                }
            }

            bool expected = true;
            var result = gridService.CheckIfGridIsFull();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CheckIfGridIsFull_ShouldReturnFalse_WhenGridIsNotFull()
        {
            gridService.SetNewGrid();

            bool expected = false;
            var result = gridService.CheckIfGridIsFull();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddNewNumberToGrid_ShouldAddNewNumber_WhenCalled()
        {
            gridService.SetNewGrid();
            var startingGrid = (int[,])gridService.mainGrid.Clone();

            gridService.AddNewNumberToGrid();
            var resultGrid = gridService.mainGrid;

            bool expected = false;
            var result = scoutingService.CheckIfArraysEqual(startingGrid, resultGrid);

            Assert.AreEqual(expected, result);
        }


    }
}