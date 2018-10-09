using System.Collections;
using System.Collections.Generic;
using ObserverPattern;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject box1Obj;
	public GameObject box2Obj;
	public GameObject box3Obj;
	private Rigidbody rb; 

	//Will send notifications that something has happened to whoever is interested
	Subject subject = new Subject ();

	private void Start () {
		rb = GetComponent<Rigidbody>();
		//Create boxes that can observe events and give them an event to do
		Box box1 = new Box (box1Obj, new JumpLittle ());
		Box box2 = new Box (box2Obj, new JumpMedium ());
		Box box3 = new Box (box3Obj, new JumpHigh ());

		//Add the boxes to the list of objects waiting for something to happen
		subject.AddObserver (box1);
		subject.AddObserver (box2);
		subject.AddObserver (box3);
	}

	private void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.CompareTag ("box")) {
			subject.Notify ();
		}
	}

	private void LateUpdate () {

		float movementVertical = Input.GetAxis("Vertical");
		float movementHorizontal = Input.GetAxis("Horizontal");

		Vector3 movement = new Vector3(movementHorizontal, 0f, movementVertical);

		rb.AddForce(movement * 4);

	}
}