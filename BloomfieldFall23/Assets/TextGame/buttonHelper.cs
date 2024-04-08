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

    public void AddtoPlayerInv(string item)
    {
        myPlayer.inventoryAdd(item);
    }

    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed the button!");
        SceneManager.LoadScene(sceneName);
    }

    public void SetName()
    {
        myPlayer.SetName();
    }
}
