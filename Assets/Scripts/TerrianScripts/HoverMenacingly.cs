using Unity.VisualScripting;
using UnityEngine;

public class HoverMenacingly : MonoBehaviour
{
    //[SerializeField] private Transform rock;
    [SerializeField] private float leftRightMovementMax = 0.4f;
    private float _leftRightMovementMax;
    [SerializeField] private float upDownMovementMax = 0.4f;
    private float _upDownMovementMax;
    [SerializeField] private float forwardbackMovementMax = 0.4f;
    private float _forwardbackMovementMax;
    [SerializeField] private float moveSpeed = 0.2f;
    private float _moveSpeed;
    
    private Vector3 startPosition;
    private float moveX;
    private float moveY;
    private float moveZ;

    private bool left;
    private bool up;
    private bool forward;

    private bool shouldHover =true;

    [ContextMenu("start hover")]
    public void StartHovering()
    {
        shouldHover =true;
    }
    [ContextMenu("stop hover")]
    public void StopHovering()
    {
        shouldHover=false;
    }
    private void Start()
    {
        startPosition = transform.position;
        _leftRightMovementMax = leftRightMovementMax + Random.Range(0, (leftRightMovementMax * 0.1f));
        _upDownMovementMax = upDownMovementMax + Random.Range(0, (upDownMovementMax * 0.1f));
        _forwardbackMovementMax = forwardbackMovementMax + Random.Range(0, (forwardbackMovementMax * 0.1f));
        _moveSpeed = moveSpeed + Random.Range(0, (moveSpeed * 0.1f));
        float temp1 = Random.Range(-1f,1f);
        float temp2 = Random.Range(-1f, 1f);
        float temp3 = Random.Range(-1f, 1f);
        
        if (temp1 > 0) left = true;
        if (temp2 > 0) up = true;
        if (temp3 > 0) forward = true;
    }
    void FixedUpdate()
    {
        if (!shouldHover) return;
        if(left)
        {
            moveX += Time.deltaTime * _moveSpeed;
            if(moveX > _leftRightMovementMax)
            {
                left = false;
            }
        }
        else
        {
            moveX -= Time.deltaTime * _moveSpeed;
            if (moveX < -_leftRightMovementMax)
            {
                left = true;
            }
        }
        if (up)
        {
            moveY += Time.deltaTime * _moveSpeed;
            if (moveY > _upDownMovementMax)
            {
                up = false;
            }
        }
        else
        {
            moveY -= Time.deltaTime * _moveSpeed;
            if (moveY < -_upDownMovementMax)
            {
                up = true;
            }
        }
        if (forward)
        {
            moveZ += Time.deltaTime * _moveSpeed;
            if (moveZ > _forwardbackMovementMax)
            {
                forward = false;
            }
        }
        else
        {
            moveZ -= Time.deltaTime * _moveSpeed;
            if (moveZ < -_forwardbackMovementMax)
            {
                forward = true;
            }
        }
        transform.position = new Vector3(startPosition.x+moveX, startPosition.y+moveY, startPosition.z+moveZ);
    }
}
