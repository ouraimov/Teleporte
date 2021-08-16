using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class BreakFloor : MonoBehaviour
    {
        [SerializeField]
        private float breakTime = 10f;
        [SerializeField]
        private float proximity = 0.5f;
        [SerializeField]
        private Sprite[] sprites;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D collider;
        private Transform player;
        private bool kill = false;

        private float currentTime = 0f;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            collider = gameObject.GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            float dist = (player.position - transform.position).magnitude;
            if (dist <= proximity || currentTime > 0)
            {
                BreakAway();
            }
        }

        public void BreakAway()
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime > breakTime)
            {
                spriteRenderer.sprite = sprites[2];
                collider.enabled = true;
                kill = true;
            }
            else if (currentTime > breakTime * 2 / 3)
            {
                spriteRenderer.sprite = sprites[1];
            }
            else if (currentTime > breakTime / 3)
            {
                spriteRenderer.sprite = sprites[0];
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (kill)
            {
                Debug.Log(collision.transform.tag);
                if (collision.transform.tag == "Player")
                {
                    GameManager.instance.KillPlayer();
                }
            }
        }

    }
}
