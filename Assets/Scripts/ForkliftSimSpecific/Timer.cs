using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;

    public bool threeStarCheck = true, twoStarCheck = true, oneStarCheck = true;

    [SerializeField] private int threeStarTime, twoStarTime, oneStarTime;

    private float currentTime = 0;

    private void Update()
    {
        currentTimeText.text = "Time: " + currentTime.ToString("F2");
        currentTime += Time.deltaTime;

        TimeCheck();
    }

    private void TimeCheck()
    {
        if (currentTime >= oneStarTime)
            oneStarCheck = false;
        if (currentTime >= twoStarTime)
            twoStarCheck = false;
        if (currentTime >= threeStarTime)
            threeStarCheck = false;
    }
}