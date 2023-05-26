using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 10f; // Adjust the speed of rotation as needed
    [SerializeField] public Vector3 rotationAxis = Vector3.up; // The axis to rotate around (default is Y axis)

    void Update()
    {
        // Rotate the GameObject around the specified axis
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
