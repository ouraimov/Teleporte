using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Jiggle))]
    public class Chest : MonoBehaviour
    {
        [SerializeField]
        private bool life = true;
        [SerializeField]
        private bool summon = false;
        [SerializeField]
        private GameObject summonPrefab;

        [SerializeField]
        private float awareness = 2.0f;
        [SerializeField]
        private float time = 50.0f;
        [SerializeField]
        private float startingSpeed = 0.2f;
        [SerializeField]
        private float endingSpeed = 0.6f;
        [SerializeField]
        private Jiggle jiggle;
        [SerializeField]
        private Sprite openSprite; 
        private SpriteRenderer spriteRenderer;

        private bool closed = true;
        private float jiggleSpeed;
        private Transform player;
        private Rigidbody2D rigidBody;
        

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            jiggleSpeed = startingSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (closed)
            {
                jiggleControl();
            }
            
        }

        public void jiggleControl()
        {
            float dist = (player.position - transform.position).magnitude;
            if (dist <= awareness)
            {
                jiggle.setSpeed(jiggleSpeed);
                jiggle.setJiggle(true);
                jiggleSpeed += Time.fixedDeltaTime / (time*10);

                if (jiggleSpeed > endingSpeed)
                {
                    Open();
                }

            }
            else
            {
                if (jiggleSpeed > startingSpeed)
                {
                    jiggleSpeed -= Time.fixedDeltaTime / (time * 10);
                    jiggle.setSpeed(jiggleSpeed);
                } 
                else
                {
                    jiggle.setJiggle(false);
                    jiggle.Restart();
                }

            }
        }

        public void Open()
        {
            closed = false;
            jiggle.setJiggle(false);
            jiggle.Restart();
            Activate();
            spriteRenderer.sprite = openSprite;
        }
        public void Activate()
        {
            if (life)
            {
                GameManager.instance.IncreaseLife();
                GameManager.instance.Invincible();
            }
            if (summon)
            {
                Instantiate(summonPrefab, transform.position, Quaternion.identity);
            }
            
        }
    }
}
