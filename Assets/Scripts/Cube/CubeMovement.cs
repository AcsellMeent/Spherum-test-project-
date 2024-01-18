using UnityEngine;
using UnityEngine.InputSystem;

public enum InputType
{
    WASD,
    ARROW,
}

[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    private InputType _inputType;

    private InputActions _input;

    private Vector2 _moveDirection;

    [SerializeField]
    private float _moveSpeed;

    private void Awake()
    {
        _input = new InputActions();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Enable();
        switch (_inputType)
        {
            case InputType.WASD:
                _input.WASD.Movement.performed += OnMovementPerformed;
                _input.WASD.Movement.canceled += OnMovementCanceled;
                break;
            case InputType.ARROW:
                _input.ARROW.Movement.performed += OnMovementPerformed;
                _input.ARROW.Movement.canceled += OnMovementCanceled;
                break;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.MovePosition(_rigidbody.position + new Vector3(_moveDirection.x, 0, _moveDirection.y) / 10 * _moveSpeed);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveDirection = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        _moveDirection = Vector2.zero;
    }

    private void OnDisable()
    {
        switch (_inputType)
        {
            case InputType.WASD:
                _input.WASD.Movement.performed -= OnMovementPerformed;
                _input.WASD.Movement.canceled -= OnMovementCanceled;
                break;
            case InputType.ARROW:
                _input.ARROW.Movement.performed -= OnMovementPerformed;
                _input.ARROW.Movement.canceled -= OnMovementCanceled;
                break;
        }
        _input.Disable();
    }
}
