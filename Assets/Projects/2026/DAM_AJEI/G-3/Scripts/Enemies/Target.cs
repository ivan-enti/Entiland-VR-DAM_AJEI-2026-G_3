using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected float health = 5f;
        public abstract void ReciveDamage(float damage);

        public abstract void Die();


    }
}
