using System;
using System.Collections.Generic;
using System.Text;

namespace GhostGen
{
	class Scene
	{
		private List<Node> nodes;

		public Scene()
		{
			nodes = new List<Node> ();
			Console.WriteLine("Scene ctor");
		}

		public void AddNode(Node n)
		{ 
			nodes.Add (n);
		}

		public void UpdateScene(float deltaTime)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				nodes[i].Update(deltaTime);
			}
		}
	}
}
