using System.Collections.Generic;
using System;
namespace CustomProgram
{
    public class PipeManager 
    {
        public float spawnRate;
        private List<Pipe> Pipes = null!;
        private Random random = null!;
        // Constant
        private int PIPEDISTANCE = 300;
        private int PIPEGAP = 130;

        // Constructor 
        public PipeManager()
        {
            try
            { 
                this.Pipes = new List<Pipe>();
                this.random = new Random();
                this.SpawnPipe();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot spawn pipes: " + ex.Message);
            }
        }

        public float PipeDistance
        {
            get
            {
                return PIPEDISTANCE;
            }
        }

        public List<Pipe> ListPipes{
            get
            {
                return Pipes;
            }
        }
        public void UpdatePipes(float deltaTime)
        {
            foreach (Pipe pipe in Pipes)
            {
                pipe.Update(deltaTime);

                // If pipe outside box, reset pos
                if (pipe.X < -pipe.Width) 
                {
                    pipe.X = 1100f;

                    // Reset Marked Score 
                    pipe.IsScored = false;
                }
            }            
        }

        public void DrawPipes()
        {
            foreach (Pipe pipe in Pipes)
            {
                pipe.Draw();
            }
        }

        public void SpawnPipe()
        {
            // Clear old pipes 
            Pipes.Clear();

            // Create 4 pipes
            for (int i = 0; i < 4; i++)
            {   
                // Create 4 Pipes UPPER
                int randomHeight = random.Next(150,250);
                float x = 800f + (i * PIPEDISTANCE);
                Pipe upperPipe = new Pipe(x, 0f, 200f);
                upperPipe.Height = randomHeight;
                
                // Add pipe
                Pipes.Add(upperPipe);

                // Create 4 Pipes Lower
                float randomGap = random.Next(110, PIPEGAP);
                float yLower = upperPipe.Height + randomGap;
                Pipe lowerPipe = new Pipe(x, yLower, 200f);
                lowerPipe.Height = 600 - yLower;
                
                // Add pipe
                Pipes.Add(lowerPipe);
            }
        }        

        
        public void Reset()
        {
            // Clear Pipes
            Pipes.Clear();

            // Spawn new Pipes
            SpawnPipe();
        }
    }
}