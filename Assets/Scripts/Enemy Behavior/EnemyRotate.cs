using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This script handles enemies that rotate in place to look at the player
    * 
    */
    public class EnemyRotate : MonoBehaviour
    {
        private Transform player;
        private Rigidbody2D rigidBody;
        private Vector2 playerPos;
        private float startRot;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;

            startRot = rigidBody.rotation;
        }

        // Update is called once per frame
        void Update()
        {
            playerPos = player.position;
        }

        void FixedUpdate()
        {
            Vector2 lookDir = playerPos - rigidBody.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            rigidBody.rotation = angle + startRot;
        }

    }
}
