using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController Instance { get; private set; }

    public event Action<float> OnTimeUpdated;
    public event Action<ITarget> OnTargetKilled;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        OnTimeUpdated?.Invoke(Time.deltaTime);
    }

    public void RegisterKill(ITarget target)
    {
        OnTargetKilled?.Invoke(target);
    }
}
