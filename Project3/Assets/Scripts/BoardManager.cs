﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int max, int min)
        {
            minimum = min;
            maximum = max;
        }
    }

    private int columns;
    private int rows;

    public Count foodCount = new Count(10, 20);

    public GameObject[] turtle;
    public GameObject residence; //r
    public GameObject cofeeBuilding; //q
    public GameObject eetacBuilding; //u
    public GameObject teacherBuilding; //e
    public GameObject laketile; //lk

    public GameObject floor1; //f
    public GameObject lake1; //l
    public GameObject lake2; //z
    public GameObject grass1; //g
    public GameObject lakeBorder1; //i
    public GameObject lakeBorder2; //o
    public GameObject lakeBorder3; //p
    public GameObject lakeBorder4; //k
    public GameObject lakeBorder6; //n
    public GameObject lakeBorder7; //x
    public GameObject lakeBorder8; //c
    public GameObject lakeBorder9; //v
    public GameObject Canteen_floor; //C
    public GameObject table1; //1
    public GameObject table2; //2
    public GameObject table3; //3
    public GameObject table4; //4
    public GameObject stool; //s
    public GameObject bar1; //@
    public GameObject bar2; //#
    public GameObject bar3; //%
    public GameObject bar4; //~
    public GameObject bar5; //&
    public GameObject bar6; //(
    public GameObject sink1; //5
    public GameObject sink2; //6
    public GameObject sink3; //7
    public GameObject sink4; //8
    public GameObject wall; //w
    public GameObject chair; //S
    public GameObject cashRegister; //R
    public GameObject wall2; //W
    public GameObject computer; //O
    public GameObject blackBoard1; //K
    public GameObject blackBoard2; //L
    public GameObject blackBoard3; //Ñ
    public GameObject grass_wall; //gw
    public GameObject EETAC1; //e1
    public GameObject EETAC2; //e2
    public GameObject EETAC3; //e3
    public GameObject EETAC4; //e4
    public GameObject EETAC5; //e5
    public GameObject EETAC6; //e6
    public GameObject EETAC7; //e7
    public GameObject EETAC8; //e8
    public GameObject EETAC9; //e9
    public GameObject EETAC_Door; //ed
    public GameObject EETAC_C1; //c1
    public GameObject EETAC_C2; //c2
    public GameObject EETAC_C3; //c3
    public GameObject EETAC_C4; //c4
    public GameObject EETAC_C5; //c5
    public GameObject EETAC_C6; //c6
    public GameObject EETAC_C7; //c7
    public GameObject EETAC_C8; //c8
    public GameObject EETAC_C9; //c9
    public GameObject[] Students;
    public GameObject shop;
    public GameObject Cal;
    public GameObject Ele;
    public GameObject Com;
    public GameObject Oesc;
    public GameObject Dsa;
    public GameObject Aero;
    public GameObject Tfg;
    public GameObject Black;



    private GameObject mainCamera;
    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.

    private List <Vector3> gridPositions = new List <Vector3> ();    //A list of possible locations to place tiles.
    /*
    private string[,] map = new string[32, 15] 
    {
                                                {"f","f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f","f","f","f"},
                                                {"f","f", "f", "f", "f", "f","e1","e5","e5","c1","c3","c9","f","f","f"},
                                                {"f","f", "f", "f", "f", "f","ed","e7","e7","c2","c4","c9","f","f","f"},
                                                {"f","f","e1","e5","e5","e5","c1","c3","c3","c9","c4","c8","f","f","f"},
                                                {"f","f","e2","e2","e2","e2","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e3","e3","e3","e3","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e4","e6","e6","e6","c5","c6","c6","c7","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e7","e7","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e9","e9","c2","c4","c4","c8","f","f","f"},
                                                {"f","f","e1","e5","e5","e5","c1","c3","c3","c9","c4","c8","f","f","f"},
                                                {"f","f","e2","e2","e2","e2","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e3","e3","e3","e3","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e4","e6","e6","e6","c5","c6","c6","c7","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e7","e7","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e9","e9","c2","c4","c4","c8","f","f","f"},
                                                {"f","f","e1","e5","e5","e5","c1","c3","c3","c9","c4","c8","f","f","f"},
                                                {"f","f","e2","e2","e2","e2","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e3","e3","e3","e3","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e4","e6","e6","e6","c5","c6","c6","c7","c4","c8","f","f","f"},
                                                {"f","f", "f", "f", "f", "f","ed","e7","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e7","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e8","e8","c2","c4","c4","c8","f","f","f"},
                                                {"f","f", "g", "g", "g", "g","e9","e9","c2","c4","c4","c8","f","f","f"},
                                                {"f","f","e1","e5","e5","e5","c1","c3","c3","c9","c4","c8","f","f","f"},
                                                {"f","f","e2","e2","e2","e2","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e3","e3","e3","e3","c2","c4","c4","c8","c4","c8","f","f","f"},
                                                {"f","f","e4","e6","e6","e6","c5","c6","c6","c7","c6","c7","f","f","f"}
    };
    */

    public static string eetac = "11-41\n"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W\n"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W\n"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W\n"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4\n"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-W-f-f-W-f-2-4-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no\n";

    public static string resa = "11-41\n"
                + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W\n"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W\n"
                + "W-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-W\n"
                + "e1-ed-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-e7-e8-e8-e8-e9-W-f-f-W-W-W-W-W-W-ed-e4\n"
                + "no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-W-f-f-w-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-W-f-f-f-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-W-f-f-W-f-t2-t4-f-W-no-no-no-no-no-no-no\n"
                + "no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-W-f-f-W-f-f-f-f-W-no-no-no-no-no-no-no\n"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no\n";

    public string canteen = "10-18\n"
    + "w-w-w-w-w-w-w-w-w-w-@-w-w-5-7-5-7-w\n"
    + "C-1-3-s-C-1-3-s-C-C-R-C-C-6-8-6-8-C\n"
    + "C-2-4-s-C-2-4-s-C-S-#-C-C-C-C-C-C-C\n"
    + "C-s-s-C-C-s-s-C-C-C-R-C-C-C-C-C-C-C\n"
    + "C-C-C-C-C-C-C-C-C-S-%-&-&-&-&-&-&-&\n"
    + "C-C-C-C-C-C-C-C-C-S-~-(-(-(-(-(-(-(\n"
    + "C-1-3-s-C-1-3-s-C-C-C-C-C-C-C-C-C-C\n"
    + "C-2-4-s-C-2-4-s-C-2-4-C-C-C-C-C-C-C\n"
    + "C-s-s-C-C-s-s-C-C-s-s-C-C-C-C-C-C-C\n"
    + "C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-ed-C\n";

    public string office = "12-19\n"
    + "W-K-L-Ñ-w-w-w-K-L-Ñ-w-w-w-K-L-Ñ-w-w-W\n"
    + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W\n"
    + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W\n"
    + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W\n"
    + "W-w-w-w-w-C-w-w-w-w-w-C-w-w-w-w-w-C-W\n"
    + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W\n"
    + "ed-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-C-W\n"
    + "W-K-L-Ñ-w-C-w-K-L-Ñ-w-C-w-K-L-Ñ-w-C-W\n"
    + "W-C-C-C-C-C-W-C-C-C-C-C-W-C-C-C-C-C-W\n"
    + "W-S-O-4-C-C-W-S-O-4-C-C-W-S-O-4-C-C-W\n"
    + "W-C-s-s-C-C-W-C-s-s-C-C-W-C-s-s-C-C-W\n"
    + "W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W-W\n";

    public static string lake = "10-18\n"
        + "ed-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f\n"
        + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f\n"
        + "f-g-i-o-o-o-o-o-o-o-o-o-o-o-o-p-g-f\n"
        + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f\n"
        + "f-g-k-l-l-l-z-l-l-l-l-l-z-l-l-n-g-f\n"
        + "f-g-k-l-l-l-l-l-l-z-l-l-l-l-l-n-g-f\n"
        + "f-g-k-l-l-l-l-l-l-l-l-l-l-l-l-n-g-f\n"
        + "f-g-x-c-c-c-c-c-c-c-c-c-c-c-c-v-g-f\n"
        + "f-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-f\n"
        + "f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f";

    public static string campus = "14-18\n"
        + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g\n"
        + "g-f-f-f-f-f-f-f-f-q-no-f-f-f-f-f-f-g\n"
        + "g-f-f-f-f-f-f-f-f-no-no-f-f-f-f-f-f-g\n"
        + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g\n"
        + "g-f-g-u-no-no-f-f-f-f-f-f-r-no-g-g-f-g\n"
        + "g-f-g-no-no-no-f-f-f-f-f-f-no-no-g-g-f-g\n"
        + "g-f-g-g-g-g-g-g-f-f-g-g-g-g-g-g-f-g\n"
        + "g-f-g-e-1-1-f-f-f-f-g-g-g-g-g-g-g-g\n"
        + "g-f-g-1-1-1-f-f-f-f-g-g-i-o-p-g-g-g\n"
        + "g-f-g-g-g-g-f-f-f-f-g-g-k-lk-n-g-g-g\n"
        + "g-f-g-g-g-g-g-g-f-f-g-g-x-c-v-g-g-g\n"
        + "g-f-f-f-f-f-f-f-f-f-g-g-g-g-g-g-g-g\n"
        + "g-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-g\n"
        + "g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g-g\n";

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum + 1);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];

            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, gridPositions.Count);

        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = gridPositions[randomIndex];

        //Remove the entry at randomIndex from the list so that it can't be re-used.
        gridPositions.RemoveAt(randomIndex);

        //Return the randomly selected Vector3 position.
        return randomPosition;
    }

    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene (string level)
    {
        gridPositions.Clear();
        string[] map;
        switch (level)
        {
            case "lake":
                map = lake.Split('\n'); break;
            case "eetac":
                map = eetac.Split('\n'); break;
            case "resa":
                map = resa.Split('\n'); break;
            case "canteen":
                map = canteen.Split('\n'); break;
            case "office":
                map = office.Split('\n'); break;
            default:
                map = campus.Split('\n'); break;
        }

        string[] d = map[0].Split('-');
        columns = Int32.Parse(d[1]);
        rows = Int32.Parse(d[0]);



        for (int y = 1; y < rows + 1; y++)
        {
            int m = rows - y;
            string line = map[y];
            string[] p = line.Split('-');
            for (int x = 0; x < columns; x++)
            {

                switch (p[x])
                {
                    case "i":
                        Instantiate(lakeBorder1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "o":
                        Instantiate(lakeBorder2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "p":
                        Instantiate(lakeBorder3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "k":
                        Instantiate(lakeBorder4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "n":
                        Instantiate(lakeBorder6, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "x":
                        Instantiate(lakeBorder7, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c":
                        Instantiate(lakeBorder8, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "v":
                        Instantiate(lakeBorder9, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "f":
                        Instantiate(floor1, new Vector3(x, m, 0f), Quaternion.identity);
                        gridPositions.Add(new Vector3(x, m, 0f)); //To after add turtles randomly in map
                        break;
                    case "l":
                        Instantiate(lake1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "z":
                        Instantiate(lake2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "g":
                        Instantiate(grass1, new Vector3(x, m, 0f), Quaternion.identity);
                        gridPositions.Add(new Vector3(x, m, 0f)); //To after add turtles randomly in map
                        break;
                    case "C":
                        Instantiate(Canteen_floor, new Vector3(x, m, 0f), Quaternion.identity);
                        gridPositions.Add(new Vector3(x, m, 0f)); //To after add turtles randomly in map
                        break;
                    case "1":
                        Instantiate(table1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "2":
                        Instantiate(table2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "3":
                        Instantiate(table3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "4":
                        Instantiate(table4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "s":
                        Instantiate(stool, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "@":
                        Instantiate(bar1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "#":
                        Instantiate(bar2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "%":
                        Instantiate(bar3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "~":
                        Instantiate(bar4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "&":
                        Instantiate(bar5, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "(":
                        Instantiate(bar6, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "5":
                        Instantiate(sink1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "6":
                        Instantiate(sink2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "7":
                        Instantiate(sink3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "8":
                        Instantiate(sink4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "w":
                        Instantiate(wall, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "S":
                        Instantiate(chair, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "R":
                        Instantiate(cashRegister, new Vector3(x, m, 0f), Quaternion.identity); break;
		            case "W":
                        Instantiate(wall2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "O":
                        Instantiate(computer, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "K":
                        Instantiate(blackBoard1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "L":
                        Instantiate(blackBoard2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "Ñ":
                        Instantiate(blackBoard3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "gw":
                        Instantiate(grass_wall, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e1":
                        Instantiate(EETAC1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e2":
                        Instantiate(EETAC2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e3":
                        Instantiate(EETAC3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e4":
                        Instantiate(EETAC4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e5":
                        Instantiate(EETAC5, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e6":
                        Instantiate(EETAC6, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e7":
                        Instantiate(EETAC7, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e8":
                        Instantiate(EETAC8, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e9":
                        Instantiate(EETAC9, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "ed":
                        Instantiate(EETAC_Door, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c1":
                        Instantiate(EETAC_C1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c2":
                        Instantiate(EETAC_C2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c3":
                        Instantiate(EETAC_C3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c4":
                        Instantiate(EETAC_C4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c5":
                        Instantiate(EETAC_C5, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c6":
                        Instantiate(EETAC_C6, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c7":
                        Instantiate(EETAC_C7, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c8":
                        Instantiate(EETAC_C8, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "c9":
                        Instantiate(EETAC_C9, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "u":
                        Instantiate(eetacBuilding, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "e":
                        Instantiate(teacherBuilding, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "r":
                        Instantiate(residence, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "lk":
                        Instantiate(laketile, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "q":
                        Instantiate(cofeeBuilding, new Vector3(x, m, 0f), Quaternion.identity); break;
                    default:
                        break;
                }
            }
        }
        if (level=="lake")
            LayoutObjectAtRandom(turtle, 1, 5);
        else if (level=="canteen")
            Instantiate(shop, new Vector3(3, 8, 0f), Quaternion.identity);
        else if (level=="office"){
            Instantiate(Cal, new Vector3(1, 3, 0f), Quaternion.identity);
            Instantiate(Ele, new Vector3(7, 3, 0f), Quaternion.identity);
            Instantiate(Com, new Vector3(13, 3, 0f), Quaternion.identity);
            Instantiate(Oesc, new Vector3(1, 10, 0f), Quaternion.identity);
            Instantiate(Dsa, new Vector3(7, 10, 0f), Quaternion.identity);
            Instantiate(Aero, new Vector3(13,10, 0f), Quaternion.identity);
            Instantiate(Tfg, new Vector3(8, 5, 0f), Quaternion.identity);
        }
        LayoutObjectAtRandom(Students, 3, 6);
    }
}