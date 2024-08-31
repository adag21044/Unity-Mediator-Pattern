using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject cubePrefab;

    private void Start()
    {
        IMediator mediator = new Mediator();

        GameObject sphereObject = Instantiate(spherePrefab);
        Sphere sphere = sphereObject.GetComponent<Sphere>();
        sphere.Setup(mediator, "Sphere");

        GameObject cubeObject = Instantiate(cubePrefab);
        Cube cube = cubeObject.GetComponent<Cube>();
        cube.Setup(mediator);

        sphere.SendCustomMessage("Hello, Cube!");
        cube.SendCustomMessage("Hello, Sphere!");
    }
}
