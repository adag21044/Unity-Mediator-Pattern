using UnityEngine;

public class Cube : Shape
{
    public void Setup(IMediator mediator)
    {
        Initialize(mediator, "Cube");
    }

    public override void SendCustomMessage(string message)
    {
        Debug.Log("Cube sends message: " + message);
        mediator.SendMessage(this, message);
    }

    public override void ReceiveCustomMessage(string sender, string message)
    {
        Debug.Log("Cube receives message: " + message + " from " + sender);
    }
}
