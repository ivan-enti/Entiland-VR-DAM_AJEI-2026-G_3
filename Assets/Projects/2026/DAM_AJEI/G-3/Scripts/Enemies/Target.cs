using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected float health = 5f;

        private EnemySpawner spawner = null;
        public abstract void ReciveDamage(float damage);

        public virtual void Die()
        {
            if(spawner != null) { spawner.EnemyEliminated(); }
            gameObject.SetActive(false);
        }

        public void SetSpawner(EnemySpawner set_spawner) { spawner = set_spawner; }
    }
}
