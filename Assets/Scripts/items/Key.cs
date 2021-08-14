using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Key : MonoBehaviour
    {
        [SerializeField]
        private GameObject door;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.transform.tag);
            if (collision.transform.tag == "Player")
            {
                OpenDoor();
            }
        }
        public void OpenDoor()
        {
            door.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
