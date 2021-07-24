using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /*
    * Description: This script kills the player or a killable enemy that touches the base object
    * 
    */

    public class KillOnContact : MonoBehaviour
    {
        [SerializeField]
        private bool isConsumed = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            if (collision.transform.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            } 
            else if(collision.transform.tag == "Enemy")
            {
                Enemy enemy = collision.transform.gameObject.GetComponent<Enemy>();
                if (enemy.isKillable)
                {
                    collision.transform.gameObject.GetComponent<Enemy>().Restart();
                }
            }
            if (isConsumed)
            {
                Destroy(gameObject);
            }
        }

    }
}
