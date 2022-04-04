using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Raylib

namespace GhostGen
{
    class Game
    {
        private Core core;
        private GameScene currentScene;

        public Game()
        {
            core = new Core("GhostGen - Racing Game");

            currentScene = new GameScene();
        }

        public void Play()
        {
            while (core.Run(currentScene))
            {
                ;
            }
            Console.WriteLine("Thank you for playing!");
        }
    }
}
