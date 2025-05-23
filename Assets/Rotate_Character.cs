using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate_Character : MonoBehaviour
{
    [SerializeField] GameObject theCharacter;
    [SerializeField] float rotateSpeed = 10f;
    Vector2 lastMousPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastMousPos = Mouse.current.position.ReadValue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastMousPos = Mouse.current.position.ReadValue();
        }
        if (Input.GetMouseButton(0))
        {
            float diff = lastMousPos.x - Mouse.current.position.ReadValue().x;
            theCharacter.transform.Rotate(0, diff * rotateSpeed, 0);
            lastMousPos = Mouse.current.position.ReadValue();
        }
        
    }
}
