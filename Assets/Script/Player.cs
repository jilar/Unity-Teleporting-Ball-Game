using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private float teleCooldown =.5f;
	private float cooldownTime=5f;
	public ParticleSystem ps;
	public float liftTime=0;
	private int life=2;
    public Text lifeText;
    public Text winText;
	public Text score;
	private int sc=0;
	public GameObject Enemy;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}



	void Update () {
			cooldownTime = cooldownTime + Time.deltaTime;
			if (cooldownTime < teleCooldown) {
			return;
			}	
			//right click go to front
			if (transform.position.y > -1) {
				if (Input.GetMouseButtonDown (1)) {
					if (transform.position.z == 0) {
						transform.position = new Vector3 (transform.position.x, transform.position.y + 1, -4);
						ps.Play ();
					} else if (transform.position.z == -4) {
						transform.position = new Vector3 (transform.position.x, transform.position.y + 1, -7);
						ps.Play ();
					}
				cooldownTime = 0;
					//left click go to back
				} else if (Input.GetMouseButtonDown (0)) {
					if (transform.position.z == -7) {
						transform.position = new Vector3 (transform.position.x, transform.position.y + 1, -4);
						ps.Play ();
					} else if (transform.position.z == -4) {
						transform.position = new Vector3 (transform.position.x, transform.position.y + 1, 0);
						ps.Play ();
					}
				cooldownTime = 0;
				}

			}
			
		if (transform.position.y < -10 && !(transform.position.x>=103.5f)) {
				if (life == 0) {
					winText.text = "You Lost!";
				} else {
					life--;
					transform.position = new Vector3 (0,.8f,-4);
					Enemy.transform.position = new Vector3 (-5,3,-4);
				}
				SetlifeText ();
		}
		if (transform.position.x>=103.5f && winText.text!="You Lost!") {
			winText.text = "You Win!";
		}

	}


	//called before performing any physics calcculations, where physics code go
	//in the game forces will be applied to the rigid body to move the ball
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0, 0);

		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup1")) {
			sc += 100;
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Pickup2")) {
			sc += 500;
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			life--;
		
			if (life < 0) {
				winText.text = "You Lost!";
				Destroy (gameObject);
				return;
			}
			SetlifeText ();
			transform.position = new Vector3 (0, .8f, -4);
			Enemy.transform.position = new Vector3 (-5, 3, -4);

		}
		score.text = "Score: " + sc.ToString ();
	}

	void SetlifeText(){
		lifeText.text = "Lives: " + life.ToString ();
	}

}
