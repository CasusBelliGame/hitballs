using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMover : MonoBehaviour
{
    public GameObject gun;

    void Update()
    {
        
    }

    public void MoveGunLeft(){
        gun.transform.position = new Vector3(gun.transform.position.x-1,gun.transform.position.y,gun.transform.position.z);
    }
}
