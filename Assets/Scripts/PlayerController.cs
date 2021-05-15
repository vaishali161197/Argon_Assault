using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float PositionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] Lasers;

    float xThrow;
    float yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // void OnEnable()
    //{
    //    movement.Enable();
    //}

    // void OnDisable()
    //{
    //    movement.Disable();
    //}

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    private void ProcessFiring()
    {
     if(Input.GetButton("Fire1"))
        {
            ActivateLasers();
        }
     else
        {
            DeactivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach(GameObject Laser in Lasers)
        {
            Laser.SetActive(true);
        }
    }
    private void DeactivateLasers()
    {
       foreach(GameObject Laser in Lasers)
        {
            Laser.SetActive(false);
        }
    }

    

    void ProcessRotation()
    {
        float PitchDueToControlThrow = yThrow * controlPitchFactor;
        float PitchDueToPosition = transform.localPosition.y * positionPitchFactor;


        float pitch = PitchDueToPosition + PitchDueToControlThrow;

        float yaw = transform.localPosition.x * PositionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation= Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //float verticalThrow = movement.ReadValue<Vector2>().y;


         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXpos = transform.localPosition.x + xoffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float Yoffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYpos = transform.localPosition.y + Yoffset;
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);



        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
