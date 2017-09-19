using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;

	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;

	public GameObject skillshot;

	private bool shooting;
	public float shootingTime;
	private float shootingTimeCounter;

	private int gos;

	private PlayerHealthManager plyr;

	private SFXManager sfxMan;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		plyr = FindObjectOfType<PlayerHealthManager>();
		sfxMan = FindObjectOfType<SFXManager> ();



		if (!playerExists) 
		{
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else 
		{
			Destroy (gameObject);
		}


		lastMove = new Vector2 (0, -1f);

	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!attacking && !shooting) 
		{			
			
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
			{
				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
			{
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
			{
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);

			}

			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);

				sfxMan.playerAttack.Play ();
			}

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			} else {
				currentMoveSpeed = moveSpeed;
			}

			if ((Input.GetKeyDown (KeyCode.E)) && (plyr.playerCurrentMana > 9)) 
			{
				plyr.TakeAwayMana(10);
				sfxMan.playerShoot.Play ();

				shootingTimeCounter = shootingTime;
				shooting = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Shoot", true);

				GameObject newSkillshot = Instantiate (skillshot, transform.position, transform.rotation);
				shooting = true;
				if (lastMove.x > 0.5f) {
					newSkillshot.GetComponent<Rigidbody2D> ().transform.Rotate (0, 0, 180);
					newSkillshot.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (-300f, 0f));
				} else if (lastMove.x < -0.5f) {
					newSkillshot.GetComponent<Rigidbody2D> ().transform.Rotate (0, 0, 0);
					newSkillshot.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (-300f, 0f));
				} else if (lastMove.y > 0.5) {
					newSkillshot.GetComponent<Rigidbody2D> ().transform.Rotate (0, 0, 270);
					newSkillshot.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (-300f, 0f));
				} else {
					newSkillshot.GetComponent<Rigidbody2D> ().transform.Rotate (0,0,90);
					newSkillshot.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (-300f, 0f));
				}


			}

		}

		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		if (shootingTimeCounter > 0) 
		{
			shootingTimeCounter -= Time.deltaTime;
		}

		if (shootingTimeCounter <= 0) 
		{
			shooting = false;
			anim.SetBool ("Shoot", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);


		gos = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (gos <= 0) {
			Destroy(GameObject.Find("prolaz"));

		}

	
	}

}
