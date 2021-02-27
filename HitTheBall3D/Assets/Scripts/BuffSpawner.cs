using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] buffs;
    public GameObject[] deBuffs;

    [SerializeField] float timeBetweenSpawns;
    float timePassed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= timeBetweenSpawns){
            timePassed = 0;
            int i = Random.Range(1,11);
            if(i<5){
                Instantiate(buffs[Random.Range(0,buffs.Length)],transform.position,Quaternion.identity);
                timeBetweenSpawns += 1;
            }else if(i >8){
                Instantiate(deBuffs[Random.Range(0,deBuffs.Length)],transform.position,Quaternion.identity);
                timeBetweenSpawns -=1;
            }else{
                timeBetweenSpawns -= 0.5f;
            }
        }
    }
}
