using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class WinTrigger : MonoBehaviour
    {
        public GameManager gameManager;

        private void OnTriggerEnter2D()
        {
            gameManager.GameWin();
        }
    }
}
