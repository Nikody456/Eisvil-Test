using UnityEngine;

public class TaskUIController : MonoBehaviour
{
    [Header("UI")]
    public TaskUIItem[] taskUIItems;

    [Header("Tasks (ScriptableObjects)")]
    public ScriptableObject[] taskObjects;

    private ITask[] _tasks;

    private void Start()
    {
        _tasks = new ITask[taskObjects.Length];

        for (int i = 0; i < taskObjects.Length; i++)
        {
            if (taskObjects[i] is ITask task)
            {
                _tasks[i] = task;
                task.Activate();
                taskUIItems[i].Setup(task);
            }
        }

        TaskController.Instance.OnTimeUpdated += _ => UpdateAll();
        TaskController.Instance.OnTargetKilled += _ => UpdateAll();
    }

    private void UpdateAll()
    {
        foreach (var item in taskUIItems)
            item.UpdateUI();
    }
    
    private void OnDestroy()
    {
        foreach (var task in _tasks)
        {
            task?.Deactivate();
        }
    }
}