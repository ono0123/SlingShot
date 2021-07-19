using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VR_game : MonoBehaviour
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
        float Grab_Hand = Vector3.Distance(Hand.transform.position, StringGrab.transform.position);

        if (Grab_Hand >= 1f && OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) 
        {
            ArrowCreate(StringGrab.transform.position);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            Vector3 ShotPos = Hand.transform.position;
            ArrowShot(ShotPos);
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
        Instantiate(ShotArrow);
    }
}