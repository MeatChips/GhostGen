using System.Numerics;

namespace GhostGen
{
    interface IMovable
    {
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }

        void Move(float deltaTime);
        void AddForce(Vector2 force);
    }
}
