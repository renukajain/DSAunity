using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    int counter;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        counter++;
        if (counter%2==1)
            Panel.gameObject.SetActive(false);
        else
            Panel.gameObject.SetActive(true);
        
    }


}
