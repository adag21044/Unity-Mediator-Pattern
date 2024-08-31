using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    protected IMediator mediator;
    public string Name { get; private set; }

    protected Shape(IMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
        mediator.RegisterToy(this);
    }

    public abstract void SendMessage(string message);
    public abstract void ReceiveMessage(string sender, string message);
}