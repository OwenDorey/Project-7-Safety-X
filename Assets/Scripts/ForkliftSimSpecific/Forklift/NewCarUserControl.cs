using UnityEngine;

[RequireComponent(typeof(NewCarController))]
[RequireComponent(typeof(InputManager))]

public class NewCarUserControl : MonoBehaviour
{
    [SerializeField] private Transform steeringWheel;
    private NewCarController m_Car;
    private InputManager IM;
    private float h, v, handbrake;
    [SerializeField] private float minYRot = -1, maxYRot = 1, rotationCounter, rotationSpeed;
    [SerializeField] private bool isMaxRotate = false, stopNaturalRotate;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<NewCarController>();
        IM = GetComponent<InputManager>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car
        h = IM.horizontal;
        v = IM.vertical;
        handbrake = IM.handbrake;

        RotateSteeringWheel();

        m_Car.Move(h, v, v, handbrake);
    }

    private void RotateSteeringWheel()
    {
        // calculate rotation
        rotationCounter += h * rotationSpeed * Time.deltaTime;

        // stop rotation at min/max ranges
        if (rotationCounter <= minYRot)
        {
            isMaxRotate = true;
            rotationCounter = minYRot;
        }
        else if (rotationCounter >= maxYRot)
        {
            isMaxRotate = true;
            rotationCounter = maxYRot;
        }
        else
            isMaxRotate = false;

        // rotate wheel in relation to steering input
        if (!isMaxRotate)
        {
            steeringWheel.Rotate(float.Epsilon, h * rotationSpeed, float.Epsilon);
        }

        // rotate back to neutral position under zero steering input
        if (h == 0 && !stopNaturalRotate)
        {
            if (rotationCounter > 0)
            {
                rotationCounter += -rotationSpeed * Time.deltaTime;
                steeringWheel.Rotate(float.Epsilon, -rotationSpeed, float.Epsilon);

                if (rotationCounter == 0)
                    stopNaturalRotate = true;
                else
                    stopNaturalRotate = false;
            }

            if (rotationCounter < 0)
            {
                rotationCounter += rotationSpeed * Time.deltaTime;
                steeringWheel.Rotate(float.Epsilon, rotationSpeed, float.Epsilon);

                if (rotationCounter == 0)
                    stopNaturalRotate = true;
                else
                    stopNaturalRotate = false;
            }
        }
    }
}