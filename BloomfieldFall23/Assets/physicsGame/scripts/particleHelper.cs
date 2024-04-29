using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleHelper : MonoBehaviour
{
    public ParticleSystem myParticles;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("COLLIDED");
            myParticles.Play(true);
        }
    }
}
