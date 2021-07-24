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
        public static Transform player = null;

        private List<Enemy> enemies;                          //List of all Enemy units, used to issue them move commands.
        //private bool enemiesMoving;						    //Boolean to check if enemies are moving.
        private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.

        private GameObject playerObj;
        public GameObject completeUI;
        public GameObject deathUI;

        private bool gameMove;

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
            DontDestroyOnLoad(completeUI);
            DontDestroyOnLoad(deathUI);

            //Assign enemies to a new List of Enemy objects.
            enemies = new List<Enemy>();

            playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.transform;

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
