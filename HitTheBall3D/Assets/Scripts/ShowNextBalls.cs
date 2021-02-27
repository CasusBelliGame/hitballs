using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowNextBalls : MonoBehaviour
{
    public GameObject[] ballPics;
    public int HowManyBalls = 1;
    public GunFire gun;


    void Start()
    {
        gun = GameObject.FindWithTag("Gun").GetComponent<GunFire>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject ball in ballPics)
        {
            if(i < HowManyBalls){
                ball.SetActive(true);
                ball.GetComponent<Image>().sprite = gun.NextBall.GetComponent<Ball>().pic;

            }else{
                ball.SetActive(false);
            }
            i +=1;

        }
    }
}
