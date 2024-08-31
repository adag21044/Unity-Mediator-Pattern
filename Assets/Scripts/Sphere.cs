using UnityEngine;

public class Sphere : Shape
{
    public void Setup(IMediator mediator, string name)
    {
        Initialize(mediator, name);
    }

    public override void SendCustomMessage(string message)
    {
        Debug.Log("Sphere sends message: " + message);
        mediator.SendMessage(this, message);
    }

    public override void ReceiveCustomMessage(string sender, string message)
    {
        Debug.Log("Sphere receives message: " + message + " from " + sender);
    }
}
