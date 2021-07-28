using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public int lives = 5;
        public Vector3 startPos;

        // Start is called before the first frame update
        void Start()
        {
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.GameIsOver() || !GameManager.instance.GameMove())
            {
                return;
            }
        }

        public void Restart()
        {
            lives--;
            if (lives > 0)
            {
                transform.position = startPos;
                gameObject.GetComponent<PlayerTeleport>().Restart();
                GameManager.instance.RestartEnemies();
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }
    }
}

