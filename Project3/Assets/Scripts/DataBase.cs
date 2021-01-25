using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static DataBase handler;
    public int num;
    public List<Inventory> I;


    private void Awake()
    {
        if (handler==null){
            handler = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(this);
        }
    }


    public void addItems(string name){

    }
}
