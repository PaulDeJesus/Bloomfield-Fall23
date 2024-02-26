using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player3D : MonoBehaviour
{

    public float speed = .2f;
    public GameObject myCam;
    public float camLock = 90;
    public float lookSpeed = 5f;
    public float jumpForce = 50f;
    public bool jumped = false;
    public bool canJump = true;

    Rigidbody myRB;
    Vector3 myLook;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myLook = Vector3.zero;
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLook = myCam.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, playerLook * 3f, Color.magenta);


        myLook += DeltaLook() * Time.deltaTime;

        if(myLook.y > camLock)
        {
            myLook.y = camLock;
        }
        else if(myLook.y < -camLock)
        {
            myLook.y = -camLock;
        }


        Debug.Log("look dir: " + myLook);

        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            jumped = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 myDir = transform.TransformDirection(Dir());
        Debug.Log("input dir: " + myDir);
        myRB.AddForce(myDir * speed);

        if(jumped && canJump)
        {
            Jump();
        }
    }


    Vector3 Dir()
    {
        Vector3 moveDir = Vector3.zero;

      /*  if (Input.GetKey(forward))
        {
            //moveDir += Vector3.forward + speed;
        }

       if (Input.GetKey(backwards))
        {

        }

       if (Input.GetKey(left))
        {

        }

       if (Input.GetKey(right))
        {

        }*/

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(x, 0, z);

        return moveDir;
    }

    Vector3 DeltaLook()
    {
        Vector3 deltaLook = Vector3.zero;
        float rotY = Input.GetAxisRaw("Mouse Y") * lookSpeed;
        float rotX = Input.GetAxisRaw("Mouse X") * lookSpeed;

        deltaLook = new Vector3(rotX, rotY, 0);
        return deltaLook;
    }


    void Jump()
    {
        myRB.AddForce(Vector3.up * jumpForce);
        jumped = false;
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground") { canJump = true; }
    }


    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

}