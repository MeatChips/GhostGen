using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
    class MoveNode : SpriteNode, IMovable
    {
		// Implementation of IMovable: Velocity, Acceleration
		protected Vector2 velocity;
		protected Vector2 acceleration;

		public Vector2 Velocity
		{
			get { return velocity; }
			set { velocity = value; }
		}
		public Vector2 Acceleration
		{
			get { return acceleration; }
			set { acceleration = value; }
		}

		protected MoveNode(string name) : base(name)
		{
			Velocity = new Vector2(0.0f, 0.0f);
			Acceleration = new Vector2(0.0f, 0.0f);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime); // SpriteNode.Draw()
			Move(deltaTime); // IMovable
		}

		// Implementation of IMovable: Move(float deltaTime), AddForce(Vector2 force)
		public void Move(float deltaTime)
		{
			// apply motion 101
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// reset acceleration
			Acceleration *= 0.0f;
		}

		public void AddForce(Vector2 force)
		{
			Acceleration += force;
		}
	}
}
