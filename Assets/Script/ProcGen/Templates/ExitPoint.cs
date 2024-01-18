using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private int orientation;
    //degree angle that the next spawned template will need to be to match with this rotation
    private bool isEmpty;
    //is this exit point empty or does it have a created template
    private bool isCenter;
    //is the player in this room or not (if not it will be max 2 points away)
    private int distanceFromCentre;
}
