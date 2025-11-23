using SplashKitSDK;
using System;

namespace CustomProgram
{
    public class Orb : GameObject, ICollectable
    {
        private float x;
        private float y;
        private float width = 30f;
        private float height = 30f;
        private float speed = 200f;

        private OrbEffectType _effectType;
        private Color _orbColor;

        // Property
        public float X
        {
            get{ return x;}
            set{ x = value;}
        }

        public float Y
        {
            get{ return y;}
            set{ y = value;}            
        }

        public float Width
        {
            get{ return width;}
            set{ width = value;}            
        }

        public float Height
        {
            get{ return height;}
            set{ height = value;}            
        }

        public float Speed
        {
            get{ return speed;}
            set{ speed = value;}            
        }


        public OrbEffectType EffectType
        {
            get 
            { 
                return _effectType; 
            }
            set 
            { 
                _effectType = value; 
            }
        }

        public Color OrbColor
        {
            get 
            { 
                return _orbColor; 
            }
            set 
            { 
                _orbColor = value; 
            }
        }

        // Orb Hitbox
        public Rectangle CollisionBox
        {
            get { return SplashKit.RectangleFrom(X, Y, Width, Height); }
        }

        public bool OnCollected()
        {
            return true;
            // Console.WriteLine("Orb Collected!");
        }

        public override void Update(float deltaTime)
        {
            // Move Orb
            X -= Speed * deltaTime;
        }

        public override void Draw()
        {
            // Draw Circle
            SplashKit.FillCircle(OrbColor, X + Width/2, Y + Height/2, Width/2);
            // Draw outline
            SplashKit.DrawCircle(Color.Black, X + Width/2, Y + Height/2, Width/2);
        }
    }
}