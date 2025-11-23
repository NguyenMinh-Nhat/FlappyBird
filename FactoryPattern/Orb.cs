using SplashKitSDK;
using System;

namespace CustomProgram
{
    public class Orb : GameObject, ICollectable
    {
        private float speed = 200f;

        private OrbEffectType _effectType;
        private Color _orbColor;

        public Orb()
        {
            this.Width = 30f;
            this.Height = 30f;
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