using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    private BowString Bow;

    void Start()
    {
        Bow = new BowString();
    }

    void Update()
    {

    }

    public void CreateArrow()
    {
        GameObject ArrowObj = (GameObject)Resources.Load("Arrow");
        Instantiate(ArrowObj, new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 0));
        ArrowObj.transform.localPosition = new Vector3(0, 0, 0);
    }
}