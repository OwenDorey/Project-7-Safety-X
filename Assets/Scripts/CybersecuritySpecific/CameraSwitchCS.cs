using UnityEngine;

public class CameraSwitchCS : MonoBehaviour
{
    [SerializeField] private float changeRate;
    [SerializeField] private GameController gameController;
    [Header("Cameras")]
    public GameObject initialCamera;
    public GameObject gameCameraCentre;
    public GameObject gameCameraRight;
    public GameObject gameCameraLeft;
    
    private InputManager IM;
    private float nextSwitch = 0f;
    private bool initialChange = false;

    void Start()
    {
        IM = GetComponent<InputManager>();
    }

    void Update()
    {
        if (gameController.isOn)
        {
            if (!initialChange)
            {
                gameCameraCentre.SetActive(true);
                initialCamera.SetActive(false);
                initialChange = true;
            }
            InputCheck();
        }
    }

    private void InputCheck()
    {
        if (IM.cameraSwitchLeft && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveLeft();
        }
        if (IM.cameraSwitchRight && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveRight();
        }
    }

    private void ChangePerspectiveLeft()
    {
        if (gameCameraRight.activeSelf)
        {
            gameCameraCentre.SetActive(true);
            gameCameraRight.SetActive(false);
            gameCameraLeft.SetActive(false);
        }
        else if (gameCameraCentre.activeSelf)
        {
            gameCameraCentre.SetActive(false);
            gameCameraRight.SetActive(false);
            gameCameraLeft.SetActive(true);
        }
    }

    private void ChangePerspectiveRight()
    {
        if (gameCameraLeft.activeSelf)
        {
            gameCameraCentre.SetActive(true);
            gameCameraRight.SetActive(false);
            gameCameraLeft.SetActive(false);
        }
        else if (gameCameraCentre.activeSelf)
        {
            gameCameraCentre.SetActive(false);
            gameCameraRight.SetActive(true);
            gameCameraLeft.SetActive(false);
        }
    }
}