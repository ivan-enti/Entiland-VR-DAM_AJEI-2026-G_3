using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Kills")]
    [SerializeField] private int killCount = 0;
    [SerializeField] private int killsToChangeWeapon = 5;

    [Header("Weapons")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();

    private GameObject currentWeapon;
    private int lastWeaponIndex = -1;
    public void RegisterKill()
    {
        killCount++;

        if (killCount % killsToChangeWeapon == 0)
        {
            ChangeWeapon();
        }
    }
    public void ResetKillsAndChangeWeapon()
    {
        killCount = 0;

        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        if (weapons.Count == 0) return;

        int newIndex;

        do
        {
            newIndex = Random.Range(0, weapons.Count);
        }
        while (weapons.Count > 1 && newIndex == lastWeaponIndex);

        lastWeaponIndex = newIndex;

        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(
            weapons[newIndex],
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}
