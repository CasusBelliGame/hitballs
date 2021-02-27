using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    int direction;
    Rigidbody r;
    [SerializeField] public float speed;
    [SerializeField] float slowDown;
    [SerializeField] int min = 1;
    [SerializeField] int max = 2;
    [SerializeField] public int IDNum;
    public int ballPower;

    [SerializeField] public int xp;
    public int RewardMoney;

    void Start()
    {
        direction = Random.Range(0,2);
        r = GetComponent<Rigidbody>();
    }

    void Update()
    {
        r.AddForce(Vector3.up*slowDown*Time.deltaTime);
        if(direction == 1){
            r.AddForce(Vector3.right * speed*Time.deltaTime);
        }else{
            r.AddForce(Vector3.left * speed*Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Wall"){
            if(direction ==1){
                direction = 0;
            }else{
                direction = 1;
            }
            //DoLazyMove();
        }
        if(other.gameObject.tag == "Ball"){
            DoLazyMove();
        }
    }

    void DoLazyMove(){
        int RanSpeed = Random.Range(min, max);
        int x = Random.Range(0,3);
        int y = Random.Range(0,3);
        int z = Random.Range(0,3);
        r.AddForce(new Vector3(x-1,y-1,z-1) * RanSpeed);
    }
}
