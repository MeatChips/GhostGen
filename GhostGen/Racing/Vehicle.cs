using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
    class Vehicle : MoveNode
    {
        //private float forwardForce;
        private float rotSpeed;

        float boost_time;
        float idle_time;
        float boost_timer;
        float idle_timer;
        bool boostable;


        public Vehicle(string name) : base(name)
        {
            Position = new Vector2(640, 35);
            Pivot = new Vector2(0.5f, 0.5f);
            //Scale = new Vector2(.5f, .5f);

            //forwardForce = 10;
            rotSpeed = (float)Math.PI;

            boost_time = 5.0f;
            idle_time = 3.0f;

            boost_timer = 0.0f;
            idle_timer = 0.0f;
            boostable = true;
        }

        public override void Update(float deltaTime) // override implementation of MoverNode.Update()
        {
            // MoverNode (IMovable)
            base.Update(deltaTime);
        }

        public void GoForward(float deltaTime)
        {
            float movespeedF = 100;

            position.X -= movespeedF * (float)Math.Sin(rotation) * deltaTime;
            position.Y += movespeedF * (float)Math.Cos(rotation) * deltaTime;

            //myentity->position.x -= movespeedF * sin(a) * deltaTime;
            //myentity->position.y += movespeedF * cos(a) * deltaTime;

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
            float movespeedB = 50;

            position.X += movespeedB * (float)Math.Sin(rotation) * deltaTime;
            position.Y -= movespeedB * (float)Math.Cos(rotation) * deltaTime;

            //myentity->position.x += movespeedB * sin(a) * deltaTime;
            //myentity->position.y -= movespeedB * cos(a) * deltaTime;
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
