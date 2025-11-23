using SplashKitSDK;

namespace CustomProgram
{
    public class OrbFactory
    {
        public Orb CreateOrb(OrbEffectType type, float x, float y)
        {
            Orb newOrb = new Orb();
            newOrb.X = x;
            newOrb.Y = y;
            newOrb.EffectType = type;
            
            switch (type)
            {
                case OrbEffectType.Health: // Health
                    newOrb.OrbColor = Color.Red;
                    break;
                    
                case OrbEffectType.Imune: // Immune
                    newOrb.OrbColor = Color.Yellow; 
                    break;
                    
                case OrbEffectType.Point: // Point
                    newOrb.OrbColor = Color.Purple;
                    break;
            }
            
            return newOrb;
        }
    }
}