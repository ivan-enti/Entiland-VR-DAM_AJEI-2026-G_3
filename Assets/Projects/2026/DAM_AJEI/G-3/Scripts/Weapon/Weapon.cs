using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    [RequireComponent(typeof(Collider))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected string enemy_tag = "Enemy";
        [SerializeField] protected float damage;
        [SerializeField] protected float attack_rate;

    }
}
