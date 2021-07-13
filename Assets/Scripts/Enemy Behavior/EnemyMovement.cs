using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: The script handles enemy movement and follow behavior
    * 
    */
    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;
        public Vector3 startPos;
        public Rigidbody2D rigidBody;
        public float awareness = 8.0f;
        private UnityEngine.AI.NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.destination = transform.position;

            player = GameObject.FindGameObjectWithTag("Player").transform;
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // GameManager.instance.AddEnemyToList(this);
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float dist = (player.position - transform.position).magnitude;
            if (dist <= awareness)
            {
                agent.destination = player.position;
            }
            else
            {
                agent.destination = transform.position;
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            if (collision.transform.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            }
        }
    }
}
