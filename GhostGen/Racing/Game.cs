using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Raylib

namespace GhostGen
{
    class Game
    {
        private Core core;
        private Scene scene;

        public Game()
        {
            core = new Core("GhostGen");

            scene = new Scene();

            Entity ImagePNG = new Entity("resources/victory.png");
            ImagePNG.Position = new Vector2((int)Settings.ScreenSize.X / 2, (int)Settings.ScreenSize.Y / 2);

            scene.AddNode(ImagePNG);
        }

        public void Play()
        {
            while (core.Run(scene))
            {
                ;
            }
            Console.WriteLine("Thank you for playing!");
        }
    }
}
