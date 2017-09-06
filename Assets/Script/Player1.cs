using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

	public Animator animator;
	public Rigidbody rb;
	private float Horizontal;
	private float Vertical;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKey("a") || Input.GetKey("d")){
//			animator.Play("sprint_00",-1,0f);
//		}

		Horizontal = Input.GetAxis ("Horizontal");
		Vertical = Input.GetAxis ("Vertical");
	

		animator.SetFloat ("Horizontal", Horizontal);
		animator.SetFloat ("Veritcal", Vertical);
//		float moveX = Horizontal * 20f * Time.deltaTime;
//		float moveZ = Horizontal * 50f * Time.deltaTime;
//		rb.velocity = new Vector3 (.5f, moveX, 0); 
		if (Input.GetKey (KeyCode.D)){
			if (transform.eulerAngles.y>=265){
				transform.Rotate (new Vector3 (0, 180, 0));
			}
			transform.Translate (new Vector3(0,0,1) * 3f *Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)){
			if (transform.eulerAngles.y<=95){
				transform.Rotate (new Vector3 (0, 180, 0));
			}
			transform.Translate (new Vector3(0,0,1) * 3f *Time.deltaTime);
		}
	}
}
