using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SkeletonAI : MonoBehaviour, IEnemyAI
    {
        public Rigidbody2D rb;
        public Transform player;
        public Vector2 playerPos;
        public float startPos;


        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            GameManager.instance.AddEnemyToList(this);
            rb = gameObject.GetComponent<Rigidbody2D>();
            startPos = rb.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            playerPos = player.position;

        }
        void FixedUpdate()
        {
            Vector2 lookDir = playerPos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            rb.rotation = angle + startPos;
        }

        public void Restart()
        {
            rb.rotation = startPos;
        }
    }
}
