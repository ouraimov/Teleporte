using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This script handles enemies that follow the player
    * 
    */
    public class EnemyFollow : MonoBehaviour
    {
        [SerializeField]
        private float awareness = 8.0f;

        private Transform player;
        private Rigidbody2D rigidBody;
        private UnityEngine.AI.NavMeshAgent agent;
        private float stunned = 0f;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.destination = transform.position;

            player = GameObject.FindGameObjectWithTag("Player").transform;
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float dist = (player.position - transform.position).magnitude;
            if (stunned >= 0)
            {
                stunned -= Time.deltaTime;
            }
            if (dist <= awareness && stunned <= 0f)
            {
                agent.destination = player.position;
            }
            else
            {
                agent.destination = transform.position;
            }
        }
        public void Stun()
        {
            stunned = 2f;
        }
    }
}
