using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Jiggle : MonoBehaviour
    {
        [SerializeField]
        private float jiggleDistance = 7.0f;

        private float jiggleSpeed = 2f;
        private Rigidbody2D rigidBody;
        private float jiggleDir = 1;
        private bool jiggle = false;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
            rigidBody.rotation = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (jiggle)
            {
                rigidBody.rotation += jiggleDir * jiggleSpeed;
                if (Mathf.Abs(rigidBody.rotation) > jiggleDistance)
                {
                    jiggleDir = -jiggleDir;
                }

            }
        }
        public void setSpeed(float speed)
        {
            jiggleSpeed = speed;
        }
        public void setJiggle(bool j)
        {
            jiggle = j;
        }
        public void Restart()
        {
            rigidBody.rotation = 0f;
        }
    }
}
