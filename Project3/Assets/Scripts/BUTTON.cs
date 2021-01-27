using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUTTON : MonoBehaviour
{
    
    public Player player;
    int counter = 0;
    public GameObject Panel;
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



    // Start is called before the first frame update
    public void TriggerInventory()
    {
        Inventory I = GameManager.instanceinv;
        counter++;
        if (counter % 2 == 1)
        {
            Text0.text = "Turtle: " + I.GetTurtle().ToString();
            Text1.text = "Coffee: " + I.GetCoffee().ToString();
            Text2.text = "RedBull: " + I.GetRedBull().ToString();
            Text3.text = "Pills: " + I.GetPills().ToString();
            Text4.text = "Calculator: " + I.GetCalculator().ToString();
            Text5.text = "Rule: " + I.GetRule().ToString();
            Text6.text = "Compass: " + I.GetCompass().ToString();
            Text7.text = "Pencil: " + I.GetPencil().ToString();
            Text8.text = "Glasses: " + I.GetGlasses().ToString();
            Text9.text = "USB: " + I.GetUsb().ToString();
            Text10.text = "Book: " + I.GetBook().ToString();
            Text11.text = "Puzzle: " + I.GetPuzzle().ToString();
            Text12.text = "CheatSheet: " + I.GetCheat().ToString();

            Panel.gameObject.SetActive(true);
        }
        else
            Panel.gameObject.SetActive(false);
    }



}
