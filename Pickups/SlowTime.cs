using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour
{
	[SerializeField]
	private float slowStartValue;

	//private float _slowValue;

	void OnTriggerEnter(Collider obj)
	{
		if (obj.tag == "Player") {
			SetTime(slowStartValue);
			Destroy(this.gameObject);
		}
	}

	public void SetTime(float slowStartValue){
		Time.timeScale = 0;


		for (float t = 0; t < 1; t += Time.deltaTime){
			//Time.timeScale += Time.timeScale / 1000;
			Time.timeScale += Time.deltaTime;
			Debug.Log("corauass");
			//WaitForSeconds(1);
		}
		//StartCoroutine("TimeIncrement");
	}

	IEnumerator TimeIncrement() {
		//while (Time.timeScale < 1) {
		for (float t = 0; t < 1; t += Time.deltaTime){
			//Time.timeScale += Time.timeScale / 1000;
			Time.timeScale += Time.deltaTime;
			Debug.Log("corauass");
			//WaitForSeconds(1);
			yield return null;
		}
		Time.timeScale = 1;
		Debug.Log("end");
	}
}

