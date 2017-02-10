using UnityEngine;

namespace Actor
{
	[AuthorAttribute ("JJ", TeamRole.Programmer)]
	public class ActorMovement : Character
	{
		CharacterController chCo;
		Animator anim;
		public bool grounded;
		public bool move2DOnly;
		public static GameObject metamorphosis;
		//Initialises character settings
		void Start ()
		{
			CharacterSettings ();
			chCo = GetComponentInParent<CharacterController> ();
			anim = GetComponentInChildren<Animator> ();
		}

		//Sets nma destination according to inputs.
		static int movementType;

		public static int MovementType {
			get {
				return movementType;
			}
			set {
				while (value > 4) {
					value -= 4;
				}
				if (value < 0) {
					value = 3;
				} else if (value > 3) {
					value = 0;
				}
				movementType = value;
			}
		}

		public static bool canInput = true;
		// Moves the actor and raycasts to determine if finish has been accessed.
		//256 is the number for the "Floor" layer
		void Update ()
		{
			MovementType += (int)Input.GetAxis ("Mouse ScrollWheel");
			//InputMoveType ();
			float h = Input.GetAxis ("Horizontal");
			float v = 0;
			if (!move2DOnly) {
				v = Input.GetAxis ("Vertical");
			}
			bool noInput = (h == 0 && v == 0) ? true : false;
			anim.SetBool ("Input", !noInput);
			//	Debug.Log (v + " " + h);
			Vector3 newPos = Vector3.zero;
			//	if (h > 0.2f || v > 0.2f) {
			if (canInput) {
				switch (MovementType) {
				case 0:
					newPos = new Vector3 (v, 0, h);
					break;
				case 2:
					newPos = new Vector3 (-v, 0, -h);
					break;
				case 1:
					newPos = new Vector3 (h, 0, -v);
					break;
				case 3:
					newPos = new Vector3 (-h, 0, v);
					break;
				}
			}
			CheckGround ();
			//	Debug.Log (MovementType);
			if (nma != null) {
				if (newPos != transform.position) {
					nma.SetDestination ((newPos * 0.5f) + transform.position);
					if (nma.speed != moveSpeed) {
						SetNMASpeed (moveSpeed);
					}
				}
			} else if (grounded) {
				chCo.Move (newPos * Time.deltaTime);
			} else {
				chCo.Move (-newPos * Time.deltaTime);
			}
		}
		//RAYCAST ALL 4 CORNERS
		void CheckGround ()
		{
			RaycastHit rayh;
			grounded = Physics.Raycast (transform.position, Vector3.down, out rayh, 1.8f, 256);
			/*	if (rayh.collider.tag == "Finish") {				
				Debug.Log ("LEVEL COMPLETE");
		}*/
		}

		public void Teleport (Vector3 v)
		{
			//	canInput = false;
			if (transform.position != v) {	
				if (nma != null) {
					nma.Warp (v);
				} else {		
					transform.position = v;
				}
			} else {
				//		canInput = true;
			}
		}

		public void InputMoveType (int i = 4)
		{
			if (i != 4) {
				MovementType = i;
			} else {
				if (Input.GetKey (KeyCode.Alpha0)) {
					MovementType = 0;
				} else if (Input.GetKey (KeyCode.Alpha1)) {
					MovementType = 1;
				} else if (Input.GetKey (KeyCode.Alpha2)) {
					MovementType = 2;
				} else if (Input.GetKey (KeyCode.Alpha3)) {
					MovementType = 3;
				}
			}
		}
	}
}
