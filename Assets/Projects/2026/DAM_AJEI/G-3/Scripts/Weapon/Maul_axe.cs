using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class Maul_axe : MonoBehaviour
    {
        [Header("Orbit")]
        public Transform player;
        public float radius = 1.5f;
        public float duration = 1.5f;
        public float height = 1.2f;

        private Rigidbody rb;
        private bool isOrbiting = false;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            var grab = GetComponent<XRGrabInteractable>();
            if (grab != null)
            {
                grab.selectExited.AddListener(OnReleased);
            }
        }

        private void OnReleased(SelectExitEventArgs args)
        {
            if (!isOrbiting)
            {
                StartCoroutine(OrbitRoutine());
            }
        }

        IEnumerator OrbitRoutine()
        {
            isOrbiting = true;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;

            float time = 0f;

            while (time < duration)
            {
                float t = time / duration;
                float angle = t * 2f * Mathf.PI;

                Vector3 offset = new Vector3(
                    Mathf.Cos(angle) * radius,
                    height,
                    Mathf.Sin(angle) * radius
                );

                transform.position = player.position + offset;

                time += Time.deltaTime;
                yield return null;
            }

            EndOrbit();
        }

        void EndOrbit()
        {
            isOrbiting = false;

            GameController.Instance.weapons.ResetKillsAndChangeWeapon();

            Destroy(gameObject);
        }
    }
}