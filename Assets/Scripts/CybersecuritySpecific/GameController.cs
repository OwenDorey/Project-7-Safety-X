using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Login Screen")]
    [SerializeField] private GameObject loginScreen;
    [SerializeField] private GameObject invalidText;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private string correctEmail = "email";
    [SerializeField] private string correctPassword = "password";
    [Header("Desktop")]
    [SerializeField] private GameObject desktopScreen;
    [SerializeField] private GameObject emailsScreen;
    [Header("Email Screen")]
    [SerializeField] private GameObject exitButton;
    [Header("Day Change")]
    [SerializeField] private EmailController emailController;
    [SerializeField] private CameraSwitchCS cameraSwitchCS;
    [SerializeField] private GameObject noLogoutText;
    [SerializeField] private int day = 1;
    public int score = 100;

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
    }

    public void OpenEmails()
    {
        desktopScreen.SetActive(false);
        emailsScreen.SetActive(true);
    }

    public void CloseEmails()
    {
        desktopScreen.SetActive(true);
        emailsScreen.SetActive(false);
    }

    public void LogOut()
    {
        if (emailController.emailsResponded == 5)
        {
            desktopScreen.SetActive(false);
            emailController.emailsResponded = 0;
            cameraSwitchCS.gameCameraCentre.SetActive(false);
            cameraSwitchCS.gameCameraLeft.SetActive(false);
            cameraSwitchCS.gameCameraRight.SetActive(false);
            cameraSwitchCS.initialCamera.SetActive(true);

            if (score > 0)
            {
                // Show score for that day
                day++;
                // Show starting screen for next day
            }
            else
            {
                // Show fail screen
                // Loop back to the start of the failed day
            }
        }
        else
        {
            noLogoutText.SetActive(true);
            StartCoroutine(RemoveInvalid());
        }
    }
    IEnumerator RemoveInvalid()
    {
        yield return new WaitForSeconds(3f);

        invalidText.SetActive(false);
    }
}