using UnityEngine;
using System.Collections;

public class MoveWorld : MonoBehaviour {
    //t means tilt
    private bool _forward, _backward, _left, _right;
    private float _tLeft, _tForward;
    private int _tSpeed = 2;
    private bool doMoveWorld;

    [SerializeField]
    private int _maxAngle = 13;

    void Update()
    {
        if (doMoveWorld) tiltPlatform();
    }

    //tilting the platform
    void tiltPlatform()
    {
        //adding angle
        if (_forward) { _tForward += _tSpeed; }
        else if (_backward) { _tForward -= _tSpeed; }
        if (_left) { _tLeft += _tSpeed; }
        else if (_right) { _tLeft -= _tSpeed; }

        //makes the movement smooth
        if (_tForward > 0) _tForward -= _tForward / _maxAngle;
        else if (_tForward < 0) _tForward -= _tForward / _maxAngle;
        if (_tLeft > 0) _tLeft -= _tLeft / _maxAngle;
        else if (_tLeft < 0) _tLeft -= _tLeft / _maxAngle;

        //actually changes the angle
        this.transform.eulerAngles = new Vector3(_tForward, 0, _tLeft);
    }

    public bool setLeft
    {
        get { return _left; }
        set { _left = value; }
    }
    public bool setRight
    {
        get { return _right; }
        set { _right = value; }
    }
    public bool setForward
    {
        get { return _forward; }
        set { _forward = value; }
    }
    public bool setBackward
    {
        get { return _backward; }
        set { _backward = value; }
    }
    public bool DoMoveWorld
    {
        get { return doMoveWorld; }
        set { doMoveWorld = value; }
    }
}
