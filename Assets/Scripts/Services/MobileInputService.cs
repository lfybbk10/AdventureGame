using System;
using UnityEngine;
using Zenject;

public class MobileInputService : UpdatableService
{
    public event Action<Vector2> OnJoystickDragged;
    public event Action OnJoystickDragEnded;

    private bool isJoystickDragging;

    private Joystick _joystick;

    [Inject]
    public MobileInputService(Joystick joystick, IUpdateService updateService) : base(updateService)
    {
        _joystick = joystick;
    }

    public override void FixedUpdate()
    {
        Debug.Log(_joystick.Horizontal+" "+_joystick.Vertical);
        Debug.Log(_joystick.Direction);
        if (Math.Abs(_joystick.Horizontal) > 0 || Math.Abs(_joystick.Vertical) > 0)
        {
            isJoystickDragging = true;
            OnJoystickDragged?.Invoke(new Vector2(_joystick.Horizontal,_joystick.Vertical));
        }
        else if (isJoystickDragging)
        {
            isJoystickDragging = false;
            OnJoystickDragEnded?.Invoke();
        }
    }
}
