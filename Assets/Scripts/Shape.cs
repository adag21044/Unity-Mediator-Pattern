using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    protected IMediator mediator;
    public string Name { get; private set; }

    public void Initialize(IMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
        mediator.RegisterShape(this);
    }

    public abstract void SendCustomMessage(string message);
    public abstract void ReceiveCustomMessage(string sender, string message);
}
