using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class practice : MonoBehaviour
{
    [SerializeField] public GameObject Bow, Hand, Arrow, ShotArrow, StringGrab;
    private int Space_Count = 0;
    private GameObject CreateArrow;
    private Quaternion vel;
    public Quaternion Vel
    {
        get { return vel; }
        set { vel = value; }
    }

    private Vector3 ArrowVel;
    public Vector3 Arrowvel
    {
        get { return ArrowVel; }
        set { ArrowVel = value; }
    }

    private float ArrowPow;
    public float Arrowpow
    {
        get { return ArrowPow; }
        set { ArrowPow = value; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Space_Count++;
            if (Space_Count % 2 == 1) 
            {
                ArrowCreate(StringGrab.transform.position);
            }
            else
            {
                Vector3 ShotPos = Hand.transform.position;
                ArrowShot(ShotPos);
            }
        }
    }

    private void ArrowCreate(Vector3 pos)
    {
        CreateArrow = Instantiate(Arrow, pos, Quaternion.identity);
    }

    private void ArrowShot(Vector3 ShotPos)
    {
        Destroy(CreateArrow);
        ArrowVel = Bow.transform.position - ShotPos;
        ArrowPow = (StringGrab.transform.position - ShotPos).magnitude;
        //Debug.LogWarning(ArrowVel);
        //Debug.LogWarning(ArrowPower);
        Instantiate(ShotArrow);
    }
}