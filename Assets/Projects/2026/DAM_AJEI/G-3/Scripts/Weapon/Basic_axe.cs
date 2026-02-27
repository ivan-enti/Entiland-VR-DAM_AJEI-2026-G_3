using EntilandVR.DosCinco.DAM_AJEI.G_Tres;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class Basic_axe : Weapon
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float min_velocity = 2;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != enemy_tag) { return; }

            float rb_velocity = rb.linearVelocity.sqrMagnitude;
            if (other.TryGetComponent<Target>(out Target target) && rb_velocity > min_velocity)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
