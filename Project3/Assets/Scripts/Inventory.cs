using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public string ID;
    public int turtleQuantity;
    public int coffQuantity;
    public int redBullQuantity;
    public int pillsQuantity;
    public int calculatorQuantity;
    public int ruleQuantity;
    public int compassQuantity;
    public int pencilQuantity;
    public int glassesQuantity;
    public int puzzleQuantity;
    public int bookQuantity;
    public int usbQuantity;
    public int cheatQuantity;


    public void SetID(string text){
        this.ID=text;
    }
    public void SetTurtle(int q){
        this.turtleQuantity=q;
    }
    public void SetCoff(int q){
        this.coffQuantity=q;
    }
    public void SetRedBull(int q){
        this.redBullQuantity=q;
    }
}

