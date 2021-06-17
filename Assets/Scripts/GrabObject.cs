using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private GameObject RHand, ArrowPrefab;
    [SerializeField, Range(1, 10)] private float mag = 1;
    private bool Shot_Can = false;
    private Vector3 GrabPos, ShotPos;
    private ArrowObject Arrow;

    public Vector3 ArrowVel
    {
        protected set;
        get;
    }

    public float ArrowPower
    {
        protected set;
        get;
    }

    void Start()
    {
        GrabPos = transform.localPosition;
    }

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && Shot_Can == true) 
        {
            ShotPos = RHand.transform.position;
            ArrowThrow(transform.localPosition);
            Arrow.Shot(ArrowVel, ArrowPower);
            Shot_Can = false;
        }
    }

    private void ArrowThrow(Vector3 pos)
    {
        ArrowVel = pos - transform.parent.localPosition;
        ArrowPower = (GrabPos - ShotPos).magnitude * mag;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Hand" && OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) 
        {
            Instantiate(ArrowPrefab);
            Shot_Can = true;
        }
    }
}
