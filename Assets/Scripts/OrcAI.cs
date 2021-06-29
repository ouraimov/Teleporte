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
        private bool dead;
        private Renderer rend;
        private BoxCollider2D col;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            player = GameObject.FindGameObjectWithTag("Player").transform;

            agent.destination = transform.position;
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.AddEnemyToList(this);
            dead = false;
            rend = GetComponent<Renderer>();
            col = GetComponent<BoxCollider2D>();
        }

        void Update()
        {

            if(GameManager.instance.GameIsOver() || !GameManager.instance.GameMove() || dead)
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
            if (collision.transform.tag == "Player" )
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            }
        }

        public void Restart()
        {
            transform.position = startPos;
            dead = false;
            rend.enabled = true;
            col.enabled = true;
        }

        public void Deletus()
        {
            dead = true;
            agent.destination = transform.position;
            rend.enabled = false;
            col.enabled = false;
            print("yup");
        }
    }
}
