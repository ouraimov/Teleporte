using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Shield : MonoBehaviour
    {

        private SpriteRenderer spriteRenderer;
        private float visibility = 0.5f;
        private float visibilityMax = 0.5f;
        private float visibilitySpeed = -0.01f;
        private bool blink = false;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            spriteRenderer.color = new Color(1f, 1f, 1f, visibility);
        }

        // Update is called once per frame
        void Update()
        {
            if (blink)
            {
                visibility += visibilitySpeed;
                spriteRenderer.color = new Color(1f, 1f, 1f, visibility); 
                if (visibility > visibilityMax || visibility <= 0f)
                {
                    visibilitySpeed = -visibilitySpeed;
                }
            }

        }
        public void On()
        {
            spriteRenderer.enabled = true;
        }
        public void Blink()
        {
            blink = true;
        }
        public void Off()
        {
            spriteRenderer.enabled = false;
            blink = false;
        }
    }
}
