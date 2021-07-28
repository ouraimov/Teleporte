using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GhostMovement : MonoBehaviour
    {
        public float speed = 2.0f;
        public float awareness = 8.0f;
        private Vector2 direction;
        public Transform player;
        public Rigidbody2D rigidBody;

        // Start is called before the first frame update
        protected void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Restart();
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
            // rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
