
namespace Game.Contracts
{
    public interface IMovementService
    {
        public bool AddNumbersUp(int[,] mainGrid);
        public bool AddNumbersDown(int[,] mainGrid);
        public bool AddNumbersRight(int[,] mainGrid);
        public bool AddNumbersLeft(int[,] mainGrid);
    }
}
