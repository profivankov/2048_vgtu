using Game.Services;
using System;

namespace Game.Client
{
    public class Program
    {

        static void Main()
        {
            var builder = new Builder(new MovementService(new ScoutingService()),
                new GridService(),
                new DrawingService());

            builder.Start();
        }
    }
}

