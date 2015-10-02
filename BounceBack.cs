using UnityEngine;
using System.Collections;

public class BounceBack : MonoBehaviour {

	private ContactPoint _contact;
	
	public void Bounce(Collision obj, int strength){
		this.GetComponent<Rigidbody>().AddForce(Vector3.Reflect(transform.position,obj.contacts[0].normal) * strength, ForceMode.Force);//this causes the ball to reflect off the surface
		this.transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);//this rotates the ball to face in the direction it is moving
	} 
}
