using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour {

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;

    private Transform needleTranform;
    private Transform speedLabelTemplateTransform;
    private float speed;
    [SerializeField] private float speedMax = 10f;
    [SerializeField] private int labelAmount = 5;
    [SerializeField] private NewCarController controller;

    private void Start() {
        needleTranform = transform.Find("Needle");
        speedLabelTemplateTransform = transform.Find("SpeedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;

        CreateSpeedLabels();
    }

    private void Update() {
        //HandlePlayerInput();

        //speed += 30f * Time.deltaTime;
        //if (speed > speedMax) speed = speedMax;
        speed = controller.m_Rigidbody.velocity.magnitude;
        speed = Mathf.Clamp(speed, 0f, speedMax);
        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

/*    private void HandlePlayerInput() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            float acceleration = 80f;
            speed += acceleration * Time.deltaTime;
        } else {
            float deceleration = 20f;
            speed -= deceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            float brakeSpeed = 100f;
            speed -= brakeSpeed * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0f, speedMax);
    }*/

    private void CreateSpeedLabels() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++) {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("SpeedDialText").GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("SpeedDialText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        needleTranform.SetAsLastSibling();
    }

    private float GetSpeedRotation() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
