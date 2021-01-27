using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBye : MonoBehaviour
{
    public GameObject ShopPanel;
    public Button button;
    public void CloseShop() {
        ShopPanel.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }
}
