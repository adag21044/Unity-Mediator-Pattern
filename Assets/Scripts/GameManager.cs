using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        IMediator mediator = new Mediator();

        Shape sphere = new Sphere(mediator, "Sphere");
        Shape cube = new Cube(mediator);

        sphere.SendMessage("Hello, Cube!");
        cube.SendMessage("Hello, Sphere!");
    }
}