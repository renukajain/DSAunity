using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON : MonoBehaviour
{
    int counter = 0;
    public GameObject Panel;
    // Start is called before the first frame update
    public void TriggerInventory()
    {
       counter++;
       if (counter%2==1)
            Panel.gameObject.SetActive(true);
       else
            Panel.gameObject.SetActive(false);

        
    }
}
