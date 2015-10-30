using UnityEngine;
using System.Collections;

public class PortalHandeler : MonoBehaviour
{
	[SerializeField]
	private GameObject otherPortal;
	private bool oneWay = false;
	
	private PortalHandeler otherPortalHandeler;
	private bool justSpawned = false;

    private AudioSource _teleportSound;
	
	void Awake()
	{
		if (otherPortal.GetComponent<PortalHandeler>() != null) oneWay = false;
		else oneWay = true;
		
		if (!oneWay) otherPortalHandeler = otherPortal.GetComponent<PortalHandeler>();

        _teleportSound = (AudioSource)gameObject.AddComponent<AudioSource>();
        _teleportSound.clip = (AudioClip)Resources.Load("Audio/portal");
        _teleportSound.volume = 1;
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && justSpawned == false)
		{
            _teleportSound.Play();
			if (!oneWay) otherPortalHandeler.spawned = true;
			other.transform.position = new Vector3(otherPortal.transform.position.x, otherPortal.transform.position.y + 0.8f, otherPortal.transform.position.z);
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && !oneWay)
		{
			justSpawned = false;
		}
	}
	
	public bool spawned
	{
		get { return justSpawned; }
		set { justSpawned = value; }
	}
}
