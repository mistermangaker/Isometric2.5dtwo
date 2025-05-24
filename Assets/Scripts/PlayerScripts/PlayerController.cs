using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class PlayerController : MonoBehaviour
{

    private Rigidbody ridgedbody;
    public float movespeed = 5f;
    public Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ridgedbody = GetComponent<Rigidbody>();
    }

    public void OnMove(CallbackContext callbackContext)
    {
        Vector2 temp = callbackContext.ReadValue<Vector2>();
        Vector3 inputdir = new Vector3(temp.x, 0, temp.y);
        moveDirection = transform.TransformDirection(inputdir);
        moveDirection.Normalize();
    }

    public void FixedUpdate()
    {
        ridgedbody.linearVelocity  = moveDirection * movespeed;
    }


}
