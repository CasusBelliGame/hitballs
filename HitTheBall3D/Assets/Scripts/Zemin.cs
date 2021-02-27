using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin : MonoBehaviour
{
    public int Health = 5;

    public int MaxHealth = 5;
    public MarketObject self;

    public GameObject[] zeminler;
    GameObject currentZemin;
    public GameObject canvas;
    public GameObject HealthPlusButton;
    public gold Gold;

    private void Start() {
        //currentZemin = zeminler[Health-1];
        int i = 0;
        foreach (GameObject zemin in zeminler)
        {
            if(i!= Health-1){
                zemin.SetActive(false);
            }
            else{
                currentZemin = zemin;
                zemin.SetActive(true);
            }
            i+=1;
        }
        Gold = FindObjectOfType<gold>();
    }
    private void OnMouseOver() {
        canvas.SetActive(true);
        if(Health == MaxHealth){
             HealthPlusButton.SetActive(false);
        }else{
            HealthPlusButton.SetActive(true);
        }
    }
    public void BuyHealth(){
        if(self.HowManyWeHave >=1){
            Health+=1;
            self.HowManyWeHave -=1;
            int i = 0;
            foreach (GameObject zemin in zeminler)
            {
                if(i!= Health-1){
                    zemin.SetActive(false);
                }
                else{
                    currentZemin = zemin;
                    zemin.SetActive(true);
                }
                i+=1;
            }
        }
        else{
            Gold.PauseMenu();
            Gold.InGameMarketOpenUI();
            Time.timeScale = 0;
        }
    }
    private void OnMouseExit() {
        canvas.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ThrowBall"){
            Health -= 1;
            if(Health<=0){
                Destroy(gameObject);
                return;
            }
            int i = 0;
            foreach (GameObject zemin in zeminler)
            {
                if(i!= Health-1){
                    zemin.SetActive(false);
                }
                else{
                    currentZemin = zemin;
                    zemin.SetActive(true);
                }
                i+=1;
            }
            Destroy(other.gameObject);
        }
    }
}
