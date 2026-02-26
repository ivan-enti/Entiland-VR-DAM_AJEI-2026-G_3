using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class Target_Enemy : Target
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void ReciveDamage(float damage)
        {
            health -= damage;
            if(health <= 0)
            {
                Die();
            }
        }
        public override void Die()
        {

        }
    }
}
