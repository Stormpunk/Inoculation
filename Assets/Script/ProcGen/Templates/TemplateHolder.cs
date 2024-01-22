using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateHolder : MonoBehaviour
{
    [SerializeField]
    public ExitPoint thisExitPoint;
    [SerializeField]
    private RoomGenerator roomGenerator;
    [SerializeField]
    private bool roomIsSpawn;
    [SerializeField]
    public int RoomValue;
    [SerializeField]
    public int RoomDestroyCount;
    //start at 0, destroy at 7
    public bool RoomIsSPawn
    {
        get { return roomIsSpawn; }
        set { roomIsSpawn = value; }
    }
    [SerializeField] private bool isStatic;
    private void Start()
    {
        roomGenerator = GameObject.Find("GameManager").GetComponent<RoomGenerator>();
        thisExitPoint = GetComponentInChildren<ExitPoint>();
    }
    private void Update()
    {
    
    }

    

}
