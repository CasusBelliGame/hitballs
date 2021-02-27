using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Guns", menuName = "Guns", order = 0)]
public class Guns : ScriptableObject {
    public Information self;
    [SerializeField] int GunMoney;
    [SerializeField] bool isEquipped;
    [SerializeField] int OrderNo;
    [SerializeField] bool isBuyed;
    [SerializeField] int minLevel;
    [SerializeField] int shootingSpeed;
    [SerializeField] int maxShootingSpeed;
    [SerializeField] int Head;
    [SerializeField] int maxHead;
    [SerializeField] int NumberBall;
    [SerializeField] int MaxNumberBall;
    [SerializeField] int armor;
    [SerializeField] int MaxArmor;
    [SerializeField] Sprite pic;
    [SerializeField] GameObject PrefabOfGun;

    public int[] UpgradeSpeedMoney;
    public int[] UpgradeHeadMoney;
    public int[] UpgradeBallMoney;
    public int[] UpgradeArmorMoney;

    public bool CheckEquipped(){
        return self.GetGun().GetComponent<GunFire>().gun == this;
    }
    public void Equip(){
        self.SetGun(this.PrefabOfGun);

        //self.GetGun().GetComponent<GunFire>().gun = this;
        isEquipped = true;

    }
    public void UnEquip(){
        isEquipped = false;
    }
    public Sprite GetPic(){
        return pic;
    }
    public bool GunBought(){
        return isBuyed;
    }
    public int GunCost(){
        return GunMoney;
    }
    public void BuyGun(){
        self.ChangeTotalMoney((-1)* GunMoney);
        isBuyed = true;
    }
    public int GetSpeed(){
        return shootingSpeed;
    }

    public bool CanIncreaseSpeed(){
        return maxShootingSpeed> shootingSpeed +1;
    }
    public bool CandecreaseSpeed(){
        return shootingSpeed-1 >= 1;
    }
    public int SpeedIncreaseMoney(){
        return UpgradeSpeedMoney[shootingSpeed-1];
    }
    public void IncreaseSpeed(){
        self.ChangeTotalMoney((-1)* SpeedIncreaseMoney());
        shootingSpeed +=1;
    }
    public void DecreaseSpeed(){
        self.ChangeTotalMoney(SpeedIncreaseMoney()/2);
        shootingSpeed -=1;
    } 

    public bool CanIncreaseHead(){
        return maxHead> Head +1;
    }
    public int HeadIncreaseMoney(){
        return UpgradeHeadMoney[Head-1];
    }
    public void IncreaseHead(){
        self.ChangeTotalMoney((-1)* HeadIncreaseMoney());
        Head +=1;
    }
    public bool CanDecreaseHead(){
        return Head-1 >= 1;
    }
    public void DecreaseHead(){
        self.ChangeTotalMoney(HeadIncreaseMoney()/2);
        Head -=1;
    }
    public bool CanIncreaseBall(){
        return MaxNumberBall> NumberBall +1;
    }
    public int BallIncreaseMoney(){
        return UpgradeBallMoney[NumberBall-1];
    }
    public void IncreaseBall(){
        self.ChangeTotalMoney((-1)* BallIncreaseMoney());
        Head +=1;
    }
    public bool CanDecreaseBall(){
        return NumberBall-1 >= 1;
    }
    public void DecreaseBall(){
        self.ChangeTotalMoney(BallIncreaseMoney()/2);
        NumberBall -=1;
    }
    public bool CanIncreaseArmor(){
        return MaxArmor > armor+1;
    }
    public int ArmorIncreaseMoney(){
        return UpgradeArmorMoney[armor-1];
    }
    public void IncreaseArmor(){
        self.ChangeTotalMoney((-1)* ArmorIncreaseMoney());
        armor +=1;
    }
    public bool CanDecreaseArmor(){
        return armor-1 >= 0;
    }
    public void DecreaseArmor(){
        self.ChangeTotalMoney(ArmorIncreaseMoney()/2);
        armor -=1;
    }

}