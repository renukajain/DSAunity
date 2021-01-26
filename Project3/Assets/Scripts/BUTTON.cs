using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUTTON : MonoBehaviour
{
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
       counter++;
       if (counter%2==1){
            Text0.text = "Turtle: " + Inventory.instance.turtleQuantity.ToString();
            Text1.text = "Coffee: " + Inventory.instance.coffQuantity.ToString();
            Text2.text = "RedBull: " + Inventory.instance.redBullQuantity.ToString();
            Text3.text = "Pills: " + Inventory.instance.pillsQuantity.ToString();
            Text4.text = "Calculator: " + Inventory.instance.calculatorQuantity.ToString();
            Text5.text = "Rule: " + Inventory.instance.ruleQuantity.ToString();
            Text6.text ="Compass: "+ Inventory.instance.compassQuantity.ToString();
            Text7.text ="Pencil: " + Inventory.instance.pencilQuantity.ToString();
            Text8.text ="Glasses: "+ Inventory.instance.glassesQuantity.ToString();
            Text9.text ="USB: "+ Inventory.instance.usbQuantity.ToString();
            Text10.text ="Book: " + Inventory.instance.bookQuantity.ToString();
            Text11.text ="Puzzle: " + Inventory.instance.puzzleQuantity.ToString();
            Text12.text ="CheatSheet: " + Inventory.instance.cheatQuantity.ToString();
            Panel.gameObject.SetActive(true);

       }
       else
            Panel.gameObject.SetActive(false);

        
    }
}
