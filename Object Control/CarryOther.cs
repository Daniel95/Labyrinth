using UnityEngine;
using System.Collections;

public class CarryOther : MonoBehaviour {

	[SerializeField]
	private string[] objsToInteract;

	private Transform _world;

	private GameObject _emptyObject;

	private Vector3 _originalScale;

	void Start()
	{
		_emptyObject = new GameObject();
		_world = GameObject.Find("World").transform;
	}

	void OnCollisionEnter(Collision obj) {
		foreach (string tag in objsToInteract) {
			if (obj.gameObject.tag == tag) {
				_originalScale = obj.transform.localScale;
				//obj.transform.parent = transform;
				//obj.transform.localScale = _originalScale;

				//_emptyObject.transform.parent = transform;
				//obj.transform.parent = _emptyObject.transform;
				_emptyObject.transform.SetParent(transform, true);
				obj.transform.SetParent(_emptyObject.transform, true);
				//obj.transform.localScale = _originalScale;

				//obj.transform.SetParent(this.transform, true);//obj.transform.parent = this.transform;
			}
		}
	}
	
	void OnCollisionExit(Collision obj) {
		foreach (string tag in objsToInteract) {
			if (obj.gameObject.tag == tag) {




				obj.transform.parent = _world;
				obj.transform.localScale = _originalScale;

				//if (obj.gameObject.tag == tag) obj.transform.SetParent(_world);;
			}
		}
	}

}


