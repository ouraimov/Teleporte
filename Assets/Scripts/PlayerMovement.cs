using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 3.0f;
        public int lives = 5;
        public Rigidbody2D rb;
        public Vector3 startPos;

        private Vector2 direction;

        private bool teleport;
        private bool teleportedLastFrame;
        private const float teleportDistance = 3.0f;
        private float teleportCooldown = 3.0f;
        private float dissolveAmount = 0.0f;
        //private float startDissolve = 0.0f;
        //private float endDissolve = 1.0f;

        private Animator animator;
        private Material material;
        
        [SerializeField]
        private AudioSource teleportSource;

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

        // Start is called before the first frame update
        void Start()
        {
            teleport = false;
            teleportedLastFrame = false;

            animator = GetComponent<Animator>();
            material = GetComponent<Renderer>().sharedMaterial;

            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {

            if(GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }

            TakeInput();
        
            if(teleport && !teleportedLastFrame && (teleportCooldown >= 2f) && CanTeleport())
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
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }

        public void Restart()
        {
            lives--;
            if(lives > 0)
            {
                dissolveAmount = 1.00f;
                transform.position = startPos;
                teleportSource.Play();
                teleportCooldown = 0.0f;
                GameManager.instance.RestartEnemies();
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }

        private void MoveTeleport()
        {
            transform.Translate(direction.normalized * teleportDistance);
            teleportSource.Play();
        }

        private void TakeInput()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            teleport = Input.GetKey(KeyCode.Space);
        }
    }
}
