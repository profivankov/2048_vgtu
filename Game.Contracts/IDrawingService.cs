
namespace Game.Contracts
{
    public interface IDrawingService
    {
        public void PrintTable(int[,] array);
        public void PrintColumns(int maxColumns, string word);
        public void PrintLine();
        public void PrintRow(params string[] columns);
    }
}
