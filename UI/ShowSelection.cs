using UnityEngine;
using System.Collections;

public class ShowSelection : MonoBehaviour {
    [SerializeField]
    private float heigth = 0f;
    [SerializeField]
    private GameObject cam;
    
	// Use this for initialization
	void Start () {
	    
	}
    
    void OnMouseEnter()
    {
        Vector3 temp = cam.transform.position; // copy to an auxiliary variable...
        temp.y = heigth * 10 +38; // modify the component you want in the variable...
        cam.transform.position = temp; // and save the modified value 

        //cam.transform.position.y = heigth * 30f;
    }
   

    // Update is called once per frame
    void Update () {
	
	}
}
