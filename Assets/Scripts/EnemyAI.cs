using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAI : MonoBehaviour
    {
        public float speed = 2.5f;
        public Transform player;
        private Vector2 direction;

        private UnityEngine.AI.NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            player = GameObject.FindGameObjectWithTag("Player").transform;

            agent.destination = transform.position;

            GameManager.instance.AddEnemyToList(this, transform.position);
        }

        void Update()
        {

            if(GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }

            float dist = (player.position - transform.position).magnitude;
            if(dist <= 8f)
            {
                agent.destination = player.position;
            } else
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

        public void Restart(Vector3 pos)
        {
            transform.position = pos;
        }
    }
}
