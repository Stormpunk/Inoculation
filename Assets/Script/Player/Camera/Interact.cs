using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField]
    private Camera m_Camera;
    [Header("Values")]
    [SerializeField]
    private float interactDistance;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }
    public void Use()
    {
        RaycastHit hit;
        if(Physics.Raycast(m_Camera.transform.position,m_Camera.transform.forward, out hit, interactDistance))
        {
            hit.transform.gameObject.SendMessage("Use");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 direction = m_Camera.transform.forward * interactDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
