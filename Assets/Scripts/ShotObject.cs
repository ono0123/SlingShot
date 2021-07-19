using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObject : MonoBehaviour
{
    private Rigidbody rig;
    public practice practice;
    public ArrowController ArrowController;
    public int Damage;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        practice = GameObject.Find("GameController").GetComponent<practice>();
        transform.position = GameObject.Find("RHand").transform.position;
        transform.rotation = practice.Vel;
        Shot(practice.Arrowvel, practice.Arrowpow);
        Invoke("This_Delete", 5f);
    }

    void Update()
    {
        ArrowController = GameObject.Find("GameController").GetComponent<ArrowController>();
        this.tag = ArrowController.ArrowMode[ArrowController.magic];
        Damage = ArrowController.ArrowDamage[ArrowController.magic];
    }

    public void Shot(Vector3 vel, float power)
    {
        rig.AddForce(vel * power * 10, ForceMode.Impulse);
    }

    private void This_Delete()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (gameObject.GetComponent<EnemyManager>() != null) 
        {
            rig.isKinematic = true;
            transform.parent = col.gameObject.transform;
        }
        else
        {
            rig.isKinematic = true;
        }
    }
}