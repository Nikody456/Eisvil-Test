public interface ITask
{
    bool IsCompleted { get; }

    string DisplayProgress { get; }
    void Activate();
    void Deactivate();
}