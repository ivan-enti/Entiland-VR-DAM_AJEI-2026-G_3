using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public Transform t_player;
        public EnemySpawner spawner;
        public PlayerWeapons weapons;
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
        }
        public void EnemyEliminated()
        {
            spawner.EnemyEliminated();
        }
        public void Die()
        {

        }
    }
}
