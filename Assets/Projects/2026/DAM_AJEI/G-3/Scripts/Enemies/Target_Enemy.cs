using System.Collections;
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
        private float current_speed = 1.0f;

        private void Start()
        {
            playerHealth = GameController.Instance.t_player.GetComponent<PlayerHealth>();
            current_speed = speed;
        }
        private void Update()
        {
            Transform player = GameController.Instance.t_player;
            transform.LookAt(player);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > attackDistance)
            {
                transform.position += transform.forward * current_speed * Time.deltaTime;
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
        public override void FrezeEffect(float time)
        {
            if (!frost)
            {
                StartCoroutine(Corutine_Freze(time));
            }
        }
        private IEnumerator Corutine_Freze(float time)
        {
            current_speed = speed / 2;
            frost = true;
            yield return new WaitForSeconds(time);
            current_speed = speed;
            frost = false;
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
