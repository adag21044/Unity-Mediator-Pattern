using System.Collections.Generic;

public class Mediator : IMediator
{
    private List<Shape> shapes = new List<Shape>();
    
    public void SendMessage(Shape sender, string message)
    {
        foreach(var shape in shapes)
        {
            if(shape != sender)
            {
                shape.ReceiveMessage(sender.Name, message);
            }
        }
    }

    public void RegisterToy(Shape shape)
    {
        if(!shapes.Contains(shape))
        {
            shapes.Add(shape);
        }
    }
}