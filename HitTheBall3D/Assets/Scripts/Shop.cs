using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    public Information self;
    public Guns[] guns;
    public int order = 0;
    public Image kartPic;
    public GameObject SagOk;
    public GameObject SolOk;
    public GameObject CardCloser;
    public GameObject EquipButton;
    public Text BuyShopText;

    public GameObject speedPlusButton;
    public GameObject speedMinusButton;
    public TMP_Text speedIncreaseMoney;
    public TMP_Text speedDecreaseMoney;
    public GameObject HeadPlusButton;
    public GameObject HeadMinusButton;
    public TMP_Text HeadIncreaseMoney;
    public TMP_Text HeadDecreaseMoney;
    public GameObject BallPlusButton;
    public GameObject BallMinusButton;
    public TMP_Text BallIncreaseMoney;
    public TMP_Text BallDecreaseMoney;
    public GameObject ArmorPlusButton;
    public GameObject ArmorMinusButton;
    public TMP_Text ArmorIncreaseMoney;
    public TMP_Text ArmorDecreaseMoney;
    public void ChangeCard(){
        kartPic.sprite = guns[order].GetPic();
        if(guns.Length < order+2){
            SagOk.SetActive(false);
        }else{
            SagOk.SetActive(true);
        }
        if(order == 0){
            SolOk.SetActive(false);
        }else{
            SolOk.SetActive(true);
        }
        CheckStatus();




    }

    public void CheckStatus(){

        if(guns[order].GunBought()){
            CardCloser.SetActive(false);
            if(guns[order].CheckEquipped()){
                EquipButton.SetActive(false);
            }else{
                EquipButton.SetActive(true);
            }
        }else{
            CardCloser.SetActive(true);
            BuyShopText.text = guns[order].GunCost().ToString();
        }
        if(!guns[order].CanIncreaseSpeed()){
            speedPlusButton.SetActive(false);
            speedIncreaseMoney.enabled = false;
        }else{
            speedPlusButton.SetActive(true);
            speedIncreaseMoney.text = guns[order].SpeedIncreaseMoney().ToString();
        }
        if(!guns[order].CanIncreaseHead()){
            HeadPlusButton.SetActive(false);
            HeadIncreaseMoney.enabled = false;
        }else{
            HeadPlusButton.SetActive(true);
            speedIncreaseMoney.text = guns[order].HeadIncreaseMoney().ToString();
        }
        if(!guns[order].CanIncreaseBall()){
            BallPlusButton.SetActive(false);
            BallIncreaseMoney.enabled = false;
        }else{
            BallPlusButton.SetActive(true);
            speedIncreaseMoney.text = guns[order].BallIncreaseMoney().ToString();
        }
        if(!guns[order].CanIncreaseArmor()){
            ArmorPlusButton.SetActive(false);
            ArmorIncreaseMoney.enabled = false;
        }else{
            ArmorPlusButton.SetActive(true);
            speedIncreaseMoney.text = guns[order].ArmorIncreaseMoney().ToString();
        }

        /////////////****************************
        if(!guns[order].CandecreaseSpeed()){
            speedMinusButton.SetActive(false);
            speedDecreaseMoney.enabled = false;
        }else{
            speedMinusButton.SetActive(true);
            int i = guns[order].SpeedIncreaseMoney()*(1/2);
            speedDecreaseMoney.text = i.ToString();
        }
        if(!guns[order].CanDecreaseHead()){
            HeadMinusButton.SetActive(false);
            HeadDecreaseMoney.enabled = false;
        }else{
            HeadMinusButton.SetActive(true);
            int i = guns[order].HeadIncreaseMoney()*(1/2);
            HeadDecreaseMoney.text = i.ToString();
        }
        if(!guns[order].CanDecreaseBall()){
            BallMinusButton.SetActive(false);
            BallDecreaseMoney.enabled = false;
        }else{
            BallMinusButton.SetActive(true);
            int i = guns[order].BallIncreaseMoney()*(1/2);
            BallDecreaseMoney.text = i.ToString();
        }
        if(!guns[order].CanDecreaseArmor()){
            ArmorMinusButton.SetActive(false);
            ArmorDecreaseMoney.enabled = false;
        }else{
            speedMinusButton.SetActive(true);
            int i = guns[order].ArmorIncreaseMoney()*(1/2);
            ArmorDecreaseMoney.text = i.ToString();
        }
    }

    public void SagOkButton(){
        order +=1;
        ChangeCard();
    }
    public void SolOkButton(){
        order -=1;
        ChangeCard();
    }

    public void IncreaseSpeed(){
        if(self.GetTotalMoney() >= guns[order].SpeedIncreaseMoney()){
            guns[order].IncreaseSpeed();
        }
    }
    public void DecreaseSpeed(){
        guns[order].DecreaseSpeed();
    } 

    public void IncreaseHead(){
        if(self.GetTotalMoney() >= guns[order].HeadIncreaseMoney()){
            guns[order].IncreaseHead();
        }
    }
    public void DecreaseHead(){
        guns[order].DecreaseHead();
    } 

    public void IncreaseMaxBall(){
        if(self.GetTotalMoney() >= guns[order].BallIncreaseMoney()){
            guns[order].IncreaseBall();
        }
    }
    public void DecreaseMaxBall(){
        guns[order].DecreaseBall();
    } 
    public void IncreaseMaxArmor(){
        if(self.GetTotalMoney() >= guns[order].ArmorIncreaseMoney()){
            guns[order].IncreaseArmor();
        }
    }
    public void DecreaseMaxArmor(){
        guns[order].DecreaseArmor();
    } 
    public void CloseShopUI(){
        gameObject.SetActive(false);
    }

    public void BuyGun(){
        if(self.GetTotalMoney() > guns[order].GunCost()){
            guns[order].BuyGun();
            CheckStatus();
        }
    }

    public void EquipWeapon(){
        guns[order].Equip();
        CheckStatus();
        int i =0;
        foreach (Guns gun in guns)
        {
            if(i != order){
                gun.UnEquip();
            }
            i+=1;
        }
    }


}
