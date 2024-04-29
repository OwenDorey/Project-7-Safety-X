using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class EmailsManager : MonoBehaviour
{
    // Screens

    public GameObject emailScreen;
    public GameObject allEmailsScreen;
    public GameObject openedEmailScreen;

    public int day = 1;

    // Emails

    public GameObject[] Day1Emails;

    private float change = 60f;
    [HideInInspector] public float offset = 60f;

    public bool isCurrentEmailGood;

    public GameObject currentEmailObject;

    [HideInInspector] public int emailCount = 0;
    [HideInInspector] public int completedEmails = 0;
    [HideInInspector] public int correctEmails = 0;
    [HideInInspector] public List<GameObject> allEmails;



    public void AddEmails()
    {

        // If day 1

        if (day == 1 && emailCount == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                int chosen = Random.Range(0, Day1Emails.Length);
                GameObject newEmail = Instantiate(Day1Emails[chosen], emailScreen.transform);
                newEmail.GetComponent<RectTransform>().localPosition -= new Vector3(0f, offset, 0f);

                offset += change;
                emailCount++;
                allEmails.Add(newEmail);
            }
        }
    }

    public void OnReply()
    {
        if (isCurrentEmailGood)
        {
            correctEmails += 1;
        }
        Debug.Log(correctEmails);

        currentEmailObject.GetComponent<Image>().color = new Color32(79, 253, 46, 67);
        currentEmailObject.GetComponent<Button>().interactable = false;

        completedEmails++;
        openedEmailScreen.SetActive(false);
    }

    public void OnDelete()
    {
        if (!isCurrentEmailGood)
        {
            correctEmails += 1;
        }
        Debug.Log(correctEmails);

        currentEmailObject.GetComponent<Image>().color = new Color32(255, 49, 49, 67);
        currentEmailObject.GetComponent<Button>().interactable = false;

        completedEmails++;
        openedEmailScreen.SetActive(false);
    }

    public void DeleteAllEmails()
    {
        foreach (var email in allEmails)
        {
            Destroy(email);
        }
    }
}
