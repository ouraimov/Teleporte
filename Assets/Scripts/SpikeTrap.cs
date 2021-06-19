using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SpikeTrap : MonoBehaviour
    {
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
            } else
            {
                collision.gameObject.GetComponent<OrcAI>().Deletus();
            }
        }

    }
}
