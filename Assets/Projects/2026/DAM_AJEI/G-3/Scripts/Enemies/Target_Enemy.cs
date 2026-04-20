using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class Target_Enemy : Target
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float attackDistance = 1.5f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackCooldown = 1f;

        private float attackTimer;
        private PlayerHealth playerHealth;

        private void Start()
        {
            playerHealth = GameController.Instance.t_player.GetComponent<PlayerHealth>();
        }
        private void Update()
        {
            Transform player = GameController.Instance.t_player;
            transform.LookAt(player);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > attackDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                Attack();
            }
        }
        public override void TakeDamage(float damage)
        {
            health -= damage;
            if(health <= 0)
            {
                Die();
            }
        }
        private void Attack()
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                playerHealth.TakeDamage(damage);
                attackTimer = attackCooldown;
            }
        }
        public override void Die()
        {
            base.Die();
        }
    }
}
