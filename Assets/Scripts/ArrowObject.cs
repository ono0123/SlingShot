using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    private BowString Bow;
    private Rigidbody rig;

    void Start()
    { 
        rig = GetComponent<Rigidbody>();
        Bow = new BowString();
        transform.parent = GameObject.Find("CustomHandRight").transform;
    }

    void Update()
    {
        
    }

    public void ArrowShot(Vector3 ArrowVel, float ArrowPower)
    {
        rig.isKinematic = false;
        rig.useGravity = true;
        rig.AddForce(ArrowVel * ArrowPower, ForceMode.Impulse);
    }

    private void ArrowParentChange()
    {

    }
}