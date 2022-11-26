using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerMain Ply;
    void Start()
    {
        
    }

    //Input System
    public Controls control;
    void Awake()
    {
        Ply = gameObject.GetComponent<PlayerMain>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        _speed = Ply.Speed;
        _cam = Camera.main;

        control = new Controls();
        fireInput = control.Player.Fire;
        moveInput = control.Player.Move;
        
    }

    InputAction moveInput, fireInput, interact;
    void OnEnable()
    {
        moveInput.Enable();
        fireInput.Enable();

        control.Enable();
    }

    void OnDisable()
    {
        moveInput.Disable();
        fireInput.Disable();

        control.Disable();
    }

    //Movement input
    Camera _cam;
    Vector2 _moveDir;
    public Vector3 _mePos, _myTarget;
    void Update()
    {
        _moveDir = moveInput.ReadValue<Vector2>();

        if (fireInput.inProgress)
        {
            _myTarget = Mouse.current.position.ReadValue();
            _mePos = gameObject.transform.position;

            Ply.Attack(_myTarget, _mePos);
            
        }
    }

    //Input translates to movement per realtime second.
    float _speed;
    Rigidbody2D rb;
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(_moveDir.x * _speed, _moveDir.y * _speed);
    }
}
