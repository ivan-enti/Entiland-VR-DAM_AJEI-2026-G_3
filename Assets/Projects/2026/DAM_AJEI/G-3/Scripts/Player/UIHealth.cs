using UnityEngine;
using UnityEngine.UI;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private CanvasGroup panel;
        [SerializeField] private float max_alpha = 1;

        public void UpdateHealthPanel(float max_health, float current_health)
        {
            float health_percent = current_health / max_health;

            float current_alpha = max_alpha * health_percent;
            panel.alpha = current_alpha;
        }
    }
}