using SplashKitSDK;

namespace CustomProgram
{
    public class SoundManager : IObserver
    {
        private SoundEffect _jumpSound;
        private SoundEffect _scoreSound;
        private SoundEffect _hitSound;
        private SoundEffect _dieSound;
        private SoundEffect _orbSound;
        private Music _bgMusic;

        private int _lastScore;
        private int _lastHealth;

        public SoundManager()
        {
            try {
            // Sound Effect
            _jumpSound = SplashKit.LoadSoundEffect("Jump", "wing.wav");
            _scoreSound = SplashKit.LoadSoundEffect("Score", "score.wav");
            _hitSound = SplashKit.LoadSoundEffect("Hit", "hit.wav");
            _dieSound = SplashKit.LoadSoundEffect("Die", "die.wav");
            _orbSound = SplashKit.LoadSoundEffect("Orb", "orb.mp3");

            // Music
            _bgMusic = SplashKit.LoadMusic("BGM", "bgm.mp3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load sound: " + ex.Message);
            }
        }


        public void StartMusic()
        {
            if (!SplashKit.MusicPlaying())
            {
                SplashKit.SetMusicVolume(0.05f); // volume (5%)
                SplashKit.PlayMusic(_bgMusic, -1);  // loop background music
            }
        }

        public void StopMusic()
        {
            SplashKit.StopMusic();
        }

        public void PlayJump()
        {
            SplashKit.PlaySoundEffect(_jumpSound);
        }

        public void UpdateHealth(int currentHealth)
        {
            // Health reducing? -> Trigger sound
            if (currentHealth < _lastHealth)
            {
                SplashKit.PlaySoundEffect(_hitSound);
            }
            _lastHealth = currentHealth;
        }
        
        public void PlayOrbSound()
        {
            SplashKit.PlaySoundEffect(_orbSound);
        }
        // Reset State
        public void OnGameReset()
        {
            _lastScore = 0;
            _lastHealth = 5;
        }

        public void BirdDie()
        {
            // Play Die Sound
            SplashKit.PlaySoundEffect(_dieSound);
        }

        public void OnGameOver()
        {
            StopMusic();
        }
        public void Update(int newScore)
        {
            // Play sound when new score
            if (newScore > _lastScore)
            {
                SplashKit.SetMusicVolume(0.1f);
                SplashKit.PlaySoundEffect(_scoreSound);
            }
            _lastScore = newScore;
        }
        
    }
}