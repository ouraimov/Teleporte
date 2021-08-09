using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public int lives = 5;
        public GameObject[] hearts;
        public Vector3 startPos;

        // Start is called before the first frame update
        void Start()
        {
            startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            SetLives(lives);
        }
        public void SetLives(int l)
        {
            
            lives = l;
            print(lives);
            foreach (GameObject heart in hearts)
            {
                heart.SetActive(false);
            }
            for (int i = 0; i < lives; i++)
            {
                hearts[i].SetActive(true);
            }
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
            hearts[lives-1].SetActive(false);
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

        public void GainLife()
        {
            lives++;
            hearts[lives - 1].SetActive(true);
        }
    }
}

