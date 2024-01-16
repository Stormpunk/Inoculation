using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private float bobAmount = 0.05f;
    private float bobSpeed = 7f;
    float defaultPosY = 0;
    float timer = 0;
    [SerializeField]
    private Movement playerMove;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMoving == true)
        {
            timer += Time.deltaTime * bobSpeed;
            _camera.transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobAmount, transform.localPosition.y);
        }
        else
        {
            timer = 0;
            _camera.transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * bobSpeed),transform.localPosition.z);
        }
    }
}
