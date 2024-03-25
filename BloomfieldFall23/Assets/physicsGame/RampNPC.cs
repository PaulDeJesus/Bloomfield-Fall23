using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RampNPC : MonoBehaviour
{
    [Header("base vars")]
    public GameObject targetPlayer;
    public float speed = 50f;
    Rigidbody myRB;


    [Header("Plow Vars")]
    //proxAttack tells our Plow when to launch at the player
    float proxAttack = 10f;
    public float launchSpeed = 2000f;
    public bool nearPlayer;




    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindWithTag("Player");
        myRB = GetComponent<Rigidbody>();
        nearPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector3.Distance(targetPlayer.transform.position, transform.position);

        if(distToPlayer > proxAttack && !nearPlayer)
        {
            myRB.AddForce(VectorToPlayer() * speed);
            transform.LookAt(targetPlayer.transform);
        }

        else
        {   //use this bool to make sure we only launch once!
            if (nearPlayer == false)
            {
                Launch();
                nearPlayer = true;
            }
        }

    }

    Vector3 VectorToPlayer()
    {
        Vector3 targetDir;
        targetDir = targetPlayer.transform.position - transform.position;
        targetDir = targetDir.normalized;
        Debug.DrawRay(transform.position, targetDir * speed, Color.red);
        return targetDir;
    }

    void Launch()
    {
        myRB.AddForce(VectorToPlayer() * launchSpeed);
    }

}
