using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This script kills the player when they are near by
    * 
    */

    public class KillOnProximity : MonoBehaviour
    {
        [SerializeField]
        private bool isConsumed = false;
        [SerializeField]
        private float proximity = 0.5f;

        public Transform player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            float dist = (player.position - transform.position).magnitude;
            if (dist <= proximity)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Restart();
                if (isConsumed)
                {
                    Destroy(gameObject);
                }

            }
        }
    }
}
