using System; // Math
using System.Numerics; // Vector2
using Raylib_cs; // Raylib

namespace GhostGen
{
    class VehicleTwo : MoveNode
    {
        //private float forwardForce;
        private float rotSpeed;

        public VehicleTwo(string name) : base(name)
        {
            Position = new Vector2(640, 55);
            Pivot = new Vector2(0.5f, 0.5f);
            //Scale = new Vector2(.5f, .5f);

            //forwardForce = 10;
            rotSpeed = (float)Math.PI;
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
    }
}

