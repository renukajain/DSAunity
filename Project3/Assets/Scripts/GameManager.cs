using UnityEngine;
using System.Collections;


    using System.Collections.Generic;        //Allows us to use Lists.
    using UnityEngine.UI;
    public class GameManager : MonoBehaviour
    {
        private Player player;
        public static Collider2D col;
        public float levelStartDelay = 2f;

        public int turtle;
        public int coffee;
        public int redBull;
        public int pills;
        public int calculator;
        public int rule;
        public int compass;
        public int pencil;
        public int glasses;
        public int usb;
        public int book;
        public int puzzle;
        public int cheat;

        public bool cal = false;
        public bool ele = false;
        public bool com = false;
        public bool oes = false;
        public bool dsa = false;
        public bool aero = false;
        public bool tfg = false;


        public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
        private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.
        public string level = "campus";                                    //Current level number, expressed in game as "Day 1".
        [HideInInspector] public bool playersTurn = true;

        private Text LevelText;
        private GameObject Panel;
         public Text Text0;
        public Text Text1;
        public Text Text2;
        public Text Text3;
        public Text Text4;
        public Text Text5;
        public Text Text6;
        public Text Text7;
        public Text Text8;
        public Text Text9;
        public Text Text10;
        public Text Text11;
        public Text Text12;

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
    /*    Panel = GameObject.Find("Panel");
        Text0 = GameObject.Find("Panel").GetComponent<Text>();
        Text1 = GameObject.Find("Panel").GetComponent<Text>();
        Text2 = GameObject.Find("Panel").GetComponent<Text>();
        Text3 = GameObject.Find("Panel").GetComponent<Text>();
        Text4 = GameObject.Find("Panel").GetComponent<Text>();
        Text5 = GameObject.Find("Panel").GetComponent<Text>();
        Text6 = GameObject.Find("Panel").GetComponent<Text>();
        Text7 = GameObject.Find("Panel").GetComponent<Text>();
        Text8 = GameObject.Find("Panel").GetComponent<Text>();
        Text9 = GameObject.Find("Panel").GetComponent<Text>();
        Text10 = GameObject.Find("Panel").GetComponent<Text>();
        Text11 = GameObject.Find("Panel").GetComponent<Text>();
        Text12 = GameObject.Find("Panel").GetComponent<Text>();

        Text0.text ="Turtle: " + turtle.ToString();
        Text1.text ="Coffee: " + coffee;
        Text2.text ="RedBull: " + redBull;
        Text3.text ="Pills: " + pills;
        Text4.text ="Calculator: " +calculator;
        Text5.text ="Rule: " + rule;
        Text6.text ="Compass: "+ compass;
        Text7.text ="Pencil: " + pencil;
        Text8.text ="Glasses: "+ glasses;
        Text9.text ="USB: "+ usb;
        Text10.text ="Book: " + book;
        Text11.text ="Puzzle: " + puzzle;
        Text12.text ="CheatSheet: " + cheat;
        Panel.SetActive(true);
        Invoke("HidePanel", levelStartDelay);
    */     //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(level);

    }

    private void HidePanel(){
        Panel.SetActive(false);
    }


    public void GameOver(){

    }


        //Update is called every frame.
        void Update()
        {

        }
    }