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

    public int columns = 10;
    public int rows = 10;

    public GameObject floor1; //f
    public GameObject floor2; //d
    public GameObject floor3; //s
    public GameObject lake1; //l
    public GameObject lake2; //z
    public GameObject lake3; //m
    public GameObject grass1; //g
    public GameObject grass2; //t
    public GameObject grass3; //y
    public GameObject lakeBorder1; //i
    public GameObject lakeBorder2; //o
    public GameObject lakeBorder3; //p
    public GameObject lakeBorder4; //k
    public GameObject lakeBorder6; //n
    public GameObject lakeBorder7; //x
    public GameObject lakeBorder8; //c
    public GameObject lakeBorder9; //v

    private Transform boardHolder; //A variable to store a reference to the transform of our Board object.

    private List <Vector3> gridPositions = new List <Vector3> ();    //A list of possible locations to place tiles.
    private string[,] map = new string[10, 10] { {"f", "f", "f", "f", "f", "f", "f", "f", "f", "f"},
                                                 {"f", "g", "g", "y", "y", "t", "g", "g", "g", "f"},
                                                 {"f", "t", "x", "k", "k", "k", "k", "i", "g", "f"},
                                                 {"s", "g", "c", "l", "l", "l", "z", "o", "y", "s"},
                                                 {"s", "g", "c", "l", "z", "m", "l", "o", "g", "s"},
                                                 {"d", "g", "c", "l", "l", "l", "l", "o", "t", "s"},
                                                 {"d", "t", "c", "l", "m", "l", "l", "o", "g", "f"},
                                                 {"s", "y", "v", "n", "n", "n", "n", "p", "g", "d"},
                                                 {"f", "g", "y", "t", "g", "g", "g", "g", "g", "f"},
                                                 {"d", "d", "s", "s", "s", "s", "d", "f", "f", "f"} };



    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene (int level)
    {
        string str;
        for(int x = 0; x < columns; x++)
        {
            for(int y =0; y < rows; y++)
            {

                str = map[x,y];
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
                    case "d":
                        Instantiate(floor2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "s":
                        Instantiate(floor3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "l":
                        Instantiate(lake1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "z":
                        Instantiate(lake2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "m":
                        Instantiate(lake3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "g":
                        Instantiate(grass1, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "t":
                        Instantiate(grass2, new Vector3(x, y, 0f), Quaternion.identity); break;
                    case "y":
                        Instantiate(grass3, new Vector3(x, y, 0f), Quaternion.identity); break;
                    default:
                        str = ""; break;
                }
//
//                if (str == "i")
//                    Instantiate (lakeBorder1, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "o")
//                    Instantiate (lakeBorder2, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "p")
//                    Instantiate (lakeBorder3, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "k")
//                    Instantiate (lakeBorder4, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "n")
//                    Instantiate (lakeBorder6, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "x")
//                    Instantiate (lakeBorder7, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "c")
//                    Instantiate (lakeBorder8, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "v")
//                    Instantiate (lakeBorder9, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "f")
//                    Instantiate (floor1, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "d")
//                    Instantiate (floor2, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "s")
//                    Instantiate (floor3, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "l")
//                    Instantiate (lake1, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "z")
//                    Instantiate (lake2, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "m")
//                    Instantiate (lake3, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "g")
//                    Instantiate (grass1, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "t")
//                    Instantiate (grass2, new Vector3 (x, y, 0f), Quaternion.identity);
//                else if (str == "y")
//                    Instantiate (grass3, new Vector3 (x, y, 0f), Quaternion.identity);
//                else
//                    str ="";
//
            }
        }

    }

}