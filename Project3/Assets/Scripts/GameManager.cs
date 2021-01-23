using UnityEngine;
using System.Collections;

    using System.Collections.Generic;        //Allows us to use Lists.
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        public float levelStartDelay = 2f;
        public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
        private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.
        private string level = "lake";                                    //Current level number, expressed in game as "Day 1".
        private Text LevelText;
        private GameObject LevelImage;
        private bool doingSetup;

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

            //Get a component reference to the attached BoardManager script
            boardScript = GetComponent<BoardManager>();


            //Call the InitGame function to initialize the first level
            InitGame();
        }

        private void  OnLevelWasLoaded(int index){

            InitGame();
        }

        //Initializes the game for each level.
        void InitGame()
        {
        /*
            doingSetup= true;
            LevelImage = GameObject.Find("LevelImage");
            LevelText = GameObject.Find("Text").GetComponent<Text>();
            LevelText.text = level;
            LevelImage.SetActive(true);
            Invoke("HideLevelImage", levelStartDelay);
          */
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            boardScript.SetupScene(level);

        }

        private void HideLevelImage(){
            LevelImage.SetActive(false);

        }

        //Update is called every frame.
        void Update()
        {

        }
    }