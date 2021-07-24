using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class InGameMenu : MonoBehaviour
    {

        public void PlayAgain()
        {
            GameManager.instance.deathUI.SetActive(false);
            GameManager.instance.completeUI.SetActive(false);
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
