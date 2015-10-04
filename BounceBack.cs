using UnityEngine;
using System.Collections;

public class BounceBack : MonoBehaviour {

	private ContactPoint _contact;

	public void Bounce(Collision obj, int strength){
		this.GetComponent<Rigidbody>().AddForce(Vector3.Reflect(transform.localPosition,obj.contacts[0].normal) * strength, ForceMode.Acceleration);//this causes the ball to reflect off the surface
		this.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);//this rotates the ball to face in the direction it is moving
	} 

	/*
	public void Bounce(Collision obj, int strength){
		var contactNormal = obj.contacts[0];
		var rot = Quaternion.FromToRotation(Vector3.up, contactNormal.normal);
		var pos = contactNormal.point;
		var rv = obj.relativeVelocity.magnitude;
		var direction = GetComponent<Rigidbody>().transform.position - pos;
		var reflectBallTo = Vector3.Reflect (pos, direction);
		this.GetComponent<Rigidbody>().AddForce (reflectBallTo * strength);
		this.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);//this rotates the ball to face in the direction it is moving
	}
	 */
}
