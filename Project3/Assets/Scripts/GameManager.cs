using UnityEngine;
using System.Collections;


using System.Collections.Generic;        //Allows us to use Lists.
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;


    /*public int turtle;
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
    public bool tfg = false;*/

    public static Inventory lastinventory = null;
    public static Inventory instanceinv;
    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.
    
    public string vectorlevel;                                    //Store string of the actual level we will plot in BoardManager
    public string levelname = "campus";                           //Name of the level. To some actions in BoardManager
    public string level = "1";                                    //Current level number following the below notation:
                                                                  //level 1: campus
                                                                  //level 2: resa
                                                                  //level 3: canteen
                                                                  //level 4: office
                                                                  //level 5: lake
                                                                  //level 6: eetac

    public GameObject LevelImage;
    public Text LevelImageText;

    [HideInInspector] public bool playersTurn = true;


    //Awake is always called before any Start functions
    void Awake()
    {

        //Check if instance already exists
        if (instance == null)
        { 

            //if not, set instance to this
            instance = this; 
        }
        else if (instance != this)//If instance already exists and it's not this:
        {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject); 
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();
 
        lastinventory = instanceinv;
        instanceinv = new Inventory();

        //Call the InitGame function to initialize the first level
        InitGame();
    }


    void OnLevelWasLoaded()
    {
        lastinventory = instanceinv;
        InitGame();
    }
    //Initializes the game for each level.
    void InitGame()
    {

        //Call the SetupScene function of the BoardManager script, pass it current level number.

#if UNITY_ANDROID
        LevelImage.gameObject.SetActive(true);
        LevelImageText.gameObject.SetActive(true);   
        LevelImageText.text = levelname;

           string eetac = "11-41/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4/"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string resa = "11-41/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4/"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string canteen = "10-18/"
                + "w-w-w-w-w-w-w-w-w-w-@-w-w-5-7-5-7-w/"
                + "C-1-3-s-C-1-3-s-C-C-R-C-C-6-8-6-8-C/"
                + "C-2-4-s-C-2-4-s-C-S-#-C-C-C-C-C-C-C/"
                + "C-s-s-C-C-s-s-C-C-C-R-C-C-C-C-C-C-C/"
                + "C-C-C-C-C-C-C-C-C-S-%-&-&-&-&-&-&-&/"
                + "C-C-C-C-C-C-C-C-C-S-~-(-(-(-(-(-(-(/"
                + "C-1-3-s-C-1-3-s-C-C-C-C-C-C-C-C-C-C/"
                + "C-2-4-s-C-2-4-s-C-2-4-C-C-C-C-C-C-C/"
                + "C-s-s-C-C-s-s-C-C-s-s-C-C-C-C-C-C-C/"
                + "C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-ed-C/";

            string office = "12-19/"
                + "W-K-L-Ñ-w-w-w-K-L-Ñ-w-w-w-K-L-Ñ-w-w-W/"
                + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W/"
                + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W/"
                + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W/"
                + "W-w-w-w-w-C-w-w-w-w-w-C-w-w-w-w-w-C-W/"
                + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-K-L-Ñ-w-C-w-K-L-Ñ-w-C-w-K-L-Ñ-w-C-W/"
                + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W/"
                + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W/"
                + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/";

            string lake = "10-18/"
                + "ed-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f/"
                + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f/"
                + "f-g-i-o-o-o-o-o-o-o-o-o-o-o-o-p-g-f/"
                + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f/"
                + "f-g-k-l-l-l-z-l-l-l-l-l-z-l-l-n-g-f/"
                + "f-g-k-l-l-l-l-l-l-z-l-l-l-l-l-n-g-f/"
                + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f/"
                + "f-g-x-c-c-c-c-c-c-c-c-c-c-c-c-v-g-f/"
                + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f/"
                + "f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f/";

            string campus = "14-18/"
                + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-q-no-f-f-f-f-f-f-g/"
                + "g-f-f-f-f-f-f-f-f-no-no-f-f-f-f-f-f-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g/"
                + "g-f-g-u-no-no-f-f-f-f-f-f-r-no-g-g-f-g/"
                + "g-f-g-no-no-no-f-f-f-f-f-f-no-no-g-g-f-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g/"
                + "g-f-g-e-1-1-f-f-f-f-g-g-g-g-g-g-g-g/"
                + "g-f-g-1-1-1-f-f-f-f-g-g-i-o-p-g-g-g/"
                + "g-f-g-g-g-g-f-f-f-f-g-g-k-lk-n-g-g-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-x-c-v-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-f-g-g-g-g-g-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-g/"
                + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g/";


            //AndroidJavaClass javaClass = new AndroidJavaClass("edu.upc.androidapp.UnityAPI");
            //string vectorlevel = javaClass.CallStatic<string>("getLevel", level);
            //string levelname = javaClass.CallStatic<string>("getLevelName", level);
            switch (level)
            {
                case "1":
                    vectorlevel = campus;
                    levelname = "campus"; break;
                case "2":
                    vectorlevel = resa; 
                    levelname = "resa"; break;
                case "3":
                    vectorlevel = canteen;
                    levelname = "canteen"; break;
                case "4":
                    vectorlevel = office;
                    levelname = "office"; break;
                case "5":
                    vectorlevel = lake;
                    levelname = "lake"; break;
                case "6":
                    vectorlevel = eetac;
                    levelname = "eetac"; break;
                default:
                    vectorlevel = campus;
                    levelname = "campus"; break;
            }
            boardScript.SetupScene(vectorlevel,levelname);
            LevelImage.gameObject.SetActive(false);
            LevelImageText.gameObject.SetActive(false);


#elif UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBPLAYER
        LevelImage.gameObject.SetActive(true);
        LevelImageText.gameObject.SetActive(true);
        LevelImageText.text = levelname;
           string eetac = "11-41/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4/"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string resa = "11-41/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W/"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4/"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string canteen = "10-18/"
                + "w-w-w-w-w-w-w-w-w-w-@-w-w-5-7-5-7-w/"
                + "C-1-3-s-C-1-3-s-C-C-R-C-C-6-8-6-8-C/"
                + "C-2-4-s-C-2-4-s-C-S-#-C-C-C-C-C-C-C/"
                + "C-s-s-C-C-s-s-C-C-C-R-C-C-C-C-C-C-C/"
                + "C-C-C-C-C-C-C-C-C-S-%-&-&-&-&-&-&-&/"
                + "C-C-C-C-C-C-C-C-C-S-~-(-(-(-(-(-(-(/"
                + "C-1-3-s-C-1-3-s-C-C-C-C-C-C-C-C-C-C/"
                + "C-2-4-s-C-2-4-s-C-2-4-C-C-C-C-C-C-C/"
                + "C-s-s-C-C-s-s-C-C-s-s-C-C-C-C-C-C-C/"
                + "C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-ed-C/";

            string office = "12-19/"
                + "W-K-L-Ñ-w-w-w-K-L-Ñ-w-w-w-K-L-Ñ-w-w-W/"
                + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W/"
                + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W/"
                + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W/"
                + "W-w-w-w-w-C-w-w-w-w-w-C-w-w-w-w-w-C-W/"
                + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-K-L-Ñ-w-C-w-K-L-Ñ-w-C-w-K-L-Ñ-w-C-W/"
                + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W/"
                + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W/"
                + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W/";

            string lake = "10-18/"
                + "ed-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f/"
                + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f/"
                + "f-g-i-o-o-o-o-o-o-o-o-o-o-o-o-p-g-f/"
                + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f/"
                + "f-g-k-l-l-l-z-l-l-l-l-l-z-l-l-n-g-f/"
                + "f-g-k-l-l-l-l-l-l-z-l-l-l-l-l-n-g-f/"
                + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f/"
                + "f-g-x-c-c-c-c-c-c-c-c-c-c-c-c-v-g-f/"
                + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f/"
                + "f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f/";

            string campus = "14-18/"
                + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-q-no-f-f-f-f-f-f-g/"
                + "g-f-f-f-f-f-f-f-f-no-no-f-f-f-f-f-f-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g/"
                + "g-f-g-u-no-no-f-f-f-f-f-f-r-no-g-g-f-g/"
                + "g-f-g-no-no-no-f-f-f-f-f-f-no-no-g-g-f-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g/"
                + "g-f-g-e-1-1-f-f-f-f-g-g-g-g-g-g-g-g/"
                + "g-f-g-1-1-1-f-f-f-f-g-g-i-o-p-g-g-g/"
                + "g-f-g-g-g-g-f-f-f-f-g-g-k-lk-n-g-g-g/"
                + "g-f-g-g-g-g-g-g-f-f-g-g-x-c-v-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-f-g-g-g-g-g-g-g-g/"
                + "g-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-g/"
                + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g/";

            switch (level)
            {
                case "1":
                    vectorlevel = campus;
                    levelname = "campus"; break;
                case "2":
                    vectorlevel = resa; 
                    levelname = "resa"; break;
                case "3":
                    vectorlevel = canteen;
                    levelname = "canteen"; break;
                case "4":
                    vectorlevel = office;
                    levelname = "office"; break;
                case "5":
                    vectorlevel = lake;
                    levelname = "lake"; break;
                case "6":
                    vectorlevel = eetac;
                    levelname = "eetac"; break;
                default:
                    vectorlevel = campus;
                    levelname = "campus"; break;
            }
            boardScript.SetupScene(vectorlevel,levelname);
            LevelImage.gameObject.SetActive(false);
            LevelImageText.gameObject.SetActive(false);
#endif
    }

    private void HidePanel()
    {
        LevelImage.SetActive(false);
    }


    public void GameOver()
    {
        LevelImage.gameObject.SetActive(true);
        LevelImageText.gameObject.SetActive(true);
        LevelImageText.text = "¡Felicidades! ¡Estas preparado para ir a McDonald'S!";

    }
}