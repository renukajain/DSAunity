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

    public int columns = 18;
    public int rows = 10;

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
    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.

    private List <Vector3> gridPositions = new List <Vector3> ();    //A list of possible locations to place tiles.
    private string[,] lake = new string[18, 10] { {"f", "f", "f", "f", "f", "f", "f", "f", "f", "f"},
                                                 {"f", "g", "g", "g", "g", "g", "g", "g", "g", "f"},
                                                 {"f", "g", "x", "k", "k", "k", "k", "i", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "z", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "z", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "l", "l", "o", "g", "f"},
                                                 {"f", "g", "c", "l", "l", "z", "l", "o", "g", "f"},
                                                 {"f", "g", "v", "n", "n", "n", "n", "p", "g", "f"},
                                                 {"f", "g", "g", "g", "g", "g", "g", "g", "g", "f"},
                                                 {"f", "f", "f", "f", "f", "f", "f", "f", "f", "f"} };

    private string[,] canteen = new string[18,10] { {"cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                                                    {"cf", "st", "t2", "t1", "cf", "cf", "st", "t2", "t1", "w"},
                                                    {"cf", "st", "t4", "t3", "cf", "cf", "st", "t4", "t3", "w"},
                                                    {"cf", "cf", "st", "st", "cf", "cf", "cf", "st", "st", "w"},
                                                    {"cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                                                    {"cf", "st", "t2", "t1", "cf", "cf", "st", "t2", "t1", "w"},
                                                    {"cf", "st", "t4", "t3", "cf", "cf", "st", "t4", "t3", "w"},
                                                    {"cf", "cf", "st", "st", "cf", "cf", "cf", "st", "st", "w"},
                                                    {"cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "cf", "w"},
                                                    {"cf", "st", "t2", "cf", "cf", "st", "cf", "st", "cf", "w"},
                                                    {"cf", "st", "t4", "cf", "b4", "b3", "cr", "b2", "b2", "b1"},
                                                    {"cf", "cf", "st","cf", "b6", "b5", "cf", "cf", "si2", "si1"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "si4", "si3"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "si2", "si1"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "si4", "si3"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "cm2", "cm1"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "cm4", "cm3"},
                                                    {"cf", "cf", "cf", "cf", "b6", "b5", "cf", "cf", "cf", "w"} };


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene (string level)
    {
	    //setupMap();
        string str;
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
		        str = canteen[x,y];
                switch (str)
                {
                    case "i":
                        Instantiate(lakeBorder1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "o":
                        Instantiate(lakeBorder2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "p":
                        Instantiate(lakeBorder3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "k":
                        Instantiate(lakeBorder4, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "n":
                        Instantiate(lakeBorder6, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "x":
                        Instantiate(lakeBorder7, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "c":
                        Instantiate(lakeBorder8, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "v":
                        Instantiate(lakeBorder9, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "f":
                        Instantiate(floor1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "l":
                        Instantiate(lake1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "z":
                        Instantiate(lake2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "g":
                        Instantiate(grass1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cf":
                        Instantiate(Canteen_floor, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "t1":
                        Instantiate(table1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "t2":
                        Instantiate(table2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "t3":
                        Instantiate(table3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "t4":
                        Instantiate(table4, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "st":
                        Instantiate(stool, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b1":
                        Instantiate(bar1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b2":
                        Instantiate(bar2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b3":
                        Instantiate(bar3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b4":
                        Instantiate(bar4, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b5":
                        Instantiate(bar5, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "b6":
                        Instantiate(bar6, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "si1":
                        Instantiate(sink1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "si2":
                        Instantiate(sink2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "si3":
                        Instantiate(sink3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "si4":
                        Instantiate(sink4, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "w":
                        Instantiate(wall, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "ch":
                        Instantiate(chair, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cr":
                        Instantiate(cashRegister, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cm1":
                        Instantiate(coffeeMachine1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cm2":
                        Instantiate(coffeeMachine2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cm3":
                        Instantiate(coffeeMachine3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "cm4":
                        Instantiate(coffeeMachine4, new Vector3(x, y, 0f), Quaternion.identity); break;
                    default:
                        str = ""; break;
                }
	    }
        }
    }
}