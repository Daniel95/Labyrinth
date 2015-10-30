using UnityEngine;
//using System.Collections;
using System.Collections.Generic;

public class WeightButton : MonoBehaviour
{

    [SerializeField]
    private GameObject[] movingWalls;

    [SerializeField]
    private bool goToSpecifiedDest;
    [SerializeField]
    private bool goToOrigin;

    private int _cooldown;

    void Update() {
        _cooldown--;
    }

    void OnCollisionEnter(Collision plr)
    {
        if (plr.gameObject.tag == "Player" && _cooldown < 0)
        {
            _cooldown = 60;
            foreach (GameObject wall in movingWalls)
            {
                if (wall.GetComponent<MoveToDest>() != null && movingWalls != null) {
                    var moveToDest = wall.GetComponent<MoveToDest>();
                    moveToDest.SetActive();
                    if (goToSpecifiedDest) moveToDest.SetDest(goToOrigin);
                }
                else Debug.Log("wrong target");
            }
        }
    }

    void OnCollisionExit(Collision obj)
    {
        if (Application.loadedLevelName == "Level10")
        {
            if (obj.gameObject.tag == "Player")
            {
                foreach (GameObject wall in movingWalls)
                {
                    if (wall.GetComponent<MoveToDest>() != null)
                    {
                        var moveToDest = wall.GetComponent<MoveToDest>();
                        moveToDest.SetActive();
                        if (goToSpecifiedDest) moveToDest.SetDest(goToOrigin);
                    }
                }
            }
        }
    }
}