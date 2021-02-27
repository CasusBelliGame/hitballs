using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float TimeBetweenIns;
    float timePassed = 0;
    [SerializeField] int difficulty;

    public Information self;
    [SerializeField] int StartingMoney = 100;
    public GameObject gunStartPoint;

    private void Awake() {
        Instantiate(self.GetGun(),gunStartPoint.transform.position,Quaternion.identity);
    }
    void Start()
    {
        self.SetMoney(StartingMoney);
        self.SetHealth(3);
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > TimeBetweenIns){
            BallThrower[] balls = FindObjectsOfType<BallThrower>();
            int random = Random.Range(0,balls.Length);
            balls[random].ThrowBall(Random.Range(0,difficulty));
            timePassed = 0f;
        }
    }
}
