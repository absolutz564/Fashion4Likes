using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public string Name;
    public string Email;

    public GameObject LoginObject;
    public GameObject QuizObject;

    public InputField NameInput;
    public InputField EmailInput;

    public Button StartButton;

    public static LoginController Instance;

    private void Awake()
    {
        Instance = this;
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, true);
        Screen.fullScreen = true;
#endif
    }

    

    public void EnableQuiz()
    {
        Name = NameInput.text;
        Email = EmailInput.text;
        LoginObject.SetActive(false);
    }

    public void OnInputChange()
    {
        if(NameInput.text != "" && EmailInput.text != "")
        {
            StartButton.interactable = true;
        }
    }
}
