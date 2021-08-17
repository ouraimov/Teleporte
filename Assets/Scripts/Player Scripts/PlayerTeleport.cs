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
        private float teleportDistance = 3.0f;
        private float teleportCooldown = 3.0f;
        private float cooldownTime = 2f;
        private float dissolveAmount = 0.0f;
        private Vector2 direction;
        private Material material;

        
        private Animator animator;
        [SerializeField]
        private AudioSource teleportSource;
        [SerializeField]
        private PlayerMovement playerMovement;

        // Start is called before the first frame update
        void Start()
        {
            material = GetComponent<Renderer>().sharedMaterial;
            animator = transform.GetChild(1).GetComponent<Animator>();

            teleport = false;
            teleportedLastFrame = false;

            animator.speed = 2f / cooldownTime;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 d = playerMovement.GetDirection();
            if (d.magnitude > 0)
            {
                direction = d;
            }
             
            teleport = Input.GetKeyUp(KeyCode.Space);

            if (teleport && !teleportedLastFrame && (teleportCooldown >= cooldownTime) && CanTeleport())
            {
                dissolveAmount = 1.00f;
                MoveTeleport();
                teleport = false;
                teleportCooldown = 0f;
                Animate();
            }

            material.SetFloat("Vector1_D926CC99", Mathf.Lerp(dissolveAmount, 0.0f, teleportCooldown));
            teleportedLastFrame = teleport;
            teleportCooldown += Time.deltaTime;
        }

        public bool CanTeleport()
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

        private void MoveTeleport()
        {
            transform.Translate(direction.normalized * teleportDistance);
            teleportSource.Play();
        }

        private void Animate()
        {
            animator.SetTrigger("StartCooldown");
        }

        public void SetCooldownTime(float t)
        {
            cooldownTime = t;
            animator.speed = 2f / t;
        }
        public void SetTeleportDistance(float t)
        {
            teleportDistance = t;
        }
        public float GetDistance()
        {
            return teleportDistance;
        }
        public Vector2 GetDirection()
        {
            return direction;
        }

        public void Restart()
        {
            dissolveAmount = 1.00f;
            teleportSource.Play();
            teleportCooldown = 0.0f;
            Animate();
        }

    }
}
