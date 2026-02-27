using EntilandVR.DosCinco.DAM_AJEI.G_Tres;
using UnityEngine;

public class Basic_axe : Weapon
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != enemy_tag) { return; }

        if(other.TryGetComponent<Target>(out Target target))
        {

        }
    }
}
