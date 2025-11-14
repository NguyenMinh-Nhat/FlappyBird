namespace CustomProgram
{
    public class OrbFactory
    {
        public Orb CreateOrb(OrbEffectType type)
        {
            Orb newOrb = new Orb();
            
            switch (type)
            {
                case OrbEffectType.Health:
                    break;
                case OrbEffectType.Imune:
                    break;
            }
            return newOrb;
        }
    }
}