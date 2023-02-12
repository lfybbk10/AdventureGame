using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class HeroMove : MonoBehaviour, ISavedProgress, ILoadedProgress
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;
    private MobileInputService _mobileInputService;
    private IProgressService _progressService;
    
    [Inject]
    public void Construct(MobileInputService mobileInputService, IProgressService progressService)
    {
        _mobileInputService = mobileInputService;
        _progressService = progressService;
        
    }

    private void OnEnable()
    {
        _mobileInputService.OnJoystickDragged += Move;
        _mobileInputService.OnJoystickDragEnded += MoveEnd;

        _progressService.OnSaveProgress += SaveProgress;
        _progressService.OnLoadProgress += LoadProgress;
    }

    private void OnDisable()
    {
        _mobileInputService.OnJoystickDragged -= Move;
        _mobileInputService.OnJoystickDragEnded -= MoveEnd;
        
        _progressService.OnSaveProgress -= SaveProgress;
        _progressService.OnLoadProgress -= LoadProgress;
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

    public void SaveProgress(PlayerProgress progress)
    {
        progress.WorldData.HeroPositionOnLevel.Position = transform.position.AsVectorData();
    }

    public void LoadProgress(PlayerProgress progress)
    {
        if (CurrentLevel() != progress.WorldData.HeroPositionOnLevel.LevelName) return;

        Vector3Data savedPosition = progress.WorldData.HeroPositionOnLevel.Position;
        if (savedPosition != null) 
            SetSpawnPoint(savedPosition);
    }
    
    private string CurrentLevel() => 
        SceneManager.GetActiveScene().name;
    
    private void SetSpawnPoint(Vector3Data point)
    {
        _characterController.enabled = false;
        transform.position = point.AsUnityVector().AddY(_characterController.height);
        _characterController.enabled = true;
    }
}
