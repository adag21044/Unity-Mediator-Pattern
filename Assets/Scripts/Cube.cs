using UnityEngine;

public class Cube : Shape
{
    public Cube(IMediator mediator) : base(mediator, "Cube") { }

    public override void SendMessage(string message)
    {   
        Debug.Log("Cube sends message: " + message);
        mediator.SendMessage(this, message);
    }

    public override void ReceiveMessage(string sender, string message)
    {
        Debug.Log("Cube receives message: " + message + " from " + sender);
    }
}