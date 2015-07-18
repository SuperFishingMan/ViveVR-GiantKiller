using UnityEngine;
using System.Collections;

public class Grappler : MonoBehaviour {
	public string grappleTrigger;
	public string grappleRelease;

	public bool grappleLatched = false;
	public bool grappleReady = true;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		ShootGrapple ();
		PullGrapple ();
		ReleaseGrapple ();
	}



	void ShootGrapple(){
		// Only if the grapple has been sheathed and if the player pressed the trigger to shoot grapple
		if (grappleReady && Input.GetButtonDown(grappleTrigger)) {
			// Shoot the actual grapple
		}
	}
	
	void PullGrapple(){
		if (grappleLatched && Input.GetButton(grappleTrigger)){
			// Pull character towards grapple by applying force
		}
	}

	void ReleaseGrapple(){
		if (grappleLatched && Input.GetButtonDown(grappleRelease)){
			// Send release to grapple endpoint
			grappleLatched = false;
		}
	}
}
