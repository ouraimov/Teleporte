using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class OrcAI : MonoBehaviour, IEnemyAI
    {
        public Transform player;
        private Vector2 direction;
        private UnityEngine.AI.NavMeshAgent agent;
        public Vector3 startPos;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            player = GameObject.FindGameObjectWithTag("Player").transform;

            agent.destination = transform.position;
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.AddEnemyToList(this);
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

        public void Restart()
        {
            transform.position = startPos;
        }

        public void Deletus()
        {
            transform.position = new Vector3(100,100,0);
        }
    }
}