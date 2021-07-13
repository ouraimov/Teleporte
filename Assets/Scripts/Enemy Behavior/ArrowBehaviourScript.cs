using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ArrowBehaviourScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            if (collision.transform.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Restart();
            }
            else if (collision.gameObject.GetComponent<OrcAI>() != null)
            {
                collision.gameObject.GetComponent<OrcAI>().Deletus();
            }
            Destroy(gameObject);
        }
    }
}
