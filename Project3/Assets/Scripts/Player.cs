using UnityEngine;
using System.Collections;
using UnityEngine.UI;    //Allows us to use UI.
using UnityEngine.UI;                    //Allows us to use UI.


//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class Player : MovingObject
{

    public float dialogueTime = 3f;
    public static Collider2D collider;

    public Text scoreText;
    public GameObject scorePannel;
    public GameObject imageDialogue;
    public Text Dialogue;
    public Text LevelImageText;
    public GameObject LevelImage;
    public GameObject ShopPanel;
    public Button Button;
    
    public void setCollider(Collider2D col) {
        collider = col;
    }
    public Collider2D getCollider()
    {
        return collider;
    }

    public float restartLevelDelay = 1f;        //Delay time in seconds to restart level.
    //public int pointsPerFood = 10;                //Number of points to add to player food points when picking up a food object.
    //public int pointsPerSoda = 20;                //Number of points to add to player food points when picking up a soda object.
    //public int wallDamage = 1;                    //How much damage a player does to a wall when chopping it.
    //public Text foodText;                        //UI Text to display current player food total.
    //public AudioClip moveSound1;                //1 of 2 Audio clips to play when player moves.
    //public AudioClip moveSound2;                //2 of 2 Audio clips to play when player moves.
    //public AudioClip eatSound1;                    //1 of 2 Audio clips to play when player collects a food object.
    //public AudioClip eatSound2;                    //2 of 2 Audio clips to play when player collects a food object.
    //public AudioClip drinkSound1;                //1 of 2 Audio clips to play when player collects a soda object.
    //public AudioClip drinkSound2;                //2 of 2 Audio clips to play when player collects a soda object.
    //public AudioClip gameOverSound;                //Audio clip to play when player dies.
    
    public int turtle = 0;
    public int coffee = 0;
    public int redBull = 0;
    public int pills = 0;
    public int calculator = 0;
    public int rule = 0;
    public int compass = 0;
    public int pencil = 0;
    public int glasses = 0;
    public int usb = 0;
    public int book = 0;
    public int puzzle = 0;
    public int cheat = 0;
    public int coins = 0;

    public bool cal = false;
    public bool ele = false;
    public bool com = false;
    public bool oes = false;
    public bool dsa = false;
    public bool aero = false;
    public bool tfg = false;

    private Animator animator;                    //Used to store a reference to the Player's animator component.
    private Vector2 touchOrigin = -Vector2.one;    //Used to store location of screen touch origin for mobile controls.


    void awake() {
    }
    //Start overrides the Start function of MovingObject
    protected override void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();

        //Get the current food point total stored in GameManager.instance between levels.

        //Call the Start function of the MovingObject base class.
        base.Start();
    }


    //This function is called when the behaviour becomes disabled or inactive.
    private void OnDisable()
    {
        LevelImage.gameObject.SetActive(true);
        LevelImageText.gameObject.SetActive(true);
        //When Player object is disabled, store the current local food total in the GameManager so it can be re-loaded in next level.
    }


    private void Update()
    {
        Inventory I = GameManager.instanceinv;
        turtle = I.GetTurtle();
        coffee = I.GetCoffee();
        redBull = I.GetRedBull();
        pills = I.GetPills();
        calculator = I.GetCalculator();
        rule = I.GetRule();
        compass = I.GetCompass();
        pencil = I.GetPencil();
        glasses = I.GetGlasses();
        usb = I.GetUsb();
        book = I.GetBook();
        puzzle = I.GetPuzzle();
        cheat = I.GetCheat();
        coins = I.GetCoins();
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;      //Used to store the horizontal move direction.
        int vertical = 0;        //Used to store the vertical move direction.

        //Check if we are running either in the Unity editor or in a standalone build.
    #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

            //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
            horizontal = (int) (Input.GetAxisRaw ("Horizontal"));

            //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
            vertical = (int) (Input.GetAxisRaw ("Vertical"));

            //Check if moving horizontally, if so set vertical to zero.
            if(horizontal != 0)
            {
                vertical = 0;
            }
            //Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
    #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

            //Check if Input has registered more than zero touches
            if (Input.touchCount > 0)
            {
                //Store the first touch detected.
                Touch myTouch = Input.touches[0];

                //Check if the phase of that touch equals Began
                if (myTouch.phase == TouchPhase.Began)
                {
                    //If so, set touchOrigin to the position of that touch
                    touchOrigin = myTouch.position;
                }

                //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
                else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                {
                    //Set touchEnd to equal the position of this touch
                    Vector2 touchEnd = myTouch.position;

                    //Calculate the difference between the beginning and end of the touch on the x axis.
                    float x = touchEnd.x - touchOrigin.x;

                    //Calculate the difference between the beginning and end of the touch on the y axis.
                    float y = touchEnd.y - touchOrigin.y;

                    //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                    touchOrigin.x = -1;

                    //Check if the difference along the x axis is greater than the difference along the y axis.
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                        horizontal = x > 0 ? 1 : -1;
                    else
                        //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                        vertical = y > 0 ? 1 : -1;
                }
            }

        #endif //End of mobile platform dependendent compilation section started above with #elif
        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttemptMove<Wall>(horizontal, vertical);
        }
    }

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
    protected override void AttemptMove<T>(int xDir, int yDir)
    {

        //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
        base.AttemptMove<T>(xDir, yDir);
        scorePannel.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        //Hit allows us to reference the result of the Linecast done in Move.
        RaycastHit2D hit;

        //If Move returns true, meaning Player was able to move into an empty space.
        if (Move(xDir, yDir, out hit))
        {
            //Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
            //SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }

        //Since the player has moved and lost food points, check if the game has ended.
        CheckIfGameOver();

        //Set the playersTurn boolean of GameManager to false now that players turn is over.
        //GameManager.instance.playersTurn = false;
    }


    //OnCantMove overrides the abstract function OnCantMove in MovingObject.
    //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
    protected override void OnCantMove<T>(T component)
    {
        //Set hitWall to equal the component passed in as a parameter.
        //Wall hitWall = component as Wall;

        //Call the DamageWall function of the Wall we are hitting.
        //hitWall.DamageWall(wallDamage);

        //Set the attack trigger of the player's animation controller in order to play the player's attack animation.
        animator.SetTrigger("playerChop");
    }

    private void HideDialogue()
    {
        imageDialogue.SetActive(false);
        //doingSetup = false;
    }

    private void ShowDialogue(){
        imageDialogue.SetActive(true);
        //Invoke("HideDialogue", dialogueTime);
    }



    //OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.setCollider(other);


        //Check if the tag of the trigger collided with is the one needed to change map
        if (other.tag == "Turtle")
        {
            turtle++;
            GameManager.instanceinv.SetTurtle(turtle);
            other.gameObject.SetActive(false);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Tortuga añadida";
            //ShowDialogue();
        }
        else if (other.tag == "Coffee")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            coffee++;
            GameManager.instanceinv.SetCoffee(coffee);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Café añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Calculator")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            calculator++;
            GameManager.instanceinv.SetCalculator(calculator);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Calculadora añadida";
            //ShowDialogue();
        }
        else if (other.tag == "RedBull")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            redBull++;
            GameManager.instanceinv.SetRedBull(redBull);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "RedBull añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Pills")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            pills++;
            GameManager.instanceinv.SetPills(pills);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Pastllas añadidas";
            //ShowDialogue();
        }
        else if (other.tag == "Rule")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            rule++;
            GameManager.instanceinv.SetRule(rule);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Regla añadida";
            //ShowDialogue();
        }
        else if (other.tag == "Compass")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            compass++;
            GameManager.instanceinv.SetCompass(compass);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Compás añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Pencil")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            pencil++;
            GameManager.instanceinv.SetPencil(pencil);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Lápiz añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Glasses")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            glasses++;
            GameManager.instanceinv.SetGlasses(glasses);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Gafas añadidas";
            //ShowDialogue();
        }
        else if (other.tag == "Usb")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            usb++;
            GameManager.instanceinv.SetUsb(usb);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "usb añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Book")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            book++;
            GameManager.instanceinv.SetBook(book);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Libro añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Puzzle")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            puzzle++;
            GameManager.instanceinv.SetPuzzle(puzzle);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Puzzle añadido";
            //ShowDialogue();
        }
        else if (other.tag == "Cheat")
        {
            coins = coins + 10;
            GameManager.instanceinv.SetCoins(coins);
            cheat++;
            GameManager.instanceinv.SetCheat(cheat);
            scorePannel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Chuleta añadida";
            //ShowDialogue();
        }
        else if (other.tag == "CAL")
        {

            if (GameManager.instanceinv.GetCalc())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado calculo, pero puedo resolver dudas ya que soy fundamental para ti";
            }
            else if (calculator >= 4 && pencil >= 2 && rule >= 1)
            {
                GameManager.instanceinv.SetCalc();
                cal = true;
                calculator -= 4;
                pencil -= 2;
                rule -= 1;
                GameManager.instanceinv.SetCalculator(calculator);
                GameManager.instanceinv.SetPencil(pencil);
                GameManager.instanceinv.SetRule(rule);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas calculo, puedes seguir en este infierno llamado universidad";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas calculo, yo que tu volveria al bachi a ver si asi aprendes algo";
            }
        }
        else if (other.tag == "ELE")
        {
            if (GameManager.instanceinv.GetElec())
            {
                scoreText.text = "Ya has aprobado electonica, vete a montar robiticos o algo va";
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
            }
            else if (pills >= 3 && glasses >= 1 && usb >= 1 && calculator >= 1)
            {
                GameManager.instanceinv.SetElec();
                ele = true;
                pills -= 3;
                glasses -= 1;
                usb -= 1;
                GameManager.instanceinv.SetPills(pills);
                GameManager.instanceinv.SetGlasses(glasses);
                GameManager.instanceinv.SetUsb(usb);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas electronica, has sabido jugar al arduino bien";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas electronica, no es lo tuyo Kirchoff";
            }
        }
        else if (other.tag == "COM")
        {
            if (GameManager.instanceinv.GetComms())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado comunicaciones, vete a echar curriculums a Movistar va";
            }
            else if (coffee >= 2 && cheat >= 1 && compass >= 4)
            {
                GameManager.instanceinv.SetComms();
                com = true;
                coffee -= 2;
                cheat -= 1;
                compass -= 4;
                GameManager.instanceinv.SetCoffee(coffee);
                GameManager.instanceinv.SetCheat(cheat);
                GameManager.instanceinv.SetCompass(compass);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas comunicaciones, preparate para el 5G que viene faena";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas comunicaciones, pareces una antena sin señal";
            }
        }
        else if (other.tag == "OESC")
        {
            if (GameManager.instanceinv.GetOesc())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado oesc, mejora tus habilidades socioempresariales";
            }
            else if (redBull >= 2 && calculator >= 2 && pills >= 1 && usb >= 4)
            {
                GameManager.instanceinv.SetOesc();
                oes = true;
                redBull -= 2;
                calculator -= 2;
                pills -= 1;
                usb -= 4;

                GameManager.instanceinv.SetRedBull(redBull);
                GameManager.instanceinv.SetCalculator(calculator);
                GameManager.instanceinv.SetPills(pills);
                GameManager.instanceinv.SetUsb(usb);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas oesc. Has hecho un buen esfuerzo y tu responsabilidad como ingeniero/a estudiante cumplida";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas oesc. Deberias ser mas autoresponable";
            }
        }
        else if (other.tag == "DSA")
        {
            if (GameManager.instanceinv.GetDsa())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado dsa, vete a hacer juegos";
            }
            else if (turtle >= 1 && coffee >= 3 && redBull >= 1 && usb >= 3 && glasses >= 1)
            {
                GameManager.instanceinv.SetDsa();
                dsa = true;
                turtle -= 1;
                coffee -= 3;
                redBull -= 1;
                usb -= 3;
                glasses -= 1;
                GameManager.instanceinv.SetTurtle(turtle);
                GameManager.instanceinv.SetCoffee(coffee);
                GameManager.instanceinv.SetRedBull(redBull);
                GameManager.instanceinv.SetUsb(usb);
                GameManager.instanceinv.SetGlasses(glasses);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas dsa. De aqui a Electronic Arts de lo bueno que eres fiera";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas dsa ni currando lo que te queda de cuadri";
            }
        }
        else if (other.tag == "AERO")
        {
            if (GameManager.instanceinv.GetAero())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado aerodinámica, no vengas a fardar y vete";
            }
            else if (compass >= 1 && rule >= 1 && calculator >= 1 && redBull >= 3 && puzzle >= 4 && cheat >= 2)
            {
                GameManager.instanceinv.SetAero();
                aero = true;
                compass -= 1;
                rule -= 1;
                calculator -= 1;
                redBull -= 3;
                puzzle -= 4;
                cheat -= 2;
                GameManager.instanceinv.SetCompass(compass);
                GameManager.instanceinv.SetRule(rule);
                GameManager.instanceinv.SetCalculator(calculator);
                GameManager.instanceinv.SetRedBull(redBull);
                GameManager.instanceinv.SetPuzzle(puzzle);
                GameManager.instanceinv.SetCheat(cheat);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas aero. Eres un/a bestia por aprobar mi asignatura";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas aero. A visitar al paracaidista de Ciudadanos en la pracitca crack";
            }

        }
        else if (other.tag == "TFG")
        {
            if (GameManager.instanceinv.GetTfg())
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "Ya has aprobado tfg, sal de esta universidad que tu plaza son 2000€ mas para mi";
            }
            else if (redBull >= 3 && coffee >= 2 & glasses >= 1 && puzzle >= 1 && book >= 5 && calculator >= 1)
            {
                GameManager.instanceinv.SetTfg();
                tfg = true;
                redBull -= 3;
                coffee -= 2;
                glasses -= 1;
                puzzle -= 1;
                book -= 5;
                calculator -= 1;
                GameManager.instanceinv.SetRedBull(redBull);
                GameManager.instanceinv.SetCoffee(coffee);
                GameManager.instanceinv.SetGlasses(glasses);
                GameManager.instanceinv.SetPuzzle(puzzle);
                GameManager.instanceinv.SetBook(book);
                GameManager.instanceinv.SetCalculator(calculator);
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "SI apruebas TFG. Felicidades, has acabado (si no tienes que repetir ninguna jeje)";
            }
            else
            {
                scorePannel.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                scoreText.text = "NO apruebas TFG. Lo siento pero esas 40 paginas se van a repetir";
            }
        }
        else if (other.tag == "Exit")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "1"; //level 1: campus
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "EETAC")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "6"; //level 6: eetac
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "Teachers")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "4"; //level 4: office
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "RESA")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "2"; //level 2: resa
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "Lake")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "5"; //level 5: lake
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "Canteen")
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "3";//level 3: canteen
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        else if (other.tag == "Shop")
        {
            ShopPanel.gameObject.SetActive(true);
            Button.gameObject.SetActive(true);
        }
        else
        {
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().level = "1";
            Invoke("Restart", restartLevelDelay);
            enabled = false;//Disable the player object since level is over.
        }
        //if (other.tag != "CAL" && other.tag != "ELE" &&  other.tag != "COM" && other.tag != "OESC" &&  other.tag != "DSA" && other.tag != "AERO" &&  other.tag != "TFG")
        

    }


    //Restart reloads the scene when called.
    private void Restart()
    {
        //Load the last scene loaded, in this case Main, the only scene in the game.
        Application.LoadLevel(Application.loadedLevel);
    }



    //CheckIfGameOver checks if the player is out of food points and if so, ends the game.
    private void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (GameManager.instanceinv.GetCalc() && GameManager.instanceinv.GetElec() && GameManager.instanceinv.GetComms() && GameManager.instanceinv.GetOesc() && GameManager.instanceinv.GetDsa() && GameManager.instanceinv.GetAero() && GameManager.instanceinv.GetTfg())
        {
            scoreText.text = "Has ganado !!";

            //Call the PlaySingle function of SoundManager and pass it the gameOverSound as the audio clip to play.
            //SoundManager.instance.PlaySingle(gameOverSound);

            //Stop the background music.
            //SoundManager.instance.musicSource.Stop();

            //Call the GameOver function of GameManager.
            GameManager.instance.GameOver();
        }
        else if (cal && ele && com && oes && aero && tfg && dsa) {
            scoreText.text = "Has ganado !!";


            GameManager.instance.GameOver();
        }
    }
}