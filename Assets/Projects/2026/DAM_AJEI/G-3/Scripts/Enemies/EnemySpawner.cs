using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    [Serializable]
    public struct Target_Pool_Type
    {
        public TargetPool pool;
        [Range(0, 100)] public int probability;
    }
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private float distance;
        [SerializeField] private float spawn_cooldown = 5f;
        [SerializeField] private int max_enemies = 5;
        [Header("Pools")]
        [SerializeField] private List<Target_Pool_Type> pool_list = new List<Target_Pool_Type>();

        private int max_percent = 0;

        private bool cooldown_finish = true;

        private int current_enemies = 0;
        void Start()
        {
            foreach(Target_Pool_Type pool_type in pool_list)
            {
                max_percent += pool_type.probability;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (cooldown_finish && current_enemies <= max_enemies)
            {
                StartCoroutine(Corutine_SpawnEnemy(spawn_cooldown));
            }
        }
        public void SpawnEnemy()
        {
            float rand_x = UnityEngine.Random.Range(-1f, 1f);
            float rand_z = UnityEngine.Random.Range(-1f, 1f);

            Vector3 rand_dir = new Vector3(rand_x, 0, rand_z).normalized;

            Vector3 rand_pos = GameController.Instance.t_player.position + rand_dir * distance;
            rand_pos.y = transform.position.y;

            ActivateEnemy(rand_pos);
        }
        public void ActivateEnemy(Vector3 pos)
        {
            int random_percent = UnityEngine.Random.Range(0, max_percent);

            TargetPool pool_to_use = null;
            int temp = 0;
            foreach (Target_Pool_Type pool_type in pool_list)
            {
                temp += pool_type.probability;
                if(random_percent <= temp)
                {
                    pool_to_use = pool_type.pool;
                }
            }

            GameObject target = pool_to_use.GetObj();
            target.transform.position = pos;

            current_enemies++;
        }

        IEnumerator Corutine_SpawnEnemy(float cooldown)
        {
            cooldown_finish = false;
            yield return new WaitForSeconds(cooldown);
            SpawnEnemy();
            cooldown_finish = true;
        }

        public void EnemyEliminated()
        {
            current_enemies--;
        }
    }
}
