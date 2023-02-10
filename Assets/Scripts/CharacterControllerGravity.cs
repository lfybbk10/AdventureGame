
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerGravity : MonoBehaviour
{
    private CharacterController _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!_characterController.isGrounded)
        {
            _characterController.Move(Physics.gravity);
        }
    }
}
