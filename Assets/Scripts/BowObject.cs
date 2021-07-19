using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowObject : MonoBehaviour
{
    [SerializeField] public GameObject GrabObject, RHand, ArrowPrefab;
    [SerializeField, Range(1, 10)] private float mag = 1;
    private bool Shot_Can = false;
    private Vector3 GrabPos;
    public ArrowObject Arrow;

    private Vector3 ArrowVel;

    private float ArrowPow;

    void Start()
    {
        GrabPos = GrabObject.transform.localPosition;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && Vector3.Distance(RHand.transform.position, transform.position) <= 0.1f)  
        {
            Shot_Can = true;
        }
        
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && Shot_Can == true) 
        {
            Shot_Can = false;
            Instantiate(ArrowPrefab);
            Vector3 ShotPos = RHand.transform.position;
            Debug.LogWarning(ShotPos);
            ArrowThrow(ShotPos);
            Arrow.GetComponent<ShotObject>().Shot(ArrowVel, ArrowPow);
        }
    }

    private void ArrowThrow(Vector3 pos)
    {
        ArrowVel = pos - transform.parent.position;
        ArrowPow = (GrabPos - pos).magnitude * mag;
        //Debug.LogWarning(ArrowVel);
        //Debug.LogWarning(ArrowPower);
    }
}
