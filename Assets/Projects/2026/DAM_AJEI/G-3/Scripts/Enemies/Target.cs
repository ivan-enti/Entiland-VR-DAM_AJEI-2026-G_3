using DG.Tweening;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected float health = 5f;
        protected bool frost = false;

        private PlayerWeapons w;
        public abstract void TakeDamage(float damage);
        public abstract void FrezeEffect(float time);

        public virtual void Die()
        {
            GameController.Instance.EnemyEliminated();
            gameObject.SetActive(false);
            w.UpdateKillCount();
        }

    }
}
