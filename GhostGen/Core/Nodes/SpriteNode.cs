using System; // Math.PI
using System.Numerics; // Vector2
using Raylib_cs; // Raylib

namespace GhostGen
{
    class SpriteNode : Node, IDrawable
    {
        private string fileName;
        private Vector2 fileSize;
        private Vector2 pivot;
        private Color color;

        public string TextureName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public Vector2 TextureSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public Vector2 Pivot
        {
            get { return pivot; }
            set { pivot = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

		public SpriteNode()
		{
			fileName = "";
			Position = new Vector2(0.0f, 0.0f);
			Rotation = 0.0f;
			Scale = new Vector2(1.0f, 1.0f);
			Pivot = new Vector2(0.5f, 0.5f);
		}

		public SpriteNode(string fn = "")
		{
			fileName = fn;
			Position = new Vector2(0.0f, 0.0f);
			Rotation = 0.0f;
			Scale = new Vector2(1.0f, 1.0f);
			Pivot = new Vector2(0.5f, 0.5f);
		}

		public override void Update(float deltaTime)
		{
			// virtual (override in subclass)
			// or don't, then this will be called
			Draw();
		}

		public void Draw()
		{
			ResourceManager resman = ResourceManager.Instance;
			Texture2D texture = resman.GetTexture(fileName);
			float width = texture.width;
			float height = texture.height;
			// this Entity might not know its Size yet...
			if (fileSize.X == 0)
			{
				Vector2 size = new Vector2(width, height);
				fileSize = size;
			}

			// draw the Texture
			Rectangle sourceRec = new Rectangle(0.0f, 0.0f, width, height);
			Rectangle destRec = new Rectangle(Position.X, Position.Y, width * Scale.X, height * Scale.Y);
			Vector2 pivot = new Vector2(width * Pivot.X * Scale.X, height * Pivot.Y * Scale.Y);
			float rot = Rotation * 180 / (float)Math.PI;
			Raylib.DrawTexturePro(texture, sourceRec, destRec, pivot, rot, Color.WHITE);
		}

	}
}
