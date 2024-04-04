using UnityEngine;

public class ForkController : MonoBehaviour
{
    [SerializeField] private Transform fork;
    [SerializeField] private Transform mast;
    [SerializeField] private RectTransform heightUI;
    [SerializeField] private ForkBottomCollision ForkBottomCollision;
    [SerializeField] private float speedTranslate; //Platform travel speed
    [SerializeField] private Vector3 maxY; //The maximum height of the platform
    [SerializeField] private Vector3 minY; //The minimum height of the platform
    [SerializeField] private Vector3 maxYmast; //The maximum height of the mast
    [SerializeField] private Vector3 minYmast; //The minimum height of the mast
    [SerializeField] private Vector3 maxYUI; //The maximum height of the UI element
    [SerializeField] private Vector3 minYUI; //The minimum height of the UI element

    private bool mastMoveTrue = false; //Activate or deactivate the movement of the mast
    private InputManager IM;

    private void Awake()
    {
        IM = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        if (fork.transform.localPosition.y >= maxYmast.y && fork.transform.localPosition.y < maxY.y)
            mastMoveTrue = true;
        else
            mastMoveTrue = false;

        if (fork.transform.localPosition.y <= maxYmast.y)
            mastMoveTrue = false;

        if (IM.forkliftUp)
        {
            fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, maxY, speedTranslate * Time.deltaTime);
            heightUI.transform.localPosition = Vector3.MoveTowards(heightUI.transform.localPosition, maxYUI, speedTranslate * Time.deltaTime * 100);

            if (mastMoveTrue)
                mast.transform.localPosition = Vector3.MoveTowards(mast.transform.localPosition, maxYmast, speedTranslate * Time.deltaTime);
        }

        if (IM.forkliftDown && !ForkBottomCollision.bottomCollision)
        {
            fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, minY, speedTranslate * Time.deltaTime);
            heightUI.transform.localPosition = Vector3.MoveTowards(heightUI.transform.localPosition, minYUI, speedTranslate * Time.deltaTime * 100);

            if (mastMoveTrue)
                mast.transform.localPosition = Vector3.MoveTowards(mast.transform.localPosition, minYmast, speedTranslate * Time.deltaTime);
        }
    }
}