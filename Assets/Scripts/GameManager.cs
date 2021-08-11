using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

using System.Collections.Generic;		//Allows us to use Lists. 
using UnityEngine.UI;					//Allows us to use UI.
	
namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

        [SerializeField]
        private List<Enemy> enemies;                          //List of all Enemy units, used to issue them move commands.
        //private bool enemiesMoving;						    //Boolean to check if enemies are moving.
        private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.

        private GameObject playerObj;
        public GameObject canvas;
        public GameObject completeUI;
        public GameObject levelUI;
        public GameObject deathUI;
        [SerializeField]
        private GameObject[] hearts;
        private int lives = 5;

        private bool gameMove;

        private int scene = 1;

        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);

            //Assign enemies to a new List of Enemy objects.
            enemies = new List<Enemy>();

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        //Initializes the game for each level.
        void InitGame()
        {
            //While doingSetup is true the player can't move, prevent player from moving while title card is up.
            doingSetup = true;

            //Clear any Enemy objects in our List to prepare for next level.
            enemies.Clear();
            SetHearts();

            gameMove = true;
            

        }

        //Update is called every frame.
        void Update()
        {


            //Check that playersTurn or enemiesMoving or doingSetup are not currently true.
            //if(playersTurn || enemiesMoving || doingSetup)
            if (doingSetup)

                //If any of these are true, return and do not start MoveEnemies.
                return;

            
        }

        public void KillPlayer()
        {
            RestartEnemies();
            lives -= 1;
            SetHearts();
            playerObj.GetComponent<PlayerTeleport>().Restart();
        }

        public void SetHearts()
        {
            foreach (GameObject heart in hearts)
            {
                heart.SetActive(false);
            }
            for (int i = 0; i < lives; i++)
            {
                hearts[i].SetActive(true);
            }
        }
        public void GainLife()
        {
            lives += 1;
            SetHearts();
        }

        //Call this to add the passed in Enemy to the List of Enemy objects.
        public void AddEnemyToList(Enemy script)
        {
            //Add Enemy to List enemies.
            enemies.Add(script);
        }
        public void RestartEnemies()
        {
            foreach (Enemy i in enemies)
            {
                i.Restart();
            }
        }


        //GameOver is called when the player reaches 0 food points
        public void GameOver()
        {
            gameMove = false;
            deathUI.SetActive(true);
        }

        public void GameWin()
        {
            gameMove = false;
            completeUI.SetActive(true);
        }
        public void LevelWinUI()
        {
            gameMove = false;
            levelUI.SetActive(true);
        }
        public void NextLevel()
        {
            deathUI.SetActive(false);
            completeUI.SetActive(false);
            levelUI.SetActive(false);
            enemies.Clear();
            SceneManager.LoadSceneAsync("Omar's Testing Ground");
        }
        //allows the player object to assign itself to the manager on scene chaneg
        public void SetPlayer(GameObject player)
        {
            playerObj = player;
        }

        public bool GameIsOver()
        {
            return !enabled;
        }

        public bool GameMove()
        {
            return gameMove;
        }

        public void StartGameMove()
        {
            gameMove = true;
        }
    }
}
