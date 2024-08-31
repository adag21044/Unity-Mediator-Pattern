using UnityEngine;

public class Sphere : Shape
{
    public Sphere(IMediator mediator, string name) : base(mediator, name){}

    public override void SendMessage(string message)
    {
        Debug.Log("Sphere sends message: " + message);
        mediator.SendMessage(this, message);
    }

    public override void ReceiveMessage(string sender, string message)
    {
        Debug.Log("Sphere receives message: " + message + " from " + sender);
    }

    
}