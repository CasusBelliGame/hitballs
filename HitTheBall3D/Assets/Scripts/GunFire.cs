using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject[] InstantiatePoints;
    public Guns gun;
    public GameObject[] balls;
    public GameObject NextBall;
    [SerializeField] float speed;
    [SerializeField] float GunMovespeed;
    [SerializeField] float MaxGunMovespeed;
    [SerializeField] float timeWait;
    float timePassed;

    public Information self;
    public GameObject GameOverUI;

    int numberOfHeads;

    private void Start() {
        GameOverUI = GameObject.Find("GameOverUI");
        GameOverUI.SetActive(false);
    }
    private void Update() {
        timePassed += Time.deltaTime;
    }
    public void Fire(Vector3 point)
    {
        if(timePassed > timeWait* 2/gun.GetSpeed()){
            if(self.ChangeMoney(-1)){
                foreach (GameObject InstantiatePoint in InstantiatePoints)
                {
                    GameObject ball = Instantiate(NextBall,InstantiatePoint.transform.position,Quaternion.identity);
                    ball.GetComponent<Rigidbody>().AddForce(point*speed);
                    int i = UnityEngine.Random.Range(0,balls.Length);
                    NextBall = balls[i];
                }
            }else{
                return;
            }
            timePassed = 0;
        }

    }
    public void Move(int direction){
        if(direction == 1){
            transform.position = new Vector3(transform.position.x - Time.deltaTime*GunMovespeed,transform.position.y,transform.position.z);
        }
        if(direction == 2){
            transform.position = new Vector3(transform.position.x + Time.deltaTime*GunMovespeed,transform.position.y,transform.position.z);
        }
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ThrowBall"){
            if(self.ChangeHealth(-1)){
                Destroy(other.gameObject);
                return;
            }else{
                GameOver();
            }
        }
        if(other.gameObject.tag == "Zemin"){
            Debug.Log("Zemin");
            //GunMovespeed = MaxGunMovespeed*(other.gameObject.GetComponent<Zemin>().Health / other.gameObject.GetComponent<Zemin>().MaxHealth);
        }
        if(other.gameObject.tag == "Ball"){
            //Destroy(other.gameObject);
        }     
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }
}
