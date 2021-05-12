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

    }

    void ProcessRotation()
    {
        transform.localRotation= Quaternion.Euler(-30f, 30f, 0f);
    }

    private void ProcessTranslation()
    {
        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //float verticalThrow = movement.ReadValue<Vector2>().y;


        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXpos = transform.localPosition.x + xoffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float Yoffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYpos = transform.localPosition.y + Yoffset;
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);



        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
