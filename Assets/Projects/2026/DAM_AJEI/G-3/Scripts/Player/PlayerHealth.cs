using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float max_health = 100f;
        [SerializeField] private float regen_per_second = 0.01f;
        [SerializeField] private UIHealth UIHealth;

        private float current_health = 0;
        private void Start()
        {
            current_health = max_health;
        }
        void Update ()
        {
            UIHealth.UpdateHealthPanel(max_health, current_health);
        }
        public void TakeDamage(float damage)
        {
            current_health -= damage;

            Debug.Log("Player health: " + current_health);

            if (current_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Player died");
        }
    }
}