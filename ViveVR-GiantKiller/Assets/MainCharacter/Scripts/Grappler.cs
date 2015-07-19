using UnityEngine;
using System.Collections;

public class Grappler : MonoBehaviour {
	public string grappleTrigger;
	public string grappleRelease;

	public float pullForce;
	
	// Use this for initialization
	private Transform grappleHook;
	void Start () {
		grappleHook = transform.Find ("GrapplerHook");
	}

	// Update is called once per frame
	void Update () {
		ShootGrapple ();
		PullGrapple ();
		ReleaseGrapple ();
	}



	void ShootGrapple(){
		// Only if the grapple has been sheathed and if the player pressed the trigger to shoot grapple
		if (Input.GetButtonDown(grappleTrigger) && grappleHook.GetComponent<GrapplerHook>().IsGrappleReady()) {
			// Shoot the actual grapple
			Vector3 firingDirection = transform.Find("Aim").position - transform.position;
			grappleHook.GetComponent<GrapplerHook>().ShootGrapple(firingDirection);
		}
	}
	
	void PullGrapple(){
		if (Input.GetButton (grappleTrigger) && grappleHook.GetComponent<GrapplerHook> ().IsGrappleLatched ()) {
			// Get unit vector
			Vector3 direction = grappleHook.localPosition;
			direction.Normalize ();
			Debug.Log("Pull Grapple normal" + direction*pullForce, transform); 
			transform.parent.GetComponent<Rigidbody>().AddForce(direction * pullForce);
			// Pull character towards grapple by applying force/impulse by the unit vector 'direction'
		}
	}

	void ReleaseGrapple(){
		if (Input.GetButtonDown(grappleRelease) && grappleHook.GetComponent<GrapplerHook>().IsGrappleLatched()){
			// Send release to grapple endpoint
			Debug.Log("Release the grapple", transform); 
			grappleHook.GetComponent<GrapplerHook>().UnLatchGrapple();
		}
	}
}
