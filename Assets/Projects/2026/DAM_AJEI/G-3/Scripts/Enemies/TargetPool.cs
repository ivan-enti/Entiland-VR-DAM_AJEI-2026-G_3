using UnityEngine;
using System.Collections.Generic;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class TargetPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> obj_to_pool = new List<GameObject>();
        [SerializeField] private int pool_num;

        private List<Target> pool = new List<Target>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            for(int i = 0; i < pool_num; i++)
            {
                GameObject obj = InstantiateRandomEnemy();
                obj.SetActive(false);
                pool.Add(obj.GetComponent<Target>());
            }
        }

        public GameObject GetObj(EnemySpawner spawner = null)
        {
            GameObject get_obj = null;

            foreach (Target target in pool)
            {
                if (!target.gameObject.activeSelf)
                {
                    get_obj = target.gameObject;
                    break;
                }
            }

            if(get_obj == null)
            {
                get_obj = InstantiateRandomEnemy();
                pool.Add(get_obj.GetComponent<Target>());
            }

            get_obj.SetActive(true);
            return get_obj;
        }

        public GameObject InstantiateRandomEnemy()
        {
            int rand = Random.Range(0, obj_to_pool.Count - 1);

            return obj_to_pool[rand];
        }
    }
}
