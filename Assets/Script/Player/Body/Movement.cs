using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float moveZ, moveX;
    private Rigidbody rb;
    [SerializeField]
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        if (rb.velocity.x > 0 ||  rb.velocity.z > 0 || rb.velocity.x + rb.velocity.y > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    private void FixedUpdate()
    {
        MoveMe();
    }
    private void MoveMe()
    {
        rb.velocity = transform.TransformDirection(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);

    }
}
