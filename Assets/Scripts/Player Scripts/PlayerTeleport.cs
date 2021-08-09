using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerTeleport : MonoBehaviour
    {

        private bool teleport;
        private bool teleportedLastFrame;
        private const float teleportDistance = 3.0f;
        private float teleportCooldown = 3.0f;
        private float dissolveAmount = 0.0f;
        private Vector2 direction;
        private Material material;

        [SerializeField]
        private AudioSource teleportSource;
        [SerializeField]
        private PlayerMovement playerMovement;

        // Start is called before the first frame update
        void Start()
        {
            material = GetComponent<Renderer>().sharedMaterial;

            teleport = false;
            teleportedLastFrame = false;
        }

        // Update is called once per frame
        void Update()
        {
            direction = playerMovement.GetDirection();
            teleport = Input.GetKey(KeyCode.Space);

            if (teleport && !teleportedLastFrame && (teleportCooldown >= 2f) && CanTeleport())
            {
                dissolveAmount = 1.00f;
                MoveTeleport();
                teleport = false;
                teleportCooldown = 0f;
            }

            material.SetFloat("Vector1_D926CC99", Mathf.Lerp(dissolveAmount, 0.0f, teleportCooldown));
            teleportedLastFrame = teleport;
            teleportCooldown += Time.deltaTime;
        }

        private bool CanTeleport()
        {
            Vector2 location = transform.position + (new Vector3(direction.normalized.x, direction.normalized.y, 0.0f) * teleportDistance);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, teleportDistance, LayerMask.GetMask("No Teleport")); Debug.DrawRay(transform.position, (direction.normalized * teleportDistance), Color.green, 5.0f);
            Debug.DrawRay(transform.position, (direction.normalized * teleportDistance), Color.green, 5.0f);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                return false;
            }

            return true;
        }
        public bool TeleportReady()
        {
            if (teleportCooldown >= 2f)
            {
                return true;
            }
            return false;
        }

        private void MoveTeleport()
        {
            transform.Translate(direction.normalized * teleportDistance);
            teleportSource.Play();
        }

        public void Restart()
        {
            dissolveAmount = 1.00f;
            teleportSource.Play();
            teleportCooldown = 0.0f;
        }

    }
}
