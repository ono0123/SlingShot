using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour
{
    public GameObject Score_Object = null;
    private int ScorePoint = 0;
    public int Score_Point
    {
        set;
        get;
    }

    void Start()
    {
    }

    void Update()
    {
        Text score = Score_Object.GetComponent<Text>();
        score.text = "SCORE:" + ScorePoint;
    }
}
