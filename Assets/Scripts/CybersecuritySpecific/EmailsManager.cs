using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailsManager : MonoBehaviour
{
    [Header("Screens")]

    public GameObject emailScreen;
    public GameObject allEmailsScreen;
    public GameObject openedEmailScreen;

    public int day = 1;

    [Header("Emails")]

    public GameObject[] Day1Emails;
    public GameObject[] Day2Emails;
    public GameObject[] Day3Emails;
    public GameObject[] Day4Emails;
    public GameObject[] Day5Emails;
    public GameObject[] currentDayEmails;

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
        switch (day)
        {
            case 1:
                currentDayEmails = Day1Emails;
            break;
            case 2:
                currentDayEmails = Day2Emails;
            break;
            case 3:
                currentDayEmails = Day3Emails;
            break;
            case 4:
                currentDayEmails = Day4Emails;
            break;
            case 5:
                currentDayEmails = Day5Emails;
            break;
            default:
            break;
        }

        for (int i = 0; i < 5; i++)
        {
            int chosen = Random.Range(0, currentDayEmails.Length);
            GameObject newEmail = Instantiate(currentDayEmails[chosen], emailScreen.transform);
            newEmail.GetComponent<RectTransform>().localPosition -= new Vector3(0f, offset, 0f);

            offset += change;
            emailCount++;
            allEmails.Add(newEmail);
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