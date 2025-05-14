public interface ITarget
{
    TargetType Type { get; }
    void Kill();
}
