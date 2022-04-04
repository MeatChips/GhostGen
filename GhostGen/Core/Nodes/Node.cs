using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List<>
using Raylib_cs; // Texture2D

namespace GhostGen
{
    abstract class Node : ITransformable, IUpdatable
    {
        private ITransformable parent;
        private List<ITransformable> children;
        public List<ITransformable> Children
        {
            get { return children; }
        }
        public ITransformable Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        // Transform
        private Vector2 position;
        private float rotation;
        private Vector2 scale;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private Vector2 worldPosition;
        private float worldRotation;
        private Vector2 worldScale;

        public Vector2 WorldPosition
        {
            get { return worldPosition; }
            set { worldPosition = value; }
        }
        public float WorldRotation
        {
            get { return worldRotation; }
            set { worldRotation = value; }
        }
        public Vector2 WorldScale
        {
            get { return worldScale; }
            set { worldScale = value; }
        }

        protected Node()
        {
            this.children = new List<ITransformable>();
            Parent = null;
            Position = new Vector2(0.0f, 0.0f);
            Rotation = 0.0f;
            Scale = new Vector2(1.0f, 1.0f);
        }

        public virtual void Update(float deltaTime)
        {
            // virtual (override in subclass)
            // or don't, then this will be called
        }

        public bool AddChild(ITransformable child)
        {
            if (children.Contains(child))
            {
                // this is already our child
                return false;
            }
            if (child == this)
            {
                // this is us! we can't be our own child.
                return false;
            }
            if (child.Parent != null) // handle previous owner
            {
                // "kidnap" the child from previous parent
                child.Parent.RemoveChild(child, false);
            }
            child.Parent = this;
            children.Add(child);
            return true;
        }

        public bool RemoveChild(ITransformable child, bool keepAlive = false)
        {
            // we don't know this child
            if (!children.Contains(child))
            {
                return false;
            }

            // do we need to keep this child alive?
            if (keepAlive)
            {
                // pass back up to our parent
                if (this.parent == null)
                {
                    // we're the scene, we have no parents
                    return false;
                }
                child.Parent = this.parent;
                child.Parent.AddChild(child);
            }

            // remove from our children
            children.Remove(child);
            return true;
        }

        public void UpdateNode(float deltaTime)
        {
            // IUpdatable
            Update(deltaTime);

            // A Node is IUpdatable: update all children
            List<ITransformable> children = Children;
            for (int i = 0; i < children.Count; i++)
            {
                ((Node)children[i]).UpdateNode(deltaTime);
            }
        }
    }
}
