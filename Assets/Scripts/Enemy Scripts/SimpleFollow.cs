using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    /*
    * Description: This script handles enemies that follow the player without navmesh
    * 
    */
    public class SimpleFollow : MonoBehaviour
    {
        [SerializeField]
        private float awareness = 8.0f;
        [SerializeField]
        public float speed = 2.0f;

        private Vector2 direction;
        private Transform player;
        private Rigidbody2D rigidBody;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float dist = (player.position - transform.position).magnitude;
            if (dist <= awareness)
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
            rigidBody.MovePosition(rigidBody.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
