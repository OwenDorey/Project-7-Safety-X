using TMPro;
using UnityEngine;

public class Email : MonoBehaviour
{
    public string subject;
    public string sender;
    public string email;
    //public string content;
    private string time;

    public TMP_Text content;
    public TMP_Text senderText;
    public TMP_Text emailContentText;
    public TMP_Text timeText;

    public bool isGood;

    private void Start()
    {
        // Sets Time

        int num1 = Random.Range(6, 23);
        int num2 = Random.Range(1, 60);
        time = string.Format("{0:00}:{1:00}", num1, num2);

        // Sets Other Info

        senderText.text = sender;
        emailContentText.text = content.text;
        timeText.text = time;
    }

    public void OpenEmail()
    {
        // Open Full Email

        OpenedEmail openedEmailScreen = FindFirstObjectByType<OpenedEmail>();
        EmailsManager emailsManager = FindFirstObjectByType<EmailsManager>();

        openedEmailScreen.subject.text = subject;
        openedEmailScreen.sender.text = sender;
        openedEmailScreen.email.text = email;
        openedEmailScreen.content.text = content.text;
        openedEmailScreen.time.text = time;

        emailsManager.isCurrentEmailGood = isGood;
        emailsManager.currentEmailObject = gameObject;

        openedEmailScreen.screen.SetActive(true);
    }
}