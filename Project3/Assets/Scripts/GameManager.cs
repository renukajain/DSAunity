using UnityEngine;
using System.Collections;


using System.Collections.Generic;        //Allows us to use Lists.
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;


    //public Player player;

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
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string canteen = "11-20/"
                + "W-w-w-w-w-w-w-w-w-w-w-@-w-w-5-7-5-7-w-W/"
                + "W-C-1-3-s-C-1-3-s-C-C-R-C-C-6-8-6-8-C-W/"
                + "W-C-2-4-s-C-2-4-s-C-S-#-C-C-C-C-C-C-C-W/"
                + "W-C-s-s-C-C-s-s-C-C-C-R-C-C-C-C-C-C-C-W/"
                + "W-C-C-C-C-C-C-C-C-C-S-%-&-&-&-&-&-&-&-W/"
                + "W-C-C-C-C-C-C-C-C-C-S-~-(-(-(-(-(-(-(-W/"
                + "W-C-1-3-s-C-1-3-s-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-C-2-4-s-C-2-4-s-C-2-4-C-C-C-C-C-C-C-W/"
                + "W-C-s-s-C-C-s-s-C-C-s-s-C-C-C-C-C-C-C-W/"
                + "W-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-ed-W-W/";

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

            string lake = "12-20/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/"
                + "gw-ed-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-gw/"
                + "gw-f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f-gw/"
                + "gw-f-g-i-o-o-o-o-o-o-o-o-o-o-o-o-p-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-z-l-l-l-l-l-z-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-z-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-x-c-c-c-c-c-c-c-c-c-c-c-c-v-g-f-gw/"
                + "gw-f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f-gw/"
                + "gw-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-gw/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/";

            string campus = "16-20/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/"
                + "gw-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-q-no-f-f-f-f-f-f-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-no-no-f-f-f-f-f-f-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g-gw/"
                + "gw-g-f-g-u-no-no-f-f-f-f-f-f-r-no-g-g-f-g-gw/"
                + "gw-g-f-g-no-no-no-f-f-f-f-f-f-no-no-g-g-f-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g-gw/"
                + "gw-g-f-g-e-no-no-f-f-f-f-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-g-no-no-no-f-f-f-f-g-g-i-o-p-g-g-g-gw/"
                + "gw-g-f-g-g-g-g-f-f-f-f-g-g-k-lk-n-g-g-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-x-c-v-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-f-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-g-gw/"
                + "gw-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-gw/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/";



            //AndroidJavaClass javaClass = new AndroidJavaClass("edu.upc.androidapp.UnityAPI");
            //string vectorlevel = javaClass.CallStatic<string>("getLevel", level);
            //string levelname = javaClass.CallStatic<string>("getLevelName", level);
            switch (level)
            {
                case "1":
                    vectorlevel = campus;
                    levelname = "campus"; 
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
                case "2":
                    vectorlevel = resa; 
                    levelname = "resa"; 
                    //player.transform.position= new Vector3(1f,9f,0f);
                    break;
                case "3":
                    vectorlevel = canteen;
                    levelname = "canteen";
                    //player.transform.position= new Vector3(17f,3f,0f);
                    break;
                case "4":
                    vectorlevel = office;
                    levelname = "office";
                    //player.transform.position= new Vector3(2f,5f,0f);
                    break;
                case "5":
                    vectorlevel = lake;
                    levelname = "lake";
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
                case "6":
                    vectorlevel = eetac;
                    levelname = "eetac"; 
                    //player.transform.position= new Vector3(1f,9f,0f);
                    break;
                default:
                    vectorlevel = campus;
                    levelname = "campus";
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
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
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no/"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no/"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no/";

            string canteen = "11-20/"
                + "W-w-w-w-w-w-w-w-w-w-w-@-w-w-5-7-5-7-w-W/"
                + "W-C-1-3-s-C-1-3-s-C-C-R-C-C-6-8-6-8-C-W/"
                + "W-C-2-4-s-C-2-4-s-C-S-#-C-C-C-C-C-C-C-W/"
                + "W-C-s-s-C-C-s-s-C-C-C-R-C-C-C-C-C-C-C-W/"
                + "W-C-C-C-C-C-C-C-C-C-S-%-&-&-&-&-&-&-&-W/"
                + "W-C-C-C-C-C-C-C-C-C-S-~-(-(-(-(-(-(-(-W/"
                + "W-C-1-3-s-C-1-3-s-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-C-2-4-s-C-2-4-s-C-2-4-C-C-C-C-C-C-C-W/"
                + "W-C-s-s-C-C-s-s-C-C-s-s-C-C-C-C-C-C-C-W/"
                + "W-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W/"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-ed-W-W/";

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

            string lake = "12-20/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/"
                + "gw-ed-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-gw/"
                + "gw-f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f-gw/"
                + "gw-f-g-i-o-o-o-o-o-o-o-o-o-o-o-o-p-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-z-l-l-l-l-l-z-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-z-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f-gw/"
                + "gw-f-g-x-c-c-c-c-c-c-c-c-c-c-c-c-v-g-f-gw/"
                + "gw-f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f-gw/"
                + "gw-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-gw/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/";

            string campus = "16-20/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/"
                + "gw-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-q-no-f-f-f-f-f-f-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-no-no-f-f-f-f-f-f-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g-gw/"
                + "gw-g-f-g-u-no-no-f-f-f-f-f-f-r-no-g-g-f-g-gw/"
                + "gw-g-f-g-no-no-no-f-f-f-f-f-f-no-no-g-g-f-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g-gw/"
                + "gw-g-f-g-e-no-no-f-f-f-f-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-g-no-no-no-f-f-f-f-g-g-i-o-p-g-g-g-gw/"
                + "gw-g-f-g-g-g-g-f-f-f-f-g-g-k-lk-n-g-g-g-gw/"
                + "gw-g-f-g-g-g-g-g-g-f-f-g-g-x-c-v-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-f-g-g-g-g-g-g-g-g-gw/"
                + "gw-g-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-g-gw/"
                + "gw-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-gw/"
                + "gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw-gw/";

            switch (level)
            {
                case "1":
                    vectorlevel = campus;
                    levelname = "campus"; 
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
                case "2":
                    vectorlevel = resa; 
                    levelname = "resa"; 
                    //player.transform.position= new Vector3(1f,9f,0f);
                    break;
                case "3":
                    vectorlevel = canteen;
                    levelname = "canteen";
                    //player.transform.position= new Vector3(17f,3f,0f);
                    break;
                case "4":
                    vectorlevel = office;
                    levelname = "office";
                    //player.transform.position= new Vector3(2f,5f,0f);
                    break;
                case "5":
                    vectorlevel = lake;
                    levelname = "lake";
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
                case "6":
                    vectorlevel = eetac;
                    levelname = "eetac"; 
                    //player.transform.position= new Vector3(1f,9f,0f);
                    break;
                default:
                    vectorlevel = campus;
                    levelname = "campus";
                    //player.transform.position= new Vector3(1f,1f,0f);
                    break;
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