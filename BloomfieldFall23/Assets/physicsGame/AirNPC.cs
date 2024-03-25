using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirNPC : MonoBehaviour
{
    [Header("Base Var")]
    public GameObject targetPlayer;
    Rigidbody myRB;
    public float horSpeed = 50f;
    public float forSpeed = 5f;
    public float maxSpeed = 100f;
    public float forAccel = .1f;

    [Header("Explosion Var")]
    public float expForce;
    public float expRadius;



    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        myRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.LookAt(targetPlayer.transform);

        Vector3 newVal = Vector3.zero;
        newVal.x = horSpeed;
        newVal.z = forSpeed;
        Debug.DrawRay(transform.position, newVal, Color.magenta);
        newVal = transform.TransformDirection(newVal);
        myRB.AddForce(newVal);
        myRB.velocity = Vector3.ClampMagnitude(myRB.velocity, maxSpeed);
        Debug.Log("velocity of stalker:" + myRB.velocity.magnitude + " " + myRB.velocity);

        maxSpeed -= Time.fixedDeltaTime;
        forSpeed += forAccel;

    }


    Vector3 VectorToPlayer()
    {
        Vector3 targetDir;
        targetDir = targetPlayer.transform.position - transform.position;
        targetDir = targetDir.normalized;
        Debug.DrawRay(transform.position, targetDir * 3f, Color.red);
        return targetDir;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            Rigidbody target = collision.gameObject.GetComponent<Rigidbody>();
            target.AddExplosionForce(50f, transform.position - (Vector3.up * 2f), 20f);
            target.AddExplosionForce(expForce, transform.position - (Vector3.up * 2f), expRadius);
        }
    }



}
