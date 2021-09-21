using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
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

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    public void EnableQuiz()
    {
        Name = NameInput.text;
        Email = EmailInput.text;
        LoginObject.SetActive(false);
    }

    public void OnInputChange()
    {
        if(NameInput.text != "" && EmailInput.text != "" && IsValidEmail(EmailInput.text))
        {
            StartButton.interactable = true;
        }
        else
        {
            StartButton.interactable = false;
        }
    }
}
