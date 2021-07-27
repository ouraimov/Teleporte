using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WizardMovement : MonoBehaviour, IEnemyAI
    {
        [SerializeField]
        private Transform[] waypoints;
        public float speed = 2.0f;
        //public Vector3 pos1 = new Vector3(0,0,0);
        //public Vector3 pos2 = new Vector3(0,0,0);
        [SerializeField]
        private AudioSource teleportSource;


        private Rigidbody2D rb;
        private Transform player;
        private Vector2 direction;
        private int waypointIndex = 0;


        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            // pos1 = transform.position;
            GameManager.instance.AddEnemyToList(this);
            rb = GetComponent<Rigidbody2D>();
            transform.position = waypoints[waypointIndex].transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }

            if (waypointIndex <= waypoints.Length - 1)
            {
                // Move Wizard from current waypoint to the next one
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
                // When Wizard arrives at next waypoint
                if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) < .001f)
                {
                    if ((waypointIndex == 8 && player.position.x < 9.24) || (waypointIndex == 10 && player.position.x < 14.2) || (waypointIndex == 6 && player.position.x < 3.8))
                    {
                        return;
                    }
                    if (waypointIndex == 6 || waypointIndex == 10 || waypointIndex == 13)
                    {
                        waypointIndex += 1;
                        transform.position = waypoints[waypointIndex].transform.position;
                        teleportSource.Play();
                        
                    }
                    waypointIndex += 1;
                }
            } else
            {
                GameObject bubble = transform.GetChild(1).gameObject;
                bubble.SetActive(false);
            }
        }

        public void Restart()
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }
}
