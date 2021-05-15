using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //[SerializeField] InputAction movement;

    [Header("General SetUp settings")]
    [Tooltip("how fast ship moves up and down based upon player input")] [SerializeField] float controlSpeed = 10f;
    [Tooltip("how fast player moves horizontally")] [SerializeField] float xRange = 10f;
    [Tooltip("how fast player moves Vertically")] [SerializeField] float yRange = 7f;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;

    [Header("player input based tuning")]
    [SerializeField] float PositionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Laser Gun array")]
    [Tooltip("Add all player lasers here")][SerializeField] GameObject[] Lasers;
    
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
            SetActivateLasers(true);
        }
     else
        {
            SetActivateLasers(false);
        }
    }

    private void SetActivateLasers(bool isActive)
    {
        foreach(GameObject Laser in Lasers)
        {
            var emissionModule = Laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
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
