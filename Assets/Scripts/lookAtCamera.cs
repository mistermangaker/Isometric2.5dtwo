using UnityEngine;

public class lookAtCamera : MonoBehaviour
{

    // Update is called once per frame
    public void Start()
    {
       transform.forward = Camera.main.transform.forward;
    }
    void Update()
    {
       
    }
}
