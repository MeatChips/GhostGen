using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
    class Vehicle : MoveNode
    {
        // Rotation
        private float rotSpeed;

        // Time
        float boost_time;
        float idle_time;

        // Timer
        float boost_timer;
        float idle_timer;

        // Bool
        public static bool boostable;


        public Vehicle(string name) : base(name)
        {
            // Position/Pivot/Scale/Rotation
            Position = new Vector2(640, 35);
            Pivot = new Vector2(0.5f, 0.5f);

            // Rotation
            rotSpeed = (float)Math.PI;

            // Time
            boost_time = 5.0f;
            idle_time = 5.0f;

            // Timer
            boost_timer = 0.0f;
            idle_timer = 0.0f;

            // Bool
            boostable = true;
        }

        public override void Update(float deltaTime) // override implementation of MoverNode.Update()
        {
            // MoverNode (IMovable)
            base.Update(deltaTime);
        }

        public void GoForward(float deltaTime)
        {
            // Variables
            float movespeedF = 100;

            position.X -= movespeedF * (float)Math.Sin(rotation) * deltaTime;
            position.Y += movespeedF * (float)Math.Cos(rotation) * deltaTime;
        }

        public void GoLeft(float deltaTime)
        {
            Rotation -= rotSpeed * deltaTime;
        }

        public void GoRight(float deltaTime)
        {
            Rotation += rotSpeed * deltaTime;
        }

        public void GoBackwards(float deltaTime)
        {
            // Variables
            float movespeedB = 50;

            position.X += movespeedB * (float)Math.Sin(rotation) * deltaTime;
            position.Y -= movespeedB * (float)Math.Cos(rotation) * deltaTime;
        }

        public void goBoost(float deltaTime)
        {
            float movespeedF = 100;

            if (boostable)
            {
                boost_timer += deltaTime;
                position.X -= movespeedF * (float)Math.Sin(rotation) * deltaTime;
                position.Y += movespeedF * (float)Math.Cos(rotation) * deltaTime;

                if (boost_timer >= boost_time)
                {
                    boostable = false;
                    boost_timer = 0.0f;
                    Console.WriteLine("boost time up");
                }
            }
            else
            {
                idle_timer += deltaTime;
                if (idle_timer >= idle_time)
                {
                    boostable = true;
                    idle_timer = 0.0f;
                    Console.WriteLine("we can boost again");
                }
            }


        }
    }
}
