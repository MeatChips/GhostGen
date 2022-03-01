using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGen
{
	class Scene
	{
		private List<Entity> entities;

		public Scene()
		{
			entities = new List<Entity> ();
		}

		public void AddNode(Entity n)
		{
			entities.Add (n);
		}

		public void UpdateScene(float deltaTime)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				entities[i].Update(deltaTime);
			}
		}
	}
}
