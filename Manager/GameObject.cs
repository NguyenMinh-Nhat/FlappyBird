using SplashKitSDK;

namespace CustomProgram
{
    public abstract class GameObject
    {
        private float _x;
        private float _y;
        private float _width;
        private float _height;


        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public virtual Rectangle CollisionBox
        {
            get
            {
                return SplashKit.RectangleFrom(X, Y, Width, Height);
            }
        }

        public abstract void Update(float deltaTime);
        public abstract void Draw();
    }
}