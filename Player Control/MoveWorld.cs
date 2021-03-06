﻿using UnityEngine;
using System.Collections;

public class MoveWorld : MonoBehaviour {
    //t means tilt
    private bool _forward, _backward, _left, _right;
    private float _tLeft, _tForward;
    private float _tSpeed;
    private bool doMoveWorld = false;

    [SerializeField]
    private int _maxAngle = 13;

    void Start()
    {
        _tSpeed = 100 * Time.deltaTime;
    }

    void Update()
    {
        if (doMoveWorld) tiltPlatform();
    }

    //tilting the platform
    void tiltPlatform()
    {
        //adding angle
        if (_forward) { _tForward += _tSpeed; }
        if (_backward) { _tForward -= _tSpeed; }
        if (_left) { _tLeft += _tSpeed; }
        if (_right) { _tLeft -= _tSpeed; }

        //makes the movement smooth
        if (_tForward > 0) _tForward -= _tForward / _maxAngle;
        if (_tForward < 0) _tForward -= _tForward / _maxAngle;
        if (_tLeft > 0) _tLeft -= _tLeft / _maxAngle;
        if (_tLeft < 0) _tLeft -= _tLeft / _maxAngle;

        //actually changes the angle
        transform.eulerAngles = new Vector3(_tForward, 0, _tLeft);
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
        set {
            doMoveWorld = value;
            transform.eulerAngles = Vector3.zero;
        }
    }
}
