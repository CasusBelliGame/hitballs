using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody r;
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] public int IDNum;
    public Sprite pic;

    public int ballPower;
    
    public Information self;
    private void Awake() {
        r = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Wall"){
            Debug.Log("wall");
            DoLazyMove();
        }
        if(other.gameObject.tag == "Zemin"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Ball"){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ThrowBall"){
            if(self.ChangeMoney(other.gameObject.GetComponent<ThrowBall>().RewardMoney)){
                
            }
            self.ChangeXP(other.gameObject.GetComponent<ThrowBall>().xp);
            if(other.gameObject.GetComponent<ThrowBall>().ballPower <= ballPower){
                Destroy(gameObject);
                Destroy(other.gameObject);
            }else{
                Destroy(gameObject);

            }

        }
    }

    void DoLazyMove(){
        int RanSpeed = Random.Range(min,max);
        int x = Random.Range(0,3);
        int y = Random.Range(0,3);
        int z = Random.Range(0,3);
        r.AddForce(new Vector3(x-1,y-1,z-1) * RanSpeed);
    }





}
