using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager))]

public class PlayerPause : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private MenuResultController resultController;
    [SerializeField] private AudioSource forkliftEngine;

    private InputManager IM;

    private void Start()
    {
        IM = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (resultController.gameStarted)
            PauseActivate();
    }

    private void PauseActivate()
    {
        if (IM.cancel)
        {
            forkliftEngine.Stop();
            resultController.pauseMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}