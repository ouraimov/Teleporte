using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 3.0f;
        public Rigidbody2D rb;
        private Vector2 direction;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TakeInput();
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }

        private void TakeInput()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
        }

        public Vector2 GetDirection()
        {
            return direction;
        }
    }
}
