using System;

namespace CustomProgram
{

    public class HealthSystem : IDamageable
    {

        private int _currentHealth;
        private int _maxHealth;

        // Immune variable
        private bool _isInvincible;     
        private float _invincibleTimer; 
        private float _cooldownTime;    

        // Properties


        public int CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
            }
        }

        public bool IsDead
        {
            get
            {
                return _currentHealth <= 0;
            }
        }

        public bool IsInvincible
        {
            get
            {
                return _isInvincible;
            }
        }

        // Constructor
        public HealthSystem(int maxHealth, float immuneDuration = 1.2f)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _cooldownTime = immuneDuration;
            
            _isInvincible = false;
            _invincibleTimer = 0f;
        }

        // 
        public void Update(float deltaTime)
        {
            if (_isInvincible)
            {
                _invincibleTimer -= deltaTime;
                if (_invincibleTimer <= 0)
                {
                    _isInvincible = false; // Immune Time out
                }
            }
        }

        
        public void TakeDamage(int damage)
        {
            // Immune or dead? -> Skip checking
            if (_isInvincible || IsDead) return;

            // Minus health
            _currentHealth -= damage;
            Console.WriteLine($"Damaged! Health: {_currentHealth}");

            // No health left -> Game Over
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Console.WriteLine("Game Over");
            }
            else
            {
                // If not die trigger Immune (go through pipe)
                ActivateInvincibility(_cooldownTime);
            }
        }


        // Immune
        public void ActivateInvincibility(float duration)
        {
            _isInvincible = true;
            _invincibleTimer = duration;
        }    

        // Reset State
        public void Reset()
        {
            _currentHealth = _maxHealth;
            _isInvincible = false;
            _invincibleTimer = 0f;
        }

        public void Heal(int quantity)
        {
            // Dead? cannot heal
            if (IsDead) return;

            _currentHealth += quantity;

            // Limit max health 
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }

        public void Kill()
        {
            _currentHealth = 0;
            _isInvincible = false;
        }
    }
}