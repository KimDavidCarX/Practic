using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Button rotationButton;

    private Quaternion targetRotation;
    private Quaternion defaultRotation;
    private bool isButtonPressed = false;
    private bool isReturning = false;

    private void Start()
    {
        defaultRotation = transform.rotation;

        rotationButton.onClick.AddListener(OnButtonPressed);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (!isButtonPressed && !isReturning)
        {
            targetRotation = defaultRotation;
        }
    }

    private void OnButtonPressed()
    {
        if (!isButtonPressed)
        {
            targetRotation = Quaternion.Euler(0f, -100f, 0f);
            isButtonPressed = true;
        }
        else
        {
            targetRotation = Quaternion.Euler(0f, 100f, 0f);
            isReturning = true;
        }
    }

    public void Stop()
    {
        targetRotation = default;
    }
}
