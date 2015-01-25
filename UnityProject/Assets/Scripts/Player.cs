/*
 * BUGS
 * 	fixed with WAIT: rotation doesn't reset as expected.
 * 	fixed with WAIT: energy reset dissipates on reset.
 * */
using UnityEngine;
using System; 					
using System.Collections;

public class Player : MonoBehaviour {

	#region Fields

	public enum State {
		wait,
		resting,
		ready,
		tired,
		pinging
	}

	public float energy = 100f;
	public float maxEnergy = 100f;
	public float decayRate = 5f;
	public float regenRate = 2f;
	public float pingForce = 10f;

	public float rotateSpeed = 25f;
	public float sleepTime = 3f;
	public float pingTime = 0.3f;
	public string nextLevel = "Level 1";

	public Color decoyTriggerColor = Color.red;

	public float resetHoldTime = 1f;

	private State _state;	
	private float _appliedPingForce;
	private CharacterMotor _motor;
	private Vector3 _initPos;
	private Rect _rect = new Rect(10, 10, 100, 24);
	private Transform _transform;
	private float _sleepTimer;
	private float _pingTimer;
	private String _sleepMsg;
	private bool _canRotate;
	private Animator _anim;
	private ParticlesBursts _bursts;
	#endregion
	
	
	#region Properties
	public State MoveState {
		get {return _state;}
	}
	#endregion
	#region Unity Functions
	void Awake() {
		_bursts = GetComponent<ParticlesBursts> ();
		_motor = GetComponent<CharacterMotor>();
		_transform = transform;
		//_anim = GetComponentInChildren<Animation>();
		_anim = GetComponentInChildren<Animator>();
		Debug.Log ("Player::Awake() _anim: " + _anim);
	}	
	void Start () {
		_initPos = _transform.position;
		//if (pingTime == 0)
		//	pingTime = 1f;

		Reset();
	}	
	void Update () {

		switch(_state) {
		case State.wait:
			UpdateWaiting();
			break;
		case State.resting:
			UpdateResting();
			break;
		case State.ready:
			UpdateReady();
			break;
		case State.tired:
			UpdateTired();
			break;
		case State.pinging:
			UpdatePinging();
			break;
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag("Wall")) {
			//Debug.Log ("Player::OnCollisionEnter() Wall");
			_canRotate = false;
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.transform.CompareTag("Wall")) {
			//Debug.Log ("Player::OnCollisionExit() Wall");
			_canRotate = true;
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.transform.CompareTag("Destination")) {
			Debug.Log ("Player::OnTriggerEnter() Dest");
			//Reset ();
			// WIP
			// Do animation
			Application.LoadLevel (nextLevel);
		} else if (other.transform.CompareTag("Decoy")) {
			BlackHole b = other.gameObject.GetComponent<BlackHole> ();
			if (b.gravity > 0) {
				b.gravity = -b.gravity;
				b.colorChange = decoyTriggerColor;
			}
		}
	}
	void OnGUI() {

		string sOut = (_state == State.resting) ? _sleepMsg : 
						String.Format("Energy {0}/{1}", Mathf.Floor (energy), maxEnergy);;

		GUI.Label(_rect, sOut);

	}

	#endregion
	
	
	#region Extra Functions
	private void Reset() {
		Debug.Log ("Player::Reset()");
		_transform.position = _initPos;
		_transform.rotation = Quaternion.Euler(Vector3.up);
		energy = maxEnergy;
		_state = State.wait;
		_canRotate = true;
		_motor.Reset ();
		_anim.Play("idle");
		Debug.Log ("reset rotation: " + _transform.rotation);
	}
	private void UpdateWaiting() {
		_sleepTimer += Time.deltaTime;
		if (_sleepTimer >= resetHoldTime) {
			_sleepTimer = 0;
			_state = State.ready;
		}
	}
	private void UpdateResting() {
		_sleepTimer += Time.deltaTime;
		_sleepMsg = String.Format("Retry in {0}s", sleepTime - Mathf.Floor (_sleepTimer));
		if (_sleepTimer >= sleepTime) {
			_sleepTimer = 0;
			_sleepMsg = "";
			Reset ();

			//change animation to ready
		}
	}
	private void UpdateReady() {
		
		if (energy <= 0) {
			_state = State.tired;
			Debug.Log ("Player::UpdateReady() _state = State.tired");
			return;
		}
		
		if (_motor.IsMoving) {
			//correctly doesn't fire after reset()
			//Debug.Log ("Player::UpdateReady() _motor.IsMoving");
			energy = Mathf.Clamp (energy - decayRate * Time.deltaTime, 0, maxEnergy);

			_anim.Play ("move");
		}
		else {

			//energy = Mathf.Clamp (energy + regenRate * Time.deltaTime, 0, maxEnergy);

			_anim.Play("idle");

		}

		if (_canRotate && _motor.Direction != Vector3.zero) {
			_transform.rotation = Quaternion.LookRotation(Vector3.forward, _motor.Direction);

			//float angle = Mathf.Atan2(_motor.Direction.y, _motor.Direction.x) * Mathf.Rad2Deg;
			//_transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			//if (_motor.Direction.magnitude > 1)
		}

		//transform.Rotate (Vector3.forward * -90 * Time.deltaTime * rotateSpeed);

		
	}
	
	private void UpdateTired() {
		Debug.Log ("Player::UpdateTired()");
		_state = State.resting;

		_bursts.Burst (BurstType.DEATH, 1, _motor.transform.position);

		//change animation to sleeping
		_anim.Play("sleep");
	}
	private void UpdatePinging() {
		_pingTimer += Time.deltaTime;
		if (_pingTimer > pingTime) {
			_pingTimer = 0;
			_state = State.ready;
			_anim.Play("move");
		}
	}
	public void Ping(float elapsed) {
		if (_state == State.tired) return;

		Debug.Log("PlayerInputController::Ping()");
		_appliedPingForce = elapsed/pingTime;
		Debug.Log("\t_appliedPingForce: " + _appliedPingForce);

		_bursts.Burst (BurstType.REGULAR, _appliedPingForce, _motor.transform.position);
		_appliedPingForce = 0;

		_anim.Play("ping");
		
		_state = State.pinging;
		
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
