using UnityEngine;
using System.Collections;

public class GrappleTip : MonoBehaviour {
	Transform grappleHook;
	// Use this for initialization
	void Start () {
		grappleHook = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Wall" && !grappleHook.GetComponent<GrapplerHook>().IsGrappleLatched()) {
			Debug.Log ("Latching the grapple", transform);
			grappleHook.GetComponent<GrapplerHook>().LatchGrapple();
		}
	}
}
