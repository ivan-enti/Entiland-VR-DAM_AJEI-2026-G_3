using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    [Serializable]
    public struct Target_Pool_Type
    {
        public ObjPool pool;
        [Range(0, 100)] public int probability;
    }
    public class TargetPoolController : MonoBehaviour
    {
        [SerializeField] private List<Target_Pool_Type> pool_list = new List<Target_Pool_Type>();

        private int max_percent = 0;
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

        }
        public void ActivateEnemy(Vector3 pos)
        {
            int random_percent = UnityEngine.Random.Range(0, max_percent);

            ObjPool pool_to_use = null;
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
        }
    }
}
