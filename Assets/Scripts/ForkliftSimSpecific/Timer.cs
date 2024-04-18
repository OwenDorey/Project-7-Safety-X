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
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        currentTimeText.text = "Time: " + timeText;
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