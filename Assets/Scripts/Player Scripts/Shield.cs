using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Shield : MonoBehaviour
    {

        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void On()
        {
            spriteRenderer.enabled = true;
        }
        public void Activate()
        {
            spriteRenderer.enabled = true;
        }
        public void Off()
        {
            spriteRenderer.enabled = false;
        }
    }
}
