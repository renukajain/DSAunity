using System;
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

    public int columns;
    public int rows;

    public Count foodCount = new Count(10, 20);
    public GameObject turtle;
    public GameObject residence; //r
    public GameObject cofeeBuilding; //q
    public GameObject eetacBuilding; //u
    public GameObject exitTile; //e

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
    public GameObject Canteen_floor; //cf
    public GameObject table1; //t1
    public GameObject table2; //t2
    public GameObject table3; //t3
    public GameObject table4; //t4
    public GameObject stool; //st
    public GameObject bar1; //b1
    public GameObject bar2; //b2
    public GameObject bar3; //b3
    public GameObject bar4; //b4
    public GameObject bar5; //b5
    public GameObject bar6; //b6
    public GameObject sink1; //si1
    public GameObject sink2; //si2
    public GameObject sink3; //si3
    public GameObject sink4; //si4
    public GameObject wall; //w
    public GameObject chair; //ch
    public GameObject cashRegister; //cr
    public GameObject coffeeMachine1; //cm1
    public GameObject coffeeMachine2; //cm2
    public GameObject coffeeMachine3; //cm3
    public GameObject coffeeMachine4; //cm4
    public GameObject wall2; //w2
    public GameObject computer; //co
    public GameObject blackBoard1; //bb1
    public GameObject blackBoard2; //bb2
    public GameObject blackBoard3; //bb3
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



    private GameObject mainCamera;
    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.

    private List <Vector3> gridPositions = new List <Vector3> ();    //A list of possible locations to place tiles.
    /*
    private string[,] resa = new string[41, 11]
    {
                                                { "no","no","no","no","no","no","no","e1","w2","w2","w2"},
                                                { "no","no","no","no","no","no","no", "f", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e7", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e9", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e7", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e9", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","ed", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","w2","w2","w2","w2"}
    };
    private string[,] eetac = new string[41, 11] 
    {
                                                { "no","no","no","no","no","no","no","e1","w2","w2","w2"},
                                                { "no","no","no","no","no","no","no","ed", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e7", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e9", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e7", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e8", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","e9", "f", "f","w2"},
                                                { "e1","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "e2", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e3", "f", "f", "f", "f", "f", "f", "f", "f", "f","w2"},
                                                { "e7","w2","w2","w2","w2", "f", "w","w2", "f", "f","w2"},
                                                { "e8", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t2", "f","t2", "f", "f","w2", "f", "f","w2"},
                                                { "e8", "f","t4", "f","t4", "f", "f","w2", "f", "f","w2"},
                                                { "e9", "f", "f", "f", "f", "f", "f","w2", "f", "f","w2"},
                                                { "e4","w2","w2","w2","w2","w2","w2","w2", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","ed", "f", "f","w2"},
                                                { "no","no","no","no","no","no","no","w2","w2","w2","w2"}

    };
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

    private string[,] lake = new string[20, 11] {   {"gw","gw","gw","gw","gw","gw","gw","gw","gw","gw","gw"},
                                                    {"gw","f", "f", "f", "f", "f", "f", "f", "f", "f", "f"},
                                                    {"gw","f", "g", "g", "g", "g", "g", "g", "g", "g", "f"},
                                                    {"gw","f", "g", "x", "k", "k", "k", "k", "i", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                    {"gw","f", "g", "v", "n", "n", "n", "n", "p", "g", "f"},
                                                    {"gw","f", "g", "g", "g", "g", "g", "g", "g", "g", "f"},
                                                    {"gw","f", "f", "f", "f", "f", "f", "f", "f", "f", "f"},
                                                    {"gw","gw","gw","gw","gw","gw","gw","gw","gw","gw","gw"}};

    private string[,] canteen = new string[20,11] { {"w2","w2","w2","w2","w2","w2","w2","w2","w2","w2","w2"},
                                                    {"w2","cf","cf","cf","cf","cf","cf","cf","cf","cf", "w"},
                                                    {"w2","cf","st","t2","t1","cf","cf","st","t2","t1", "w"},
                                                    {"w2","cf","st","t4","t3","cf","cf","st","t4","t3", "w"},
                                                    {"w2","cf","cf","st","st","cf","cf","cf","st","st", "w"},
                                                    {"w2","cf","cf","cf","cf","cf","cf","cf","cf","cf", "w"},
                                                    {"w2","cf","st","t2","t1","cf","cf","st","t2","t1", "w"},
                                                    {"w2","cf","st","t4","t3","cf","cf","st","t4","t3", "w"},
                                                    {"w2","cf","cf","st","st","cf","cf","cf","st","st", "w"},
                                                    {"w2","cf","cf","cf","cf","cf","cf","cf","cf","cf", "w"},
                                                    {"w2","cf","st","t2","cf","cf","st","cf","st","cf", "w"},
                                                    {"w2","cf","st","t4","cf","b4","b3","cr","b2","b2","b1"},
                                                    {"w2","cf","cf","st","cf","b6","b5","cf","cf","si2","si1"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","si4","si3"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","si2","si1"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","si4","si3"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","cm2","cm1"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","cm4","cm3"},
                                                    {"w2","cf","cf","cf","cf","b6","b5","cf","cf","cf", "w"},
                                                    {"w2","w2","w2","w2","w2","w2","w2","w2","w2","w2","w2"} 
    };

    private string[,] office = new string[19,12] {  {"w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2"},
						                            {"w2", "cf", "ch", "cf", "bb1", "cf", "cf", "w", "cf", "ch", "cf", "bb1"},
						                            {"w2", "st", "co", "cf", "bb2", "cf", "cf", "w", "st", "co", "cf", "bb2"},
                        			                {"w2", "st", "t4", "cf", "bb3", "cf", "cf", "w", "st", "t4", "cf", "bb3"},
						                            {"w2", "cf", "cf", "cf", "w", "cf", "cf", "w", "cf", "cf", "cf", "w"},
                        			                {"w2", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                        			                {"w2", "w2", "w2", "w2", "w", "cf", "cf", "w", "w2", "w2", "w2", "w"},
                                                    {"w2", "cf", "ch", "cf", "bb1", "cf", "cf", "w", "cf", "ch", "cf", "bb1"},
                                                    {"w2", "st", "co", "cf", "bb2", "cf", "cf", "w", "st", "co", "cf", "bb2"},
                                                    {"w2", "st", "t4", "cf", "bb3", "cf", "cf", "w", "st", "t4", "cf", "bb3"},
                                                    {"w2", "cf", "cf", "cf", "w", "cf", "cf", "w", "cf", "cf", "cf", "w"},
                                                    {"w2", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                                                    {"w2", "w2", "w2", "w2", "w", "cf", "cf", "w", "w2", "w2", "w2", "w"},
                                                    {"w2", "cf", "ch", "cf", "bb1", "cf", "cf", "w", "cf", "ch", "cf", "bb1"},
                                                    {"w2", "st", "co", "cf", "bb2", "cf", "cf", "w", "st", "co", "cf","bb2"},
                                                    {"w2", "st", "t4", "cf", "bb3", "cf", "cf", "w", "st", "t4", "cf", "bb3"},
                                                    {"w2", "cf", "cf", "cf", "w", "cf", "cf", "w", "cf", "cf", "cf", "w"},
                                                    {"w2", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                                                    {"w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2", "w2"}
    };
    */

    public static string eetac = "11-41\n"
                + "w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2-w2\n"
                + "w2-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-w2\n"
                + "w2-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-f-w2\n"
                + "e1-ed-w2-f-f-w2-w2-w2-w2-w2-w2-e7-e8-e8-e8-e9-w2-f-f-w2-w2-w2-w2-w2-w2-e7-e8-e8-e8-e9-w2-f-f-w2-w2-w2-w2-w2-w2-ed-e4\n"
                + "no-no-w2-f-f-w-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w-f-f-f-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-w2-f-f-f-f-f-f-f-w2-no-no-no-no-no-w2-f-f-f-f-f-f-f-w2-no-no-no-no-no-w2-f-f-f-f-f-f-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-w2-f-f-w2-f-t2-t4-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-w2-f-f-w2-f-f-f-f-w2-no-no-no-no-no-no-no\n"
                + "no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-e1-e2-e3-e7-e8-e8-e8-e9-e4-no-no-no-no-no-no-no\n";

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

    public static string campus = "14 18\n"
        + "g g g g g g g g g g g g g g g g g g\n"
        + "g f f f f f f f f f f f f f f f f g\n"
        + "g f f f f f f f f f f f f f f f f g\n"
        + "g f g g g g g g f f g g g g g g f g\n"
        + "g f g ed 1 1 f f f f f f ed 1 1 g f g\n"
        + "g f g 1 1 1 f f f f f f 1 1 1 g f g\n"
        + "g f g g g g g g f f g g g g g g f g\n"
        + "g f g ed 1 1 f f f f g g g g g g g g\n"
        + "g f g 1 1 1 f f f f g g i o p g g g\n"
        + "g f g 1 1 1 f f f f g g k z n g g g\n"
        + "g f g g g g g g f f g g x c v g g g\n"
        + "g f f f f f f f f f g g g g g g g g\n"
        + "g f f f f f f f f f f f f f f f f g\n"
        + "g g g g g g g g g g g g g g g g g g\n";
    void LayoutObjectAtRandom(GameObject tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum + 1);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray;

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
        

        /*
        string str;
        level = "resa";
        
        switch (level)
        {
            case "lake":
                rows = lake.GetLength(1); columns = lake.GetLength(0); break;
            case "office":
                rows = office.GetLength(1); columns = office.GetLength(0); break;
            case "canteen":
                rows = canteen.GetLength(1); columns = canteen.GetLength(0); break;
            case "map":
                rows = map.GetLength(1); columns = map.GetLength(0); break;
            case "eetac":
                rows = eetac.GetLength(1); columns = eetac.GetLength(0); break;
            case "resa":
                rows = resa.GetLength(1); columns = resa.GetLength(0); break;
            default:
                rows = lake.GetLength(1); columns = lake.GetLength(0); break;
        }
        
        for (int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
        */
        gridPositions.Clear();
        string[] map = lake.Split('\n');
        string[] d = map[0].Split('-');
        int columns = Int32.Parse(d[1]);
        int rows = Int32.Parse(d[0]);
        for (int y = 1; y < rows + 1; y++)
        {
            int m = rows - y;
            string line = map[y];
            string[] p = line.Split('-');
            for (int x = 0; x < columns; x++)
            {
                switch (p[x])
                {
                    /*
                    switch (level) 
                    {
                        case "lake":
                            str = lake[x, y];  break;
                        case "office":
                            str = office[x, y];  break;
                        case "canteen":
                            str = canteen[x, y];  break;
                        case "map":
                            str = map[x, y]; break;
                        case "eetac":
                            str = eetac[x, y]; break;
                        case "resa":
                            str = resa[x, y]; break;
                        default:
                            str = lake[x, y];  break;
                    }

                    switch (str)
                    {*/

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
                        Instantiate(floor1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "l":
                        Instantiate(lake1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "z":
                        Instantiate(lake2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "g":
                        Instantiate(grass1, new Vector3(x, m, 0f), Quaternion.identity);
                        gridPositions.Add(new Vector3(x, m, 0f)); //To after add turtles randomly in map
                        break;
                    case "cf":
                        Instantiate(Canteen_floor, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "t1":
                        Instantiate(table1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "t2":
                        Instantiate(table2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "t3":
                        Instantiate(table3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "t4":
                        Instantiate(table4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "st":
                        Instantiate(stool, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b1":
                        Instantiate(bar1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b2":
                        Instantiate(bar2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b3":
                        Instantiate(bar3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b4":
                        Instantiate(bar4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b5":
                        Instantiate(bar5, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "b6":
                        Instantiate(bar6, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "si1":
                        Instantiate(sink1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "si2":
                        Instantiate(sink2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "si3":
                        Instantiate(sink3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "si4":
                        Instantiate(sink4, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "w":
                        Instantiate(wall, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "ch":
                        Instantiate(chair, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "cr":
                        Instantiate(cashRegister, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "cm1":
                        Instantiate(coffeeMachine1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "cm2":
                        Instantiate(coffeeMachine2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "cm3":
                        Instantiate(coffeeMachine3, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "cm4":
                        Instantiate(coffeeMachine4, new Vector3(x, m, 0f), Quaternion.identity); break;
		            case "w2":
                        Instantiate(wall2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "co":
                        Instantiate(computer, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "bb1":
                        Instantiate(blackBoard1, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "bb2":
                        Instantiate(blackBoard2, new Vector3(x, m, 0f), Quaternion.identity); break;
                    case "bb3":
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
                    default:
                        //str = ""; 
                        break;
                }
	        }
        }
        LayoutObjectAtRandom(turtle, 5, 10);
    }
}