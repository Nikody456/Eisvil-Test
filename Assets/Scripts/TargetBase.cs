using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TargetBase : MonoBehaviour, ITarget
{
    [SerializeField] private TargetType targetType;
    public TargetType Type => targetType;

    private bool _isDead = false;

    public void Kill()
    {
        if (_isDead) return;
        _isDead = true;
        
        TaskController.Instance.RegisterKill(this);
        
        Destroy(gameObject);
    }
}