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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            Enemy enemy = collision.transform.gameObject.GetComponent<Enemy>();
            Enemy self = this.gameObject.GetComponent<Enemy>();
            if (collision.transform.tag == "Player")
            {
                GameManager.instance.KillPlayer();
            } 
            else if(enemy != null && self == null)
            {
                if (enemy.isKillable)
                {
                    collision.gameObject.GetComponent<Enemy>().Kill();
                }
            }
            if (isConsumed)
            {
                Destroy(gameObject);
            }
        }

    }
}
