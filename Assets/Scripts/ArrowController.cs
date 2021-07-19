using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private int Magic = 0;
    public int magic
    {
        set;
        get;
    }

    public List<string> ArrowMode = new List<string> { "Arrow", "Fire", "Freeze", "Thunder", "Earth", "Water", "Wind" };
    public List<int> ArrowDamage = new List<int> { 50, 30, 30, 40, 40, 30, 0 };

    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)) 
        {
            Magic++;
            if (Magic == ArrowMode.Count)
            {
                Magic = 0;
            }
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            Magic--;
            if (Magic == -1)
            {
                Magic = ArrowMode.Count - 1;
            }
        }
    }
}
