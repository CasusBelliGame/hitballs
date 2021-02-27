using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public GameObject mid;
    void Update()
    {
        transform.rotation = mid.transform.rotation;
    }
}
