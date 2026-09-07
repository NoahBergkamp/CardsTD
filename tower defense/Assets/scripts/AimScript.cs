using System;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class AimScript : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;
    public Transform shootPoint;
    public float tarPos;
    private float range = 5;

    
    public float AttackSpeed;


    void Start()
    {
        AttackSpeed = 0.5f; 
    }
    void Update()
    {
        rangeChecker();
       
    }

    void rangeChecker()
    {
        tarPos = Vector3.Distance(target.transform.position, transform.position);
        if(tarPos < 5)
        {
            targetEnemy();
        }
    }
    void targetEnemy()
    {
        Vector3 aimDir = (target.transform.position - transform.position).normalized ;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, aimDir);
        transform.rotation = rot;
        AttackSpeed -= Time.deltaTime;

        if (AttackSpeed <= 0)
        {
            AttackSpeed = 4;
            
            Instantiate(bullet, shootPoint.transform.position, transform.rotation);

        }

    }
}
 