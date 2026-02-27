using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private int killCount = 0;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();
    private int killsToSpawn = 5;
    private int currentWeaponIndex = 0;

    public void UpdateKillCount()
    {
        killCount++;

        if (killCount % killsToSpawn == 0)
        {
            SpawnWeapon();
        }
    }
    private void SpawnWeapon()
    {
        if (weapons.Count == 0) return;

        if (currentWeaponIndex >= weapons.Count)
        {
            Debug.Log("No quedan más armas en la lista");
            return;
        }

        Instantiate(weapons[currentWeaponIndex],
                    spawnPoint.position,
                    spawnPoint.rotation);

        currentWeaponIndex++;
    }
}
