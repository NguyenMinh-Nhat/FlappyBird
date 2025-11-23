using System.Collections.Generic;
using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class OrbManager 
    {
        private List<Orb> _orbs;
        private OrbFactory _factory;
        private Random _random;
        private PipeManager _pipeManager;
        private float _spawnTimer = 0f; // Counter
        private float _minSpawnTime = 2.0f; // Waiting Time

        public List<Orb> Orbs { get { return _orbs; } } 


        public OrbManager(PipeManager pipeManager)
        {
            try {
                _orbs = new List<Orb>();
                _factory = new OrbFactory();
                _random = new Random();
                _pipeManager =  pipeManager;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Spawn Orbs: " + ex.Message);
            }
        }

        public void Update(float deltaTime)
        {
            // Move Orb
            foreach (var orb in _orbs)
            {
                orb.Update(deltaTime);
            }

            // Delete Orb
            for (int i = _orbs.Count - 1; i >= 0; i--)
            {
                if (_orbs[i].X < -50)
                {
                    _orbs.RemoveAt(i);
                }
            }

            // Random Spawn Orb Logic
            if (_spawnTimer > 0)
            {
                _spawnTimer -= deltaTime;
            }

            // Only Spawn if counter time out
            if (_spawnTimer <= 0)
            {
                // Get list pipes
                if (_pipeManager.ListPipes.Count > 0)
                {
                    Pipe lastPipe = _pipeManager.ListPipes[_pipeManager.ListPipes.Count - 1];
                    
                    // Only spawn if last pipe is appeared
                    if (lastPipe.X < 800 && lastPipe.X > 750) 
                    {
                         // Random spawn lucky (30%)
                         if (_random.Next(0, 100) < 30) 
                         {
                             SpawnOrb();
                             
                             // counting down
                             _spawnTimer = _minSpawnTime; 
                         }
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (var orb in _orbs)
            {
                orb.Draw();
            }
        }
        
        public void Reset()
        {
            _orbs.Clear();
        }

        private void SpawnOrb()
        {
            // Only spawn if have pipes
            if (_pipeManager.ListPipes.Count > 0)
            {
                Pipe lastPipe = _pipeManager.ListPipes[_pipeManager.ListPipes.Count - 1];
                
                // Spawn at middle between 2 pipes
                float spawnX = lastPipe.X - (_pipeManager.PipeDistance / 2) + (lastPipe.Width / 2);
                float spawnY = _random.Next(150, 450);
                
                OrbEffectType randomType = (OrbEffectType)_random.Next(0, 3); // Random types
                
                Orb orb = _factory.CreateOrb(randomType, spawnX, spawnY);
                _orbs.Add(orb);
            }
        }
    }
}