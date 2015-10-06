using UnityEngine;
using System.Collections;

public class StartCinematic : MonoBehaviour {
    [SerializeField]
    private Transform GoToPoint;
    private Vector3 offset;
    private Vector3 rotationOffset;

    private float moveSpeed = 1.01f;
    private float goSpeed;
    private bool gointToPlayer;

    void Start() {
        newVals();
        goSpeed = moveSpeed;
    }

    void newVals()
    {
        //resetting the value's for going to the next point
        goSpeed = moveSpeed;
        offset = (transform.position - GoToPoint.position);
        rotationOffset = (transform.eulerAngles - GoToPoint.transform.eulerAngles);
    }
	
	void Update () {
        //Making the speed a bit more constand
        goSpeed += goSpeed / 1000f;
        
        //changing the distance the camera needs to travel to the position
        offset /= goSpeed;
        rotationOffset /= goSpeed;

        //chaniging the actual camera position
        transform.position = offset + GoToPoint.position;
        transform.eulerAngles = rotationOffset + GoToPoint.eulerAngles;

        //going to the next point
        if (Vector3.Distance(transform.position, GoToPoint.position) == 0)
        {
            if (gointToPlayer) Destroy(this);
            else
            {
                if (GoToPoint.gameObject.GetComponent<NextPoint>().newPos.gameObject.tag == "Player")
                {
                    GoToPoint = GetComponent<CameraFollow>().PlayerCam;
                    goSpeed = moveSpeed; newVals(); gointToPlayer = true;
                }
                else
                {
                    Destroy(GoToPoint.gameObject);
                    GoToPoint = GoToPoint.gameObject.GetComponent<NextPoint>().newPos;
                    goSpeed = moveSpeed; newVals();
                }
            }
        }
	}
}
