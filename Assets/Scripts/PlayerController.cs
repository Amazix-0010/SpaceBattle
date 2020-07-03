using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Tooltip("In m/s - x")][SerializeField] float moveSpeed = 50f;
    [Tooltip("In m - x")][SerializeField] float xRange = 17f;

    [Tooltip("In m - y")][SerializeField] float yRangeMax = 10f;
    [Tooltip("In m - y")][SerializeField] float yRangeMin = -10f;

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
        transform.localRotation = Quaternion.Euler(0f, 30f, 0f);
    }

    private void Translation()
    {
        // X
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * moveSpeed * Time.deltaTime;

        float rawPosX = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawPosX, -xRange, xRange);

        // Y
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * moveSpeed * Time.deltaTime;

        float rawPosY = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawPosY, yRangeMin, yRangeMax);

        // Transform
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        // localPosition = Chceme přesunovat jen raketu, to znamená dítě z Main Camera(Rodič). Nechceme hýbat s kamerou(rodičem)
    }
}
