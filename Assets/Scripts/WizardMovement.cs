using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WizardMovement : MonoBehaviour, IEnemyAI
    {
        //[SerializeField]

        public float speed = 2.0f;
        public Vector3 pos1 = new Vector3(0,0,0);
        public Vector3 pos2 = new Vector3(0,0,0);


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

            transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        }
        //void FixedUpdate()
        //{
         //   rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        //}

        public void Restart()
        {
            transform.position = pos1;
        }
    }
}
