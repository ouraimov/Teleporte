using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This script moves the wizard along the path object
    * 
    */
    public class WizardPathing : MonoBehaviour
    {
        [SerializeField]
        private Transform[] waypoints;
        [SerializeField]
        private float speed = 2.0f;
        [SerializeField]
        private AudioSource teleportSource;

        private Transform player;
        private int waypointIndex = 0;

        private float dissolveAmount = 0.0f;
        private float teleportCooldown = 3.0f;
        private Material material;

        // Start is called before the first frame update
        void Start()
        {
            material = GetComponent<Renderer>().sharedMaterial;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            //
            if (waypointIndex <= waypoints.Length - 1)
            {
                // Move Wizard from current waypoint to the next one
                transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
                // When Wizard arrives at next waypoint
                if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) < .001f)
                {
                    //Waypoints where wizard waits for player
                    if ((waypointIndex == 8 && player.position.x < 9.24) || (waypointIndex == 10 && player.position.x < 14.2) || (waypointIndex == 6 && player.position.x < 3.8))
                    {
                        return;
                    }
                    //Waypoints where wizard teleports
                    if (waypointIndex == 6 || waypointIndex == 10 || waypointIndex == 13)
                    {
                        waypointIndex += 1;
                        transform.position = waypoints[waypointIndex].transform.position;
                        teleportSource.Play();
                        dissolveAmount = 1.00f;
                        teleportCooldown = 0f;
                    }
                    waypointIndex += 1;
                }
            }
            else
            {
                GameObject bubble = transform.GetChild(1).gameObject;
                bubble.SetActive(false);
            }
            material.SetFloat("Vector1_D926CC99", Mathf.Lerp(dissolveAmount, 0.0f, teleportCooldown));
            teleportCooldown += Time.deltaTime;

        }
    }
}