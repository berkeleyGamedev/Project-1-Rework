using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Transform _camera;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private InputActionMap playerControls;

    private void OnEnable()
    {
        playerControls = actions.FindActionMap("Player");
        playerControls.Enable();
        playerControls.FindAction("Jump").performed += OnJump;
    }

    private void OnDisable()
    {
        playerControls.FindAction("Jump").performed -= OnJump;
        playerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 dir = playerControls.FindAction("Move").ReadValue<Vector2>();
        _rb.MovePosition(_rb.position + Vector3.Scale((_camera.transform.forward * dir.y + _camera.transform.right * dir.x), (Vector3.one - Vector3.up)) * speed * Time.deltaTime);
        _rb.PublishTransform();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _rb.linearVelocity = Vector3.Scale(_rb.linearVelocity, new Vector3(1, 0, 1));
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
