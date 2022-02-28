using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Texture2D

namespace GhostGen
{
	class Node
	{
		private string filename;

		// Transform
		private Vector2 position;
		private float rotation;
		private Vector2 scale;

		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}
		public float Rotation {
			get { return rotation; }
			set { rotation = value; }
		}
		public Vector2 Scale
		{
			get { return scale; }
			set { scale = value; }
		}

		public Vector2 Pivot
		{
			get; set;
		}
		// Constructor
		public Node()
		{
			filename = "";
			Position = new Vector2(0.0f, 0.0f);
			Rotation = 0.0f;
			Scale = new Vector2(1.0f, 1.0f);
			Pivot = new Vector2(0.5f, 0.5f);
		}

		public Node(string fn)
		{
			filename = fn;
			Position = new Vector2(0.0f, 0.0f);
			Rotation = 0.0f;
			Scale = new Vector2(1.0f, 1.0f);
			Pivot = new Vector2(0.5f, 0.5f);
		}

		public virtual void Update(float deltaTime)
		{
			// virtual (override in subclass)
			// or don't, then this will be called
			Draw();
		}

		public void Draw()
		{
			ResourceManager resman = ResourceManager.Instance;
			Texture2D texture = resman.GetTexture(filename);
			float width = texture.width;
			float height = texture.height;

			// draw the Texture
			Rectangle sourceRec = new Rectangle(0.0f, 0.0f, width, height);
			Rectangle destRec = new Rectangle(Position.X, Position.Y, width * Scale.X, height * Scale.Y);
			Vector2 pivot = new Vector2(width * Pivot.X * Scale.X, height * Pivot.Y * Scale.Y);
			float rot = Rotation * 180 / (float)Math.PI;
			Raylib.DrawTexturePro(texture, sourceRec, destRec, pivot, rot, Color.WHITE);
		}

	}
}
