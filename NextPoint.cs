using UnityEngine;
using System.Collections;

public class NextPoint : MonoBehaviour {
    [SerializeField]
    private Transform nextPoint;

    public Transform newPos
    {
        get { return nextPoint; }
        set {nextPoint = value;}
    }

}
