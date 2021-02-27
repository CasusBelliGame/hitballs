using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    Gyroscope mover;
    bool isEnabled;
    Rigidbody rb;
    void Start()
    {
        isEnabled = EnableGyro();
        rb = GetComponent<Rigidbody>();
    }

    bool EnableGyro(){
        if(SystemInfo.supportsGyroscope){
            mover = Input.gyro;
            mover.enabled = true;
            return true;
        }
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnabled) return;
        //Quaternion dev = DeviceOrientation.Get();
        //rb.AddForce(Input.gyro.attitude .x * new Vector3(1,0,0));
    }
}
