using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class gold : MonoBehaviour
{
    public TMP_Text goldText;
    public GameObject[] Healths;
    public Information self;
    public GameObject PauseMenuUI;
    public GameObject InGameMarketOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = self.GetMoney().ToString();
        ChangeHealth(self.GetHealth());

    }

    public void ChangeHealth(int amount){
        int i = 0;
        foreach (GameObject health in Healths)
        {
            if(i<amount){
                health.SetActive(true);
            }
            else{
                health.SetActive(false);
            }
            i+=1;
        }
    }

    public void PauseMenu(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;     
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
        self.ChangeTotalMoney(self.GetMoney());
    }
    public void InGameMarketOpenUI(){
        InGameMarketOpen.SetActive(true);
    }
        public void InGameMarketClose(){
        InGameMarketOpen.SetActive(false);
    }
}
