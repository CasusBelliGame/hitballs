using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketBuy : MonoBehaviour
{
    public Image pic;
    public Text cost;
    public Button buyButton;
    [SerializeField] Information self;
    [SerializeField] MarketObject product;

    void Start()
    {
        pic.sprite = product.pic;
        cost.text = product.Money.ToString();

    }

    public void Buy(){
        if(self.GetMoney() >= product.Money){
            
            self.ChangeMoney((-1)*product.Money);

        }
    }
}
