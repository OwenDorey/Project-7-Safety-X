using System.Collections;
using UnityEngine;

public class EmailController : MonoBehaviour
{
    private int correctResponse;

    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject openEmailButton;
    [SerializeField] private GameObject correctResponseButton;
    [SerializeField] private GameObject incorrectResopnseButton;
    [SerializeField] private GameController gameController;

    public int emailsResponded = 0;

    public void OpenEmail()
    {
        contentPanel.SetActive(true);
    }

    public void CorrectResponse()
    {
        correctResponse = 0;
        emailsResponded++;
        CalculateResult();
    }

    public void IncorrectResponsePoints()
    {
        correctResponse = 1;
        emailsResponded++;
        CalculateResult();
    }

    public void IncorrectResponseLose()
    {
        correctResponse = 2;
        emailsResponded++;
        CalculateResult();
    }

    private void CalculateResult()
    {
        if (correctResponse == 0)
            StartCoroutine(ReturnToEmailScreen());
        else if (correctResponse == 1)
        {
            //gameController.score -= 25;
            StartCoroutine(ReturnToEmailScreen());
        }
        else if (correctResponse == 2)
        {
            //gameController.score = 0;
            StartCoroutine(ReturnToEmailScreen());
        }
    }

    IEnumerator ReturnToEmailScreen()
    {
        yield return new WaitForSeconds(1f);
        contentPanel.SetActive(false);
    }
}