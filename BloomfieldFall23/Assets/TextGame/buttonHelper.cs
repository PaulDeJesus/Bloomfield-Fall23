using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHelper : MonoBehaviour
{
    public textGameManager myPlayer;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindAnyObjectByType<textGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed the button!");
        SceneManager.LoadScene(sceneName);
    }

}
