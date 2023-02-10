using System;
using UnityEngine;
using Zenject;


public class HeroMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;
    private MobileInputService _mobileInputService;
    
    [Inject]
    public void Construct(MobileInputService mobileInputService)
    {
        _mobileInputService = mobileInputService;
    }

    private void OnEnable()
    {
        _mobileInputService.OnJoystickDragged += Move;
        _mobileInputService.OnJoystickDragEnded += MoveEnd;
    }

    private void OnDisable()
    {
        _mobileInputService.OnJoystickDragged -= Move;
        _mobileInputService.OnJoystickDragEnded -= MoveEnd;
    }

    private void Move(Vector2 dir)
    {
        _animator.SetBool("Running",true);
        Vector3 movementVector = new Vector3(dir.x, 0, dir.y);
        transform.forward = movementVector;
        _characterController.Move(movementVector * _movementSpeed * Time.deltaTime);
    }

    private void MoveEnd()
    {
        _animator.SetBool("Running",false);
    }
}
