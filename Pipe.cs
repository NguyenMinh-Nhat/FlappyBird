namespace CustomProgram
{
    public class Pipe : GameObject, IPipe
    {
        private float speed;

        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public override void Update()
        {

        }

        public void Move()
        {
            
        }
    }
}