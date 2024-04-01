using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PalletInGoal : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private TextMeshProUGUI starRating;
    [SerializeField] private MenuWinController winController;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioSource forkliftEngine;

    private bool isGameWon = false;
    public int totalPallets, palletCheck = 0;

    private void Start()
    {
        totalPallets = GameObject.FindGameObjectsWithTag("Pallet").Length;
    }

    private void Update()
    {
        GameWinCheck();
    }

    private void GameWinCheck()
    {
        if (palletCheck == totalPallets && !isGameWon)
        {
            if (timer.threeStarCheck)
                starRating.text = "3 Stars!";
            else if (timer.twoStarCheck)
                starRating.text = "2 Stars!";
            else if (timer.oneStarCheck)
                starRating.text = "1 Star!";
            else starRating.text = "0 Stars!";

            forkliftEngine.Stop();
            winController.winMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restartButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isGameWon = true;
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Pallet"))
        {
            palletCheck++;
            collision.gameObject.tag = "Collected Pallet";
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collected Pallet"))
        {
            palletCheck--;
            collision.gameObject.tag = "Pallet";
        }
    }
}