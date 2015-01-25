using UnityEngine;
using System; 					
using System.Collections;

public class Player : MonoBehaviour {

	#region Fields
	
	public enum Turn {
		left = -1,
		none = 0,
		right = 1
	}

	public float energy = 100f;
	public float maxEnergy = 100f;
	public float decayRate = 5f;
	public float regenRate = 2f;
	public float pingForce = 10f;
	public float pingHoldTime = 1f;
	public float rotateSpeed = 250f;
	public string nextLevel = "Level 1";


	private bool _pinging;	
	private float _appliedPingForce;
	private CharacterMotor _motor;
	private Vector3 _initPos;
	private Rect _rect = new Rect(10, 10, 100, 24);
	private Turn _turn;
	private Transform _transform;
	private ParticlesBursts _bursts;
	#endregion
	
	
	#region Unity Functions
	void Awake() {
		_bursts = GetComponent<ParticlesBursts> ();
		_motor = GetComponent<CharacterMotor>();
		_transform = transform;
	}	
	void Start () {
		_initPos = transform.position;
		if (pingHoldTime == 0)
			pingHoldTime = 1f;
		_turn = Turn.none;
	}	
	void Update () {
		_pinging = false; //wip
		//_transform.Rotate(0,0, (int)_turn * Time.deltaTime * rotateSpeed);
		//_transform.Rotate(_motor.Direction);

		if (_motor.IsMoving) {
			energy = Mathf.Clamp (energy - decayRate * Time.deltaTime, 0, maxEnergy);
		}
		else {
			energy = Mathf.Clamp (energy + regenRate * Time.deltaTime, 0, maxEnergy);
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.transform.CompareTag("Destination")) {
			Debug.Log ("Player::OnTriggerEnter() Dest");
			//Reset ();
			// WIP
			// Do animation
			Application.LoadLevel (nextLevel);
		}
	}
	void OnGUI() {
		
		string sOut = String.Format("Energy {0}/{1}",
		                            Mathf.Floor (energy),
		                            maxEnergy);
		GUI.Label(_rect, sOut);

	}

	#endregion
	
	
	#region Extra Functions
	private void Reset() {
		transform.position = _initPos;
		energy = maxEnergy;
	}
	
	public void Ping(float elapsed) {
		Debug.Log("PlayerInputController::Ping()");
		_appliedPingForce = elapsed/pingHoldTime;
		Debug.Log("\t_appliedPingForce: " + _appliedPingForce);

		_bursts.Burst (BurstType.REGULAR, _appliedPingForce, _motor.transform.position);
		_pinging = true;
		_appliedPingForce = 0;
	}
	void PingExtra() {
		if (rigidbody.velocity == Vector3.zero) {
			//rigidbody.velocity = Vector3.up * _appliedJumpForce; //account for sleeping physics
			//Debug.Log("BallMotor::Jump() using rigidbody.velocity");
			
		}
		else {
			//rigidbody.AddForce(Vector3.up * _appliedJumpForce, ForceMode.VelocityChange);
			//Debug.Log("BallMotor::Jump() using rigidbody.AddForce");
		}
	}
	#endregion
}
