using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Stats")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField] private float speedMultiplier;
    //for sprinting
    [SerializeField] private float fatigueMultiplier;
    private Rigidbody rb;
    [SerializeField]
    public bool isMoving = false;
    private float moveZ, moveX;
    [Header("Player Manager")]
    [SerializeField] private PlayerManager pManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Get Player Inputs
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        #endregion
        float fatigue = this.GetComponent<Stats>().Fatigue;
        if (rb.velocity.x > 0 ||  rb.velocity.z > 0 || rb.velocity.x + rb.velocity.y > 0)
        {
            isMoving = true;
            this.GetComponent<Stats>().Fatigue += (0.1f  + speedMultiplier) * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }
        #region Fatigue and Sprinting
        switch (fatigue)
        {
            case float f when f >= 0.0f && f < 10f:
                moveSpeed = 2;
                break;
            case float f when f >= 10f && f < 20f:
                moveSpeed = 1.5f;
                break;
            case float f when f >= 20f && f < 50f:
                moveSpeed = 1f;
                break;
            case float f when f >= 50 && f < 75f:
                moveSpeed = 0.75f;
                break;
            case float f when f >= 75 && f < 100f:
                moveSpeed = 0.5f;
                break;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedMultiplier = 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMultiplier = 1;
        }
        #endregion
    }
    private void FixedUpdate()
    {
        MoveMe();
    }
    private void MoveMe()
    {
        rb.velocity = transform.TransformDirection(moveX * (moveSpeed * speedMultiplier), rb.velocity.y, moveZ * (moveSpeed * speedMultiplier));

    }
}
