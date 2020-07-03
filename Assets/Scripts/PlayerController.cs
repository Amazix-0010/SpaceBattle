using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Tooltip("In m/s - x")][SerializeField] float moveSpeed = 50f;
    [Tooltip("In m - x")][SerializeField] float xRange = 19f;

    [Tooltip("In m - y")][SerializeField] float yRangeMax = 12f;
    [Tooltip("In m - y")][SerializeField] float yRangeMin = -12f;

    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -30f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Translation();
        Rotation();
    }

    private void Rotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float PitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + PitchDueToControlThrow;
        float yaw = 0f;
        float roll = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Translation()
    {
        // X
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * moveSpeed * Time.deltaTime;

        float rawPosX = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawPosX, -xRange, xRange);

        // Y
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * moveSpeed * Time.deltaTime;

        float rawPosY = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawPosY, yRangeMin, yRangeMax);

        // Transform
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        // localPosition = Chceme přesunovat jen raketu, to znamená dítě z Main Camera(Rodič). Nechceme hýbat s kamerou(rodičem)
    }
}
