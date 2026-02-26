using UnityEngine;
using System.Collections.Generic;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class ObjPool : MonoBehaviour
    {
        [SerializeField] private GameObject obj_to_pool;
        [SerializeField] private int pool_num;

        private List<GameObject> pool = new List<GameObject>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            for(int i = 0; i < pool_num; i++)
            {
                GameObject obj = Instantiate(obj_to_pool);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        public GameObject GetObj()
        {
            GameObject get_obj = null;

            foreach (GameObject obj in pool)
            {
                if (!obj.activeSelf)
                {
                    get_obj = obj;
                    break;
                }
            }

            if(get_obj == null)
            {
                get_obj = Instantiate(pool[0], pool[0].transform);
            }

            get_obj.SetActive(true);
            return get_obj;
        }
    }
}
