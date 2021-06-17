using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    private Rigidbody rig;
    private Vector3 ArrowPos = new Vector3(0, -0.02f, 0);
    private Vector3 ArrowEuler = new Vector3(-90, 0, 0);

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        transform.parent = GameObject.Find("RightControllerAnchor").transform;
        transform.localPosition = ArrowPos;
        transform.localEulerAngles = ArrowEuler;
    }

    void Update()
    {
        
    }

    public void Shot(Vector3 ArrowVel, float ArrowPower)
    {
        rig.useGravity = true;
        rig.isKinematic = false;
        rig.AddForce(ArrowVel * ArrowPower, ForceMode.Impulse);
    }
}
