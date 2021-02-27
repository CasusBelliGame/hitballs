using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    public GameObject gun;
    public GameObject FirePoint;
    public GameObject boru;
    Ray ray;
    RaycastHit hit;

    public float maxAngle = 160f;

    void Start()
    {
        gun = GameObject.FindWithTag("Gun");
        FirePoint = GameObject.Find("InsMidPoint");
    }

    // Update is called once per frame
    void Update()
    {

        if(GunMoving()) return;
        StartFire();

        

    }

    private void StartFire()
    {
        if(Input.GetMouseButtonDown(0)){

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                Vector2 deneme = new Vector2(FirePoint.transform.up.x,FirePoint.transform.up.y);
                Vector2 between = new Vector2(hit.point.x,hit.point.y);
                //if(Vector2.Angle(deneme,between) < maxAngle & Vector2.Angle(deneme,between)>20){
                    //FirePoint.transform.LookAt(hit.point);

                    gun.GetComponent<GunFire>().Fire(hit.point);
                //}else{
                //    Debug.Log(Vector3.Angle(FirePoint.transform.up,hit.point));
                //}

            }

        }
    }

    private bool GunMoving()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            if(Input.GetMouseButton(0)){
                if(EventSystem.current.currentSelectedGameObject == null) return false;
                if(EventSystem.current.currentSelectedGameObject.name == "SolOk"){
                    gun.GetComponent<GunFire>().Move(1);
                    return true;
                }
                if(EventSystem.current.currentSelectedGameObject.name == "SagOk"){
                    gun.GetComponent<GunFire>().Move(2);
                    return true;
                }
                if(EventSystem.current.currentSelectedGameObject.name == "PauseButton"){
                    return true;
                }
            }
            //return true;
        }
        return false;
    }





}
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if(Physics.Raycast(ray, out hit))
            //{
            //    if(hit.collider.name == "SolOk"){
            //        gun.transform.position = new Vector3(gun.transform.position.x-1,gun.transform.position.y,gun.transform.position.z);
            //    }
            //}