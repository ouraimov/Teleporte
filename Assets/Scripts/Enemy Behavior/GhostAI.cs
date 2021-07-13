using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GhostAI : EnemyAI
    {
        public float speed = 2.0f;
        public float awareness = 8.0f;
        private Vector2 direction;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
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
            // rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }

        public override void Restart()
        {
            transform.position = startPos;
        }
    }
}
