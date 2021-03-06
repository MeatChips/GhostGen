using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
    class Background : MoveNode
    {
        public Background(string name) : base(name)
        {
            
        }

        public override void Update(float deltaTime) // override implementation of MoverNode.Update()
        {
            // MoverNode (IMovable)
            base.Update(deltaTime);
        }
    }
}
