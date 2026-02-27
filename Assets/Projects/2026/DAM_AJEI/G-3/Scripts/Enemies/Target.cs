using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected float health = 5f;

        public abstract void TakeDamage(float damage);

        public virtual void Die()
        {
            GameController.Instance.EnemyEliminated();
            gameObject.SetActive(false);
        }

    }
}
