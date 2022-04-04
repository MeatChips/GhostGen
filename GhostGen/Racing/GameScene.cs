using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace GhostGen
{
    class GameScene : SceneNode
    {
        public GameScene() : base()
        {
            Reload();
        }

        private GreenCar player1;
        private BlueCar player2;

        public void Reload()
        {
            player1 = new GreenCar("resources/GreenCar2.png");
            AddChild(player1);

            player2 = new BlueCar("resources/BlueCar2.png");
            AddChild(player2);
        }

        public override void Update(float deltaTime)
        {
            InputPlayer1(deltaTime);
            InputPlayer2(deltaTime);
        }

        public void InputPlayer1(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                player1.GoForward();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                player1.GoLeft(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                player1.GoRight(deltaTime);
            }
        }

        public void InputPlayer2(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                player2.GoForward();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                player2.GoLeft(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                player2.GoRight(deltaTime);
            }
        }

    }
}
