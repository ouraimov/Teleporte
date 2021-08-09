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
            GameManager.instance.levelUI.SetActive(false);
            SceneManager.LoadScene("Tutorial");
        }
        public void Continue()
        {
            GameManager.instance.NextLevel();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
