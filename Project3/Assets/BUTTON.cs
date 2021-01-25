using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON : MonoBehaviour
{
        int contador = 0;
        public GameObject Panel;
    // Start is called before the first frame update
    void StartButton()
    {
       counter++;
       if (counter%2==1)
            Panel.gameObject.SetActive(true);
       else
            Panel.gameObject.SetActive(false);

        
    }
}
