using System.Numerics; // Vector2
using Raylib_cs; // Raylib

namespace GhostGen
{
	class Core
	{
		public Core(string title)
		{
			int width = (int)Settings.ScreenSize.X;
			int height = (int)Settings.ScreenSize.Y;
			Raylib.InitWindow(width, height, title);
		}

		public bool Run(Scene scene)
		{
			if (Raylib.WindowShouldClose())
			{
				ResourceManager.Instance.CleanUp();
				Raylib.CloseWindow();
				return false;
			}

			// how many seconds since the last frame?
			float deltaTime = Raylib.GetFrameTime();

			// draw the scene
			Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

			// Update (and Draw) all nodes in the Scene
			scene.UpdateScene(deltaTime);

				Raylib.DrawFPS(12, 12);
			Raylib.EndDrawing();

			return true;
		}
	}
}
