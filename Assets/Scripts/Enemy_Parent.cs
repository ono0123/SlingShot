using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Parent : MonoBehaviour
{
    public int HP, AttackPow;

    //private enum State_Type
    //{
    //    Fire,
    //    Freeze,
    //    Thunder,
    //    Earth,
    //    Water,
    //    Wind
    //}

    protected void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void EnemyAttack()
    {

    }

    protected virtual void Damage()
    {

    }

    protected virtual void Fire_Debuf()
    {

    }

    protected virtual void Freeze_Debuf()
    {

    }

    protected virtual void Thunder_Debuf()
    {

    }

    protected virtual void Earth_Debuf()
    {

    }

    protected virtual void Water_Debuf()
    {

    }

    protected virtual void Wind_Debuf()
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        HP -= col.gameObject.GetComponent<ShotObject>().Damage;

        if (col.gameObject.tag == "Fire")
        {
            Fire_Debuf();
        }
        if (col.gameObject.tag == "Freeze")
        {
            Freeze_Debuf();
        }
        if (col.gameObject.tag == "Thunder")
        {
            Thunder_Debuf();
        }
        if (col.gameObject.tag == "Earth")
        {
            Earth_Debuf();
        }
        if (col.gameObject.tag == "Water")
        {
            Water_Debuf();
        }
        if (col.gameObject.tag == "Wind")
        {
            Wind_Debuf();
        }
    }
}
