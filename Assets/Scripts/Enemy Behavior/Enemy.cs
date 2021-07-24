using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This is the base enemy script
    * 
    */

    public class Enemy : MonoBehaviour
    {
        private Vector3 startPos;
        private Rigidbody2D rigidBody;
        public bool isKillable = false;

        protected virtual void Start()
        {
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.AddEnemyToList(this);
        }

        public virtual void Restart()
        {
            transform.position = startPos;
        }

        public virtual void Kill()
        {
            gameObject.SetActive(false);
        }

    }
}
