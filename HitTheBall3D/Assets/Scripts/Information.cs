using UnityEngine;

[CreateAssetMenu(fileName = "Information", menuName = "Information", order = 0)]
public class Information : ScriptableObject {
    [SerializeField] [Range(1,5)]int Health;
    [SerializeField] int Money;
    [SerializeField] int totalMoney;
    [SerializeField] int PlayersLevel;
    [SerializeField] int PlayersXP;
    [SerializeField] int[] xpToPassLevels;
    [SerializeField] GameObject currentGun;

    public GameObject GetGun(){
        return currentGun;
    }
    public void SetGun(GameObject gun){
        currentGun = gun;
    }

    public int GetHealth(){
        return Health;
    }
    public void SetHealth(int amount){
         Health = amount;
    }
    public bool ChangeHealth(int amount){
        Health += amount;
        if(Health <=0) return false;
        return true;
    }
    public int GetMoney(){
        return Money;
    }
    public void SetMoney(int amount){
        Money = amount;
    }
    public bool ChangeMoney(int amount){
        if(Money + amount < 0) return false;
        if(Money + amount >= 0){
            Money += amount;
            return true;
        }
        return false;

    }
    public int GetTotalMoney(){
        return totalMoney;
    }
    public void ChangeTotalMoney(int amount){
        totalMoney += amount;
    }

    public void ChangeXP(int amount){
        PlayersXP += amount;
        if(PlayersXP >= xpToPassLevels[PlayersLevel]){
            PlayersXP = PlayersXP - xpToPassLevels[PlayersLevel];
            PlayersLevel +=1;
        }
    }




}