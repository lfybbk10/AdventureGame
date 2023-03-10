using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateService : MonoBehaviour, IUpdateService, ICoroutineRunner
{
    private readonly List<IUpdatableService> _services = new ();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void AddService(IUpdatableService service)
    {
        print("add service");
        _services.Add(service);
    }

    public void RemoveService(IUpdatableService service)
    {
        _services.Remove(service);
    }

    private void Update()
    {
        foreach (var service in _services)
        {
            service.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var service in _services)
        {
            service.FixedUpdate();
        }
    }
}
