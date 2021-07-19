using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    [SerializeField] GameObject Bow, Sword, ArrowPrefab;
    private bool Bow_or_Sword = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstick))
        {
            ChangeWeapon();
        }
    }

    private void ChangeWeapon()
    {
        Bow_or_Sword = !Bow_or_Sword;

        Bow.gameObject.SetActive(Bow_or_Sword);
        Sword.gameObject.SetActive(!Bow_or_Sword);

        if (!Bow_or_Sword) 
        {
            Destroy(GameObject.Find("Arrow"));
        }
    }
}
