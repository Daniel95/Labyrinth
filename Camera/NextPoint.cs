using UnityEngine;
using System.Collections;

public class NextPoint : MonoBehaviour {
    [SerializeField]
    private Transform nextPoint;
    private bool done = false;

    //Getting the next point
    public Transform newPos
    {
        get { return nextPoint; }
        set {nextPoint = value;}
    }

    //Setting in once
    public bool Done
    {
        get { return done; }
        set { done = value; }
    }

}
