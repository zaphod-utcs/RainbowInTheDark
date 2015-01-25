using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

	#region Fields
	public Vector3 inputMoveDirection;
	public Vector2 inputMouseDirection;
	public float moveForce = 10f;
	public float maxSpeed  = 10f;
	public float minSpeed  = 0.05f;
	public float drag  = 0.05f;
	
	
	private Transform _transform;
	private Transform _camera;
	private RaycastHit _hit;
	private Vector3 _prevPos;
	private Vector3 _direction;
	private float _appliedForce;
	
	private Rigidbody _rigidbody;
	
	#endregion
	
	#region Properties
	public Vector3 Direction {
		get {return _direction;}
	}
	public bool IsMoving {
		get {return inputMoveDirection != Vector3.zero;}
	}
	#endregion
	
	#region Unity Functions
	void Awake() {
		_transform = transform;
		_rigidbody = rigidbody;
	}
	void Start () {
		_prevPos = _transform.position;
	}
	void Update() {
		_direction = Vector3.Normalize(_transform.position - _prevPos);
		_prevPos = _transform.position;
	}
	void FixedUpdate() {	
		rigidbody.velocity = inputMoveDirection * maxSpeed;
	}
	#endregion
	
	#region Extra Functions
	public void Reset() {
		inputMoveDirection = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
		_direction = Vector3.up;
	}
	#endregion
}
