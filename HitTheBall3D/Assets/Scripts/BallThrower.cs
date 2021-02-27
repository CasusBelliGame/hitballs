using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    [SerializeField] Transform InstantiatePoint;
    public void ThrowBall(int whichBall){
        GameObject ball = Instantiate(balls[whichBall],InstantiatePoint.position,Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(transform.forward*10*ball.GetComponent<ThrowBall>().speed);
    }
}
