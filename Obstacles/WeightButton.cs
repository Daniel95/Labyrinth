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

    void OnCollisionEnter(Collision plr)
    {
        if (plr.gameObject.tag == "Player")
        {
            foreach (GameObject wall in movingWalls)
            {
                if (wall.GetComponent<MoveToDest>() != null) {
                    var moveToDest = wall.GetComponent<MoveToDest>();
                    moveToDest.SetActive();
                    if (goToSpecifiedDest) moveToDest.SetDest(goToOrigin);
                }
                else Debug.Log("wrong target");
            }
        }
    }

}