using UnityEngine;
using System.Collections;

public class GrapplerHook : MonoBehaviour {
	public bool grappleLatched = false;
	public bool grappleReady = true;
	public bool fireGrapple = false;
	public bool retrieveGrapple = false;
	
	public float maxLength = 75.0F;
	public float grappleSpeed = 400.0F;
	public float retrieveSpeed = 400.0F;

	private Vector3 firedDirection;
	private Rigidbody rb;

	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkGrappleReady ();
		GrappleFiring ();
	}

	public bool IsGrappleLatched(){
		return grappleLatched;
	}

	public void LatchGrapple(){
		grappleLatched = true;
		fireGrapple = false;
		retrieveGrapple = false;
		rb.velocity = Vector3.zero;
	}

	public void UnLatchGrapple(){
		retrieveGrapple = true;
		grappleLatched = false;
		Debug.Log ("Unlatch the grapple", transform);
	}

	public bool IsGrappleReady(){
		return grappleReady;
	}

	public void checkGrappleReady(){
		if( transform.localPosition.magnitude < 0.5F && !fireGrapple && !grappleLatched){
			transform.localPosition = Vector3.zero;
			rb.velocity = Vector3.zero;
			grappleReady = true;
			retrieveGrapple = false;
		} else {
			grappleReady = false;
		}
	}

	public void ShootGrapple(Vector3 direction){
		fireGrapple = true;
		firedDirection = direction.normalized;
		Debug.Log ("Shooting the grapple." + firedDirection, transform);
	}

	public void GrappleFiring(){
		if (fireGrapple && transform.localPosition.magnitude < maxLength) {
			rb.velocity = firedDirection * grappleSpeed;
		} else if (fireGrapple && transform.localPosition.magnitude >= maxLength) {
			rb.velocity = Vector3.zero;
			fireGrapple = false;
			retrieveGrapple = true;
		} else if (retrieveGrapple) {
			rb.velocity = transform.localPosition.normalized * -1 * retrieveSpeed;
		}
	}
}