using System.Drawing;
using System.Numerics;

namespace CustomProgram
{
    public abstract class GameObject
    {
        public Vector2 position;
        public Rectangle boundingBox;
        public abstract void Update();
        public void Draw()
        {
            
        }
    }
}