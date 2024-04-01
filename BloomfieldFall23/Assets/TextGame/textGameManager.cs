using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR;

public class textGameManager : MonoBehaviour
{
    [Header("name buttons")]
    public TMP_InputField myInput;
    public string playerName;
    public GameObject inputField;
    public GameObject submitButton;
    public GameObject welcomeObject;
    TextMeshProUGUI WelcomeText;

    public string welcomeMessage;
    public string replaceText;

    // Start is called before the first frame update
    void Start()
    {
        WelcomeText = welcomeObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        playerName = myInput.text;
        submitButton.SetActive(false);
        inputField.SetActive(false);

        string newWelcome = welcomeMessage.Replace(replaceText, playerName);

        WelcomeText.text = newWelcome;
    }
}
