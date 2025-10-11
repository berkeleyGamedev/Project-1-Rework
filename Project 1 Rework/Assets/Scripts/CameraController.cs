using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public InputSystem_Actions actions;
    private Vector2 _mouseDelta;
    [SerializeField] Transform targetTransform;

    private float yRot;
    private float xRot;
    public float sens;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    //Event.current.mousePosition
    //    //_mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position);
    //    transform.rotation = Quaternion.Euler(xRot, yRot, transform.rotation.z);
    //    //transform.position = ExpDecay(transform.position, targetTransform.position, 20, Time.deltaTime);
    //    transform.position = targetTransform.position;
    //}

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(xRot, yRot, transform.rotation.z);
        transform.position = targetTransform.position;
        //transform.position = ExpDecay(transform.position, targetTransform.position, 20, Time.deltaTime);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
        xRot -= _mouseDelta.y * sens;
        yRot += _mouseDelta.x * sens;
        xRot = Mathf.Clamp(xRot, -90, 90);
    }

    //public void OnMouseMove (InputAction.CallbackContext context)
    //{
    //    _mousePos = context.ReadValue<Vector2>();
    //}

    private Vector3 ExpDecay(Vector3 a, Vector3 b, float decay, float dt)
    {
        return b + (a-b)*Mathf.Exp(-decay * dt);
    }
}
