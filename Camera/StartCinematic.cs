using UnityEngine;
using System.Collections;

public class StartCinematic : MonoBehaviour {

    //execute all this with: 
    //GameObject.Find("Main Camera").GetComponent<StartCinematic>().newVals(GameObject.Find("NameOfFirstPoint").transform);

    private Transform GoToPoint; //The point it needs to travel to
    private Vector3 offset; //The diverence between the amera position and the destination point
    private Vector3 rotationOffset; //The divrerence between the camera rotation and the destination rotation
    private MoveWorld mWorld; //Move world script
    [SerializeField]
    private float moveSpeed = 10; //The speed at witch the animation moves
    private float goSpeed; //Used to stabilise the speed
    private bool gointToPlayer, doCinematic, skip; //toggle bools

    void Start() {
        mWorld = GameObject.Find("World").GetComponent<MoveWorld>();
    }

    void Update() {
        if (doCinematic) DoCinematic();
    }

    //resetting the value's for going to the next point
    public void newVals(Transform NewPoint)
    {
        //Setting the states for the cinematic
        GoToPoint = NewPoint; goSpeed = 1; doCinematic = true; mWorld.DoMoveWorld = false;
        //Calculating the offset position
        offset = (transform.position - GoToPoint.position);
        //Calculating the rotation offset
        rotationOffset = (transform.eulerAngles - GoToPoint.transform.eulerAngles);
    }
	
	void DoCinematic () {
        print(GoToPoint);
        //Making the speed a bit more constand
        goSpeed += goSpeed / (moveSpeed * 100);
        
        //changing the distance the camera needs to travel to the position
        offset /= goSpeed;
        rotationOffset /= goSpeed;

        //chaniging the actual camera position
        transform.position = offset + GoToPoint.position;
        transform.eulerAngles = rotationOffset + GoToPoint.eulerAngles;

        //going to the next point
        if (Vector3.Distance(transform.position, GoToPoint.position) == 0 || skip)
        {
            if (skip) transform.eulerAngles = GoToPoint.eulerAngles; transform.position = GoToPoint.position; skip = false;
            //End cinematic
            if (gointToPlayer) { mWorld.DoMoveWorld = true; doCinematic = false; gointToPlayer = false; skip = false; }
            else
            {
                //Prepare for flying to the player
                if (GoToPoint.gameObject.GetComponent<NextPoint>().newPos.gameObject.tag == "Player")
                {
                    newVals(GetComponent<CameraFollow>().PlayerCam); gointToPlayer = true;
                }
                //Prepare going to the next point
                else
                {
                    goSpeed = 1; newVals(GoToPoint.gameObject.GetComponent<NextPoint>().newPos);
                }
            }
        }
	}

    public bool Skip {
        get { return skip; }
        set { skip = value; }
    }
}
