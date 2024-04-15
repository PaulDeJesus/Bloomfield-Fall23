using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meshControl : MonoBehaviour
{
    [Header("basic Vars")]
    public Renderer myRender;
    public Mesh myMesh;
    public Material myMat;
    public Rigidbody myRB;
    public float speed;

    [Header("Bools")]
    public bool colorOnHit = true;
    public bool speedStretch = true;

    
    public float previousMagn;
    Vector3[] referencePos;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshFilter>().mesh;
        myRB = GetComponent<Rigidbody>();
        myMat = myRender.material;
        myMat.color = Color.white;
        referencePos = myMesh.vertices;
    }

    public void Update()
    {
        speed = myRB.velocity.magnitude * .1f;

        if(speedStretch)
        {
            float newZ = Mathf.Clamp(speed, .8f, 3f);
            if(transform.localScale.z >= .8f && transform.localScale.z <= 3f)
            {
                transform.localScale = new Vector3(1, 1, newZ);
            }
        }

        previousMagn = myRB.velocity.magnitude;
    }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "NPC" || collision.gameObject.tag == "Player")
        {
           if(colorOnHit) StartCoroutine(takeHit(1f));
        }
    }

    IEnumerator takeHit(float time)
    {
        myMat.color = Color.red;
        yield return new WaitForSeconds(time);
        myMat.color = Color.white;
    }

}
