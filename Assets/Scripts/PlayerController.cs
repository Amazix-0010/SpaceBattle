using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 50f;
    [Tooltip("In m")] [SerializeField] float xRange = 17f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawPos, -xRange, xRange);


        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
