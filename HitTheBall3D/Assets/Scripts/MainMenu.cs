using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ShopUI;
    [SerializeField] Text gold;
    [SerializeField] Information self; 
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }
    public void OpenShop(){
        ShopUI.SetActive(true);
        ShopUI.GetComponent<Shop>().ChangeCard();
    }

    private void Update() {
        gold.text = self.GetTotalMoney().ToString();
    }
    
}
