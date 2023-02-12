using System;
using UnityEngine;
using Zenject;


public class SaveTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    
    private IProgressService _progressService;

    [Inject]
    public void Construct(IProgressService progressService)
    {
        _progressService = progressService;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("save progress");
        _progressService.SaveProgress();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(_collider.center,_collider.size);
        Gizmos.color = Color.white;
    }
}
