using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostPlatform : MonoBehaviour
{
    public string playerTag = "Player";
    public float disappearTime = 3f;
    Animator myAnim;

    public bool canReset;
    public float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("DisappearTime", 1 / disappearTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == playerTag)
        {
            myAnim.SetBool("Trigger", true);
        }
    }

    public void TriggerReset()
    {
        if(canReset)
        {
            StartCoroutine(Reset());
        }

        IEnumerator Reset()
        {
            yield return new WaitForSeconds(resetTime);
            myAnim.SetBool("Trigger", false);
        }
    }
}
