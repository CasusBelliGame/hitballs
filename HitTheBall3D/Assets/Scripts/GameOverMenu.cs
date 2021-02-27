using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public Information self;

    public void OneMoreChance(){
        // Watch Ads
        Time.timeScale = 1;
        self.SetHealth(3);
        gameObject.SetActive(false);
    }
    public void MainMenu(){
        self.ChangeTotalMoney(self.GetMoney());
        SceneManager.LoadScene(0);

    }
}
