using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmailsManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject emailScreen;
    [SerializeField] private GameObject openedEmailScreen;
    [Header("Emails")]
    public bool isCurrentEmailGood;
    public int emailsResponded = 0;

    [SerializeField] private GameObject[] Day1Emails;

    private float change = 60f;
    private float offset = 60f;
    [Header("Misc.")]
    public GameObject currentEmailObject;
    public int day = 1;

    [SerializeField] private int score = 0;
    [SerializeField] private float returnDelay;

    private GameObject[] allEmails;
    //private int emailIndex = 0;
    private int emailCount = 0;

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

                //allEmails[emailIndex] = newEmail;
                //emailIndex++;

                offset += change;
                emailCount++;
            }
        }
    }

    public void OnReply()
    {
       if (isCurrentEmailGood)
       {
            score += 10;
       }
        Debug.Log(score);

        currentEmailObject.GetComponent<Image>().color = new Color32(79, 253, 46, 67);
        currentEmailObject.GetComponent<Button>().interactable = false;

        StartCoroutine(ReturnToEmailScreen());
    }

    public void OnDelete()
    {
        if (!isCurrentEmailGood)
        {
            score += 10;
        }
        Debug.Log(score);

        currentEmailObject.GetComponent<Image>().color = new Color32(255, 49, 49, 67);
        currentEmailObject.GetComponent<Button>().interactable = false;

        StartCoroutine(ReturnToEmailScreen());
    }

    public void DeleteAllEmails()
    {
        for (int i = 0; i < allEmails.Length; i++)
        {
            Destroy(allEmails[i]);
        }
    }

    IEnumerator ReturnToEmailScreen()
    {
        emailsResponded++;
        yield return new WaitForSeconds(returnDelay);
        openedEmailScreen.SetActive(false);
    }
}