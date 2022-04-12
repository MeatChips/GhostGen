using System; // Random, Math
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Raylib
using System.Timers;

namespace GhostGen
{
    class GameScene : SceneNode
    {
        public GameScene() : base()
        {
            Reload();
        }

        // Backgrounds / UI
        private Background racingField;
        private Background number1;
        private Background number2;
        private Background colorX1;
        private Background colorX2;

        // Vehicles
        private Vehicle player1;
        private Vehicle player2;

        public void Reload()
        {
            // Adding sprites(Vehicles / Background) to the screen

            // Backgrounds
            racingField = new Background("resources/RacingField.png");
            racingField.Position = new Vector2(640, 360);
            AddChild(racingField);

            // UI
            number1 = new Background("resources/Number1.png");
            number1.Position = new Vector2(200, 360);
            AddChild(number1);

            number2 = new Background("resources/Number2.png");
            number2.Position = new Vector2(1000, 360);
            AddChild(number2);

            colorX1 = new Background("resources/GreenX.png");
            colorX1.Position = new Vector2(1060, 360);
            AddChild(colorX1);

            colorX2 = new Background("resources/GreenX.png");
            colorX2.Position = new Vector2(260, 360);
            AddChild(colorX2);

            // Vehicles
            player1 = new Vehicle("resources/RedRocket2.png");
            AddChild(player1);

            player2 = new Vehicle("resources/PurpleRocket2.png");
            AddChild(player2);
        }

        // Update
        public override void Update(float deltaTime)
        {
            InputPlayer1(deltaTime);
            InputPlayer2(deltaTime);
        }



        // Movement player 1
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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                player1.goBoost(deltaTime);
                if(Vehicle.boostable == true)
                {
                    colorX1 = new Background("resources/RedX.png");
                    colorX1.Position = new Vector2(1060, 360);
                    AddChild(colorX1);
                } else if (Vehicle.boostable == false)
                {
                    colorX1 = new Background("resources/GreenX.png");
                    colorX1.Position = new Vector2(1060, 360);
                    AddChild(colorX1);
                }

            }
        }

        // Movement player 2
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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT))
            {
                player2.goBoost(deltaTime);
                if (Vehicle.boostable == true)
                {
                    colorX2 = new Background("resources/RedX.png");
                    colorX2.Position = new Vector2(260, 360);
                    AddChild(colorX2);
                } else if (Vehicle.boostable == false)
                {
                    colorX2 = new Background("resources/GreenX.png");
                    colorX2.Position = new Vector2(260, 360);
                    AddChild(colorX2);
                }
            }

        }

    }
}
