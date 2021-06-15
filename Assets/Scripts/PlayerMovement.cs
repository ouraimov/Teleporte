using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed =3.0f;
        private Rigidbody2D rigidbody2D;
        private CircleCollider2D collider;
        private Material material;

        private Vector2 direction;
        private bool teleport;
        private bool teleportedLastFrame;
        private float TELEPORT_DISTANCE = 3.0f;
        private float teleportDistanceMax = 3.0f;

        private float teleportCooldown = 3.0f;
        private float dissolveAmount = 0.0f;
        private float startDissolve = 0.0f;
        private float endDissolve = 1.0f;
        

        private Vector3 START_POS;

        private Animator animator;

        public int lives;

        [SerializeField]
        private AudioSource teleportSource;

        private bool CanTeleport()
        {
            Vector2 location = transform.position + (new Vector3(direction.normalized.x, direction.normalized.y, 0.0f) * TELEPORT_DISTANCE);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, TELEPORT_DISTANCE, LayerMask.GetMask("No Teleport")); Debug.DrawRay(transform.position, (direction.normalized * TELEPORT_DISTANCE), Color.green, 5.0f);
            Debug.DrawRay(transform.position, (direction.normalized * TELEPORT_DISTANCE), Color.green, 5.0f);

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

            START_POS = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            lives = 5;
        }

        // Update is called once per frame
        void Update()
        {

            if(GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }

            TakeInput();
        
            if(teleport && !teleportedLastFrame && (TELEPORT_DISTANCE >= 1f) && CanTeleport())
            {
                dissolveAmount = 1.00f;
                MoveTeleport();
                teleport = false;
                teleportCooldown = 0f;
                TELEPORT_DISTANCE = 0f;
            }
            else
            {
                Move();
            }

            material.SetFloat("Vector1_D926CC99", Mathf.Lerp(dissolveAmount, 0.0f, teleportCooldown));
            teleportedLastFrame = teleport;
            teleportCooldown += Time.deltaTime;
            if (TELEPORT_DISTANCE < teleportDistanceMax)
            {
                TELEPORT_DISTANCE += Time.deltaTime;
                if (TELEPORT_DISTANCE > teleportDistanceMax)
                {
                    TELEPORT_DISTANCE = teleportDistanceMax;
                }
            }
            
        }

        public void Restart()
        {
            lives--;
            if(lives > 0)
            {
                dissolveAmount = 1.00f;
                transform.position = START_POS;
                teleportSource.Play();
                teleportCooldown = 0.0f;
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }

        private void Move()
        {
            transform.Translate(direction * speed * Time.deltaTime);
            
        }

        private void MoveTeleport()
        {
            transform.Translate(direction.normalized * TELEPORT_DISTANCE);
            teleportSource.Play();
        }

        private void TakeInput()
        {
            direction = Vector2.zero;

            if(Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }
            if(Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }
            if(Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }
            if(Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }

            teleport = Input.GetKey(KeyCode.Space);
        }
        

    }
}
