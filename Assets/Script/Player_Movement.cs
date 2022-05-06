using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player_Movement : NetworkBehaviour
{
    public CharacterController controller;

    float horizontal;
    float vertical;
    bool jump;
    bool dash;
    bool pause;

    float turnSmoothTime = 0.1f;
    float SmoothVelocity;

    [SerializeField]
    float jumpHeight = 5f;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float runningSpeed = 8f;
    public float autoRuntime = 2f;
    float runTime = 0f;
    float current_speed;

    float currentDashTime;
    public float maxDashTime = 2;
    public float dashStopSpeed = 0.1f;
    public float dashSpeed = 100f;


    [SerializeField]
    float gravity = -9.8f;
    Vector3 velocity;

    bool isground;
    public Transform groundCheck;
    public LayerMask ground;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (IsLocalPlayer)
        {
            GameManager.Instance.FreeLook.m_LookAt = gameObject.transform;
            GameManager.Instance.FreeLook.m_Follow = gameObject.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(IsClient)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            jump = Input.GetButton("Jump");
            dash = Input.GetKeyDown(KeyCode.LeftShift);
            pause = Input.GetKey(KeyCode.Escape);
        }
        if (pause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Move();
    }


    void Move()
    {
        if(runTime < autoRuntime && (Mathf.Abs(horizontal) == 1 || Mathf.Abs(vertical) == 1))
        {
            current_speed = speed;
            runTime += Time.deltaTime;
        }
        else if(runTime >= autoRuntime)
            current_speed = runningSpeed;
        else if((Mathf.Abs(horizontal) != 1 || Mathf.Abs(vertical) != 1))
            runTime = 0;
        Debug.Log(runTime);
        isground = Physics.CheckSphere(groundCheck.position, 0.5f, ground);
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f && IsLocalPlayer)
        {
            float turn = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + GameManager.Instance.Cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turn, ref SmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir = Quaternion.Euler(0f, turn, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * current_speed * Time.deltaTime);
        }

        if (jump && isground)
        {
            velocity.y = Mathf.Sqrt(2 * -gravity * jumpHeight);
        }

        if(isground && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(dash)
            currentDashTime = 0f;
        if(currentDashTime < maxDashTime){
            currentDashTime += dashStopSpeed;
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
        }
    }
}


