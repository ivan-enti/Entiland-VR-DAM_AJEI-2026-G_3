using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string enemy_tag = "Enemy";
    [SerializeField] protected float damage;
    [SerializeField] protected float attack_rate;
    
}
