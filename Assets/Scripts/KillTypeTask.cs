using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/KillTypeTask")]
public class KillTypeTask : ScriptableObject, ITask
{
    [SerializeField] private TargetType requiredType;
    [SerializeField] private int targetCount = 10;
    private int _currentCount;
    
    public string DisplayProgress => $"{_currentCount} / {targetCount}";
    public bool IsCompleted => _currentCount >= targetCount;

    public void Activate()
    {
        _currentCount = 0;
        TaskController.Instance.OnTargetKilled += HandleKill;
    }

    public void Deactivate()
    {
        TaskController.Instance.OnTargetKilled -= HandleKill;
    }

    private void HandleKill(ITarget target)
    {
        if (IsCompleted) return;
        if (target.Type == requiredType)
            _currentCount++;
    }
}