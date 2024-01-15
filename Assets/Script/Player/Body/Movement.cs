using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float moveZ, moveX;
    private Rigidbody rb;

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
