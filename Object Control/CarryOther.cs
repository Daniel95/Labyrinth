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
				if(_moveToDest.checkActive) {
					var move = _moveToDest.GoToDest (obj.transform.position);
					obj.transform.position = move;
				}
			}
		}
	}
}


