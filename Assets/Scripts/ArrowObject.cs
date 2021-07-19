using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    private Rigidbody rig;
    private GameObject Bow;
    public practice practice;

    void Start()
    {
        Bow = GameObject.Find("Bow");
        transform.parent = GameObject.Find("RHand").transform;
        this.transform.localPosition = new Vector3(0, 0, 0);
        practice = GameObject.Find("PlayerController").GetComponent<practice>();
    }

    void Update()
    {
        transform.LookAt(Bow.transform.position);
        practice.Vel = transform.rotation;
    }
}