using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {
	
	#region Fields
	private CharacterMotor _motor;
	private Player _player;
	private float _pingTimer;
	private AudioSource[] _tones;
	#endregion

	#region Unity Functions
	void Awake() {
		_motor = GetComponent<CharacterMotor>();
		_player = GetComponent<Player>();
		_tones = GetComponents<AudioSource> ();
	}
	void Start () {
	}
	void Update () {
		if (_player.MoveState == Player.State.ready) {
			_motor.inputMoveDirection =  new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			_motor.inputMouseDirection =  new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			
			if (Input.GetButton("Ping")) {
				_pingTimer += Time.deltaTime;
			}
			if (Input.GetButtonUp("Ping")) {
				_player.Ping(_pingTimer);
				_pingTimer = 0;
				_tones[Mathf.FloorToInt(_player.energy / 15)].Play();
			}
		}
		else {
			_motor.inputMoveDirection = Vector3.zero;
			_motor.inputMouseDirection = Vector3.zero;
		}
	
		
		//TODO: decide on other inputs
		//_motor.inputCrawl = Input.GetKey(KeyCode.RightShift);
		//_motor.inputRun = Input.GetKey(KeyCode.LeftShift);
		
	}
	#endregion
}
