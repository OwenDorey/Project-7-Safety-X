using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class GameController : MonoBehaviour
{
    [Header("Login")]

    public GameObject loginScreen;

    public GameObject invalidText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public string correctEmail = "email";
    public string correctPassword = "password";

    [Header("Screens")]

    public GameObject desktopScreen;
    public GameObject emailsScreen;

    [Header("Results")]

    public GameObject resultsScreen;
    public TMP_Text scoreText;
    public TMP_Text resultText;
    public GameObject NextDayButton;
    public GameObject RetryDayButton;

    [Header("Other")]

    public EmailsManager emailsManager;

    [Header("Power On")]

    public Renderer powerButton;
    public GameObject startupScreen;
    public Material onMaterial;
    public Material offMaterial;
    public Animator showDay;
    [HideInInspector] public bool isOn = false;

    public void OnLogin()
    {
        if (emailInput.text == correctEmail && passwordInput.text == correctPassword)
        {
            desktopScreen.SetActive(true);
            emailInput.text = "";
            passwordInput.text = "";
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
        emailsManager.AddEmails();
    }

    public void RetryDay()
    {
        StartDay();
    }

    public void StartNextDay()
    {
        emailsManager.day++;
        StartDay();
    }

    private void StartDay()
    {
        emailsManager.DeleteAllEmails();
        resultsScreen.SetActive(false);

        emailsManager.completedEmails = 0;
        emailsManager.correctEmails = 0;
        emailsManager.emailCount = 0;
        emailsManager.offset = 60f;

        showDay.SetTrigger("Return");
        showDay.SetTrigger("Show");
    }

    public void PowerButton()
    {
        // Turn on pc

        if (!isOn)
        {
            OnPowerOn();
        }

        // Turn off pc if all emails complete

        else if (isOn && emailsManager.completedEmails == emailsManager.emailCount)
        {
            OnPowerOff();
        }
    }
    public void OnPowerOn()
    {
        startupScreen.SetActive(true);
        powerButton.material = onMaterial;
        isOn = true;
        StartCoroutine(StartUp());

        IEnumerator StartUp()
        {
            yield return new WaitForSeconds(3f);

            loginScreen.SetActive(true);
            showDay.SetTrigger("Show");
            startupScreen.SetActive(false);
        }
    }

    public void OnPowerOff()
    {
        powerButton.material = offMaterial;
        isOn = false;

        desktopScreen.SetActive(false);
        loginScreen.SetActive(false);
        emailsScreen.SetActive(false);

        resultsScreen.SetActive(true);
        scoreText.text = "Score: " + emailsManager.correctEmails.ToString() + " / " + emailsManager.emailCount.ToString();

        // If all emails correct
        if (emailsManager.correctEmails == emailsManager.emailCount)
        {
            resultText.text = "Day " + emailsManager.day + " Completed!";
            NextDayButton.SetActive(true);
            RetryDayButton.SetActive(false);
        }
        // If failed day
        else
        {
            resultText.text = "Day " + emailsManager.day + " Failed!";
            RetryDayButton.SetActive(true);
            NextDayButton.SetActive(false);
        }


    }


    //cameraSwitchCS.gameCameraCentre.SetActive(false);
    //cameraSwitchCS.gameCameraLeft.SetActive(false);
    //cameraSwitchCS.gameCameraRight.SetActive(false);
    //cameraSwitchCS.initialCamera.SetActive(true);


}
