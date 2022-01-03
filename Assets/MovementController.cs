using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform headTransform;

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float gravity;
    [SerializeField] float jumpHeight;

    // Start is called before the first frame update
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    float verticalSpeed;
    // Update is called once per frame
    void Update()
    {
        //Get Input
        Vector2 kbInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        bool pressingJump = Input.GetKey(KeyCode.Space);

        //Calculate limit
        float min = Vector3.SignedAngle(headTransform.forward, Vector3.up, headTransform.right);
        if (min > 0) min -= 360;
        float max = Vector3.SignedAngle(headTransform.forward, -Vector3.up, headTransform.right);
        if (max < 0) max += 360;

        //Rotate
        characterController.transform.Rotate(new Vector3(0, mouseInput.x, 0) * rotationSpeed * Time.deltaTime);
        headTransform.Rotate(new Vector3(Mathf.Clamp(-mouseInput.y * rotationSpeed * Time.deltaTime, min, max), 0, 0));

        //Move
        characterController.Move((characterController.transform.forward * kbInput.y + characterController.transform.right * kbInput.x) * movementSpeed * Time.deltaTime);

        //Gravity
        characterController.Move(Vector3.up * verticalSpeed * Time.deltaTime);
        if (characterController.collisionFlags!=CollisionFlags.Below && characterController.collisionFlags!=CollisionFlags.Above)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            verticalSpeed = 0;
        }
        if (pressingJump && characterController.collisionFlags == CollisionFlags.Below)
        {
            verticalSpeed += Mathf.Sqrt(2 * gravity * jumpHeight);
        }
    }
}
