
namespace Game.Contracts
{
    public interface IGridService
    {
        public int[,] mainGrid { get; set; }
        public void SetNewGrid();
        public bool CheckFor2048();
        public bool CheckIfGridIsFull();
        public void AddNewNumberToGrid();
    }
}
