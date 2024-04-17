using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager))]

public class PlayerPauseCS : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private MenuResultControllerCS resultController;

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
            resultController.pauseMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}