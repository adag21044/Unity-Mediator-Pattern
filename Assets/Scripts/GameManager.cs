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
