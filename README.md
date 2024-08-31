# Unity Mediator Pattern

This Unity project demonstrates the implementation of the Mediator pattern. The Mediator pattern is a behavioral design pattern that defines an object that encapsulates how a set of objects interact. It promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

## Overview

In this project, the `Mediator` class coordinates communication between `Shape` objects (`Sphere` and `Cube`). The `Shape` class is an abstract class that defines the common interface for all shape objects. The `Cube` and `Sphere` classes inherit from `Shape` and provide specific implementations for sending and receiving messages.

## Components

### Mediator Interface
Defines methods for sending messages and registering shapes with the mediator.
```csharp
public interface IMediator 
{
    void SendMessage(Shape sender, string message);
    void RegisterShape(Shape shape);    
}
```

### Mediator Class
Implements the `IMediator` interface to handle message distribution and shape registration.
```csharp
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
                shape.ReceiveCustomMessage(sender.Name, message);
            }
        }
    }

    public void RegisterShape(Shape shape)
    {
        if(!shapes.Contains(shape))
        {
            shapes.Add(shape);
        }
    }
}
```

### Shape Class
An abstract class representing shapes that can communicate with each other via the mediator.
```csharp
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
```

### Sphere Class
Represents a sphere shape that sends and receives messages.
```csharp
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
```

### Cube Class
Represents a cube shape that sends and receives messages.
```csharp
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
```

### Game Manager Class
```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        IMediator mediator = new Mediator();

        // Find the Sphere and Cube objects in the scene
        Sphere sphere = FindObjectOfType<Sphere>();
        Cube cube = FindObjectOfType<Cube>();

        if (sphere != null)
        {
            sphere.Setup(mediator, "Sphere");
        }
        else
        {
            Debug.LogError("Sphere object not found in the scene.");
        }

        if (cube != null)
        {
            cube.Setup(mediator);
        }
        else
        {
            Debug.LogError("Cube object not found in the scene.");
        }

        // Send messages between the Sphere and Cube
        if (sphere != null && cube != null)
        {
            sphere.SendCustomMessage("Hello, Cube!");
            cube.SendCustomMessage("Hello, Sphere!");
        }
    }
}
```



