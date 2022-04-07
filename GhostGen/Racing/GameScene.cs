using System; // Random, Math
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Raylib

namespace GhostGen
{
    class GameScene : SceneNode
    {
        public GameScene() : base()
        {
            Reload();
        }
        
        private VehicleTwo player1;
        private VehicleOne player2;
        private Background racingField;

        public void Reload()
        {
            racingField = new Background("resources/RacingField.png");
            AddChild(racingField);

            player1 = new VehicleTwo("resources/RedRocket2.png");
            AddChild(player1);

            player2 = new VehicleOne("resources/PurpleRocket2.png");
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
                player1.GoForward(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                player1.GoLeft(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                player1.GoRight(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                player1.GoBackwards(deltaTime);
            }
        }

        public void InputPlayer2(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                player2.GoForward(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                player2.GoLeft(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                player2.GoRight(deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                player2.GoBackwards(deltaTime);
            }
        }

    }
}
