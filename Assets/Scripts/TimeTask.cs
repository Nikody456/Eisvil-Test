using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/TimeTask")]
public class TimeTask : ScriptableObject, ITask
{
    [SerializeField] private float requiredTime = 120f;
    private float _elapsedTime;
    
    public string DisplayProgress => $"{(int)(Progress * 100)}%";
    public float Progress => Mathf.Clamp01(_elapsedTime / requiredTime);
    public bool IsCompleted => _elapsedTime >= requiredTime;

    public void Activate()
    {
        _elapsedTime = 0f;
        TaskController.Instance.OnTimeUpdated += HandleTime;
    }

    public void Deactivate()
    {
        TaskController.Instance.OnTimeUpdated -= HandleTime;
    }

    private void HandleTime(float deltaTime)
    {
        if (IsCompleted) return;
        _elapsedTime += deltaTime;
    }
}