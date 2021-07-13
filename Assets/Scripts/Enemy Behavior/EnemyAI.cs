using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform player;
        public Vector3 startPos;
        public Rigidbody2D rigidBody;

        protected virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.AddEnemyToList(this);
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        public virtual void Restart()
        {

        }
    }
}
