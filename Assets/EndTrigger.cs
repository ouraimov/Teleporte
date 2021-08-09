using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class EndTrigger : MonoBehaviour
    {
        public GameManager gameManager;

        private void OnTriggerEnter2D()
        {
            gameManager.LevelWinUI();
        }
    }
}
