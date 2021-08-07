using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelGameMenu : MonoBehaviour
    {

        public void PlayAgain()
        {
            GameManager.instance.deathUI.SetActive(false);
            GameManager.instance.completeUI.SetActive(false);
            SceneManager.LoadScene("Tutorial");
        }
        public void Continue()
        {
            GameManager.instance.deathUI.SetActive(false);
            GameManager.instance.completeUI.SetActive(false);
            SceneManager.LoadScene("Omar's Testing Ground");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}