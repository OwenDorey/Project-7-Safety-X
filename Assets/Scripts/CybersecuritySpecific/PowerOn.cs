using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameController gameController;
    private void OnMouseDown()
    {
        gameController.PowerButton();
    }
}