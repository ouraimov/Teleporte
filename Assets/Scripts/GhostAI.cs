using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GhostAI : MonoBehaviour, IEnemyAI
    {
        public float speed = 2.0f;
        public float awareness = 8.0f;
        public Rigidbody2D rb;

        public Transform player;
        public Vector3 startPos;
        private Vector2 direction;


        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.AddEnemyToList(this);
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }
            float dist = (player.position - transform.position).magnitude;
            if (dist <= 0.5)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            }
            if(dist <= awareness)
            {
                direction = new Vector2((player.position.x - transform.position.x) / dist , (player.position.y - transform.position.y) /dist);
            }
            else
            {
                direction = new Vector2(0f, 0f);
            }
        }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            if (collision.transform.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            }
        }

        public void Restart()
        {
            transform.position = startPos;
        }
    }
}
