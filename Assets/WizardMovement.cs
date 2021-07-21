using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WizardMovement : MonoBehaviour, IEnemyAI
    {
        //[SerializeField]

        private float speed = 2.0f;
        private Vector3 pos1 = new Vector3(0,0,0);
        private Vector3 pos2 = new Vector3(0, 0, 0);


        private Rigidbody2D rb;
        private Transform player;
        private Vector2 direction;


        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            // pos1 = transform.position;
            GameManager.instance.AddEnemyToList(this);
            rb = GetComponent<Rigidbody2D>();
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
            if (dist <= 6)
            {
                direction = new Vector2((player.position.x - transform.position.x) / dist, (player.position.y - transform.position.y) / dist);
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
            transform.position = pos1;
        }
    }
}
