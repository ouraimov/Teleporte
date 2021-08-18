using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Jiggle))]
    public class Chest : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] locations;
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
            chooseLocation();
        }
        private void chooseLocation()
        {
            List<Vector3> positions = new List<Vector3>();
            positions.Add(transform.position);
            foreach (GameObject i in locations)
            {
                positions.Add(i.transform.position);
                i.SetActive(false);
            }
            transform.position = positions[Random.Range(0, positions.Count)];
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
            spriteRenderer.sprite = openSprite;
            Activate();
        }
        public void Activate()
        {
            int r = Random.Range(0, 5);
            switch (r)
            {
                case 0:
                    GameManager.instance.IncreaseLife();
                    break;

                case 1:
                    GameManager.instance.Invincible();
                    break;

                case 2:
                    player.GetComponent<PlayerTeleport>().DecreaseCooldownTime();
                    break;

                case 3:
                    player.GetComponent<PlayerTeleport>().IncreaseTeleportDistance();
                    break;

                case 4:
                    GameObject orc = Instantiate(summonPrefab, transform.position, Quaternion.identity);
                    orc.GetComponent<EnemyFollow>().Stun();
                    break;
            }
        }
    }
}
