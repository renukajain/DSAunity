﻿using UnityEngine;
using System.Collections;

    using System.Collections.Generic;        //Allows us to use Lists.
    using UnityEngine.UI;
    public class GameManager : MonoBehaviour
    {
        private Player player;
        public static Collider2D col;
        public float levelStartDelay = 2f;

        public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
        private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.
        public string level = "campus";                                    //Current level number, expressed in game as "Day 1".
        [HideInInspector] public bool playersTurn = true;

        private Text LevelText;
        private GameObject LevelImage;

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


    void OnLevelWasLoaded()
    {      
        InitGame();
    }
    //Initializes the game for each level.
    void InitGame()
        {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            boardScript.SetupScene(level);

        }



        //Update is called every frame.
        void Update()
        {

        }
    }