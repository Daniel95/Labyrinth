using UnityEngine;
using System.Collections;

public class CarryOther : MonoBehaviour {

	[SerializeField]
	private string[] objsToInteract;

	private MoveToDest _moveToDest;

	void Start(){
		_moveToDest = GetComponent<MoveToDest>();
	}

	void OnCollisionStay(Collision obj) {
		foreach (string tag in objsToInteract) {
			if (obj.gameObject.tag == tag) {
				//checkActive returns true if the platform is moving.
				if(_moveToDest.checkActive) {
					//get the distance of the platform and tagged gameobject.
					var distance = obj.transform.position - transform.position;

					//returns the new position for the tagged object.
					var newPos = _moveToDest.GoToDest (obj.transform.position,distance);
					obj.transform.position = newPos;
				}
			}
		}
	}
}


