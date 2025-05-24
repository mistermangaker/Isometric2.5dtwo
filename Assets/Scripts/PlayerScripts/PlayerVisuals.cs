using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private ParticleSystem particles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.moveDirection != Vector3.zero)
        {
            particles.Play();
           
        }
        else
        {
            particles.Stop();
        }
    }
}
