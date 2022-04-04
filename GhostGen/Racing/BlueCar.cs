using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
    class BlueCar : MoveNode
    {
        private float forwardForce;
        private float rotSpeed;

        public BlueCar(string name) : base(name)
        {
            Position = new Vector2(200, Settings.ScreenSize.Y / 2);
            Pivot = new Vector2(0.5f, 0.5f);
            Scale = new Vector2(.5f, .5f);

            forwardForce = 100;
            rotSpeed = (float)Math.PI;
        }

        public void GoForward()
        {
            float x = (float)Math.Cos(Rotation);
            float y = (float)Math.Sin(Rotation);
            AddForce(new Vector2(x, y) * forwardForce); 
        }

        public void GoLeft(float deltaTime)
        {
            Rotation -= rotSpeed * deltaTime;
        }

        public void GoRight(float deltaTime)
        {
            Rotation += rotSpeed * deltaTime;
        }

        //public void GoBackwards()
        //{
        //
        //}
    }
}
