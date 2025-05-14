using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskUIItem : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI progressText;
    public Image background;

    private ITask _task;

    public void Setup(ITask task)
    {
        this._task = task;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (_task == null) return;
        
        progressText.text = _task.IsCompleted ? "" : _task.DisplayProgress;

        if (background != null)
            background.color = _task.IsCompleted ? Color.green : Color.white;
    }
}