using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class Target_Enemy : Target
    {
        [SerializeField] private float speed = 1.0f;
        private void Update()
        {
            transform.LookAt(GameController.Instance.t_player.position);
            transform.position += transform.forward * speed * Time.deltaTime;
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
