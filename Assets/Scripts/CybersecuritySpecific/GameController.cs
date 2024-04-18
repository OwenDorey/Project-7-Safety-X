using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Login Screen

    public GameObject loginScreen;

    public GameObject invalidText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public string correctEmail = "email";
    public string correctPassword = "password";

    // 

    public GameObject desktopScreen;
    public GameObject emailsScreen;

    public void OnLogin()
    {
        if (emailInput.text == correctEmail && passwordInput.text == correctPassword)
        {
            desktopScreen.SetActive(true);
            loginScreen.SetActive(false);
        }
        else
        {
            invalidText.SetActive(true);
            StartCoroutine(RemoveInvalid());
        }

        IEnumerator RemoveInvalid()
        {
            yield return new WaitForSeconds(3);

            invalidText.SetActive(false);
        }
    }

    public void OpenEmails()
    {
        desktopScreen.SetActive(false);
        emailsScreen.SetActive(true);
    }
    


}
