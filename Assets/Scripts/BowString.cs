using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowString : MonoBehaviour
{
    [SerializeField] GameObject StringUp;
    [SerializeField] GameObject StringBottom;
    [SerializeField] GameObject HandPosObj;
    [SerializeField] [Range(1f, 10f)] float mag = 1;

    private Reload re;
    private ArrowObject arrow;

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

    public bool Draw
    {
        protected set;
        get;
    }

    void Start()
    {
        re = GetComponent<Reload>();
        arrow = GetComponent<ArrowObject>();
    }

    void Update()
    {
        String();
    }

    private void String()
    {
        //弓の弦をrayとして扱う
        //弓の弦の付け根へrayを出す
        Ray Upray = new Ray(transform.position, StringUp.transform.position);
        Ray Bottomray = new Ray(transform.position, StringBottom.transform.position);
        //掴んでいる地点から弦の付け根への向き
        Vector3 UpVel = StringUp.transform.position - transform.position;
        Vector3 BottomVel = StringBottom.transform.position - transform.position;
        //rayの可視化
        Debug.DrawRay(Upray.origin, UpVel, Color.black);
        Debug.DrawRay(Bottomray.origin, BottomVel, Color.black);
    }

    private void StringMove(Vector3 HandPos)
    {
        if (transform.localPosition.y >= 0.14f && transform.localPosition.y <= 0.9f)
        {
            transform.localPosition = new Vector3(0, HandPosObj.transform.position.y, 0);
        }
        else if (transform.localPosition.y < 0.14) 
        {
            transform.localPosition = new Vector3(0, 0.14f, 0);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0.9f, 0);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            ArrowThrow(transform.localPosition);
        }
    }

    private void ArrowThrow(Vector3 GrabPos)
    {
        ArrowVel = GrabPos - HandPosObj.transform.position;
        ArrowPower = ArrowVel.magnitude * mag;
    }

    private void OnTriggerStay(Collider Hand)
    {
        if (Hand.tag == "hand" && OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) 
        {

            HandPosObj.transform.position = Hand.transform.position;
            StringMove(Hand.transform.position);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            arrow.ArrowShot(ArrowVel, ArrowPower);
            re.CreateArrow();
        }
    }
}
