using UnityEngine;
public class ShakeableTransform : MonoBehaviour
{
    [SerializeField] private float speed = 25.0f; // Offset of the Perlin Noise
    [SerializeField] private Vector3 shake = Vector3.one * 0.5f; // The amount of shake
    [SerializeField] private float recoverSpeed = 0.2f; // The time of the shake
    
    private float _seed; // Random value to pass to Perlin Noise
    private float _shakeStrength; // The strength of the shake
    private float _trauma = 0.0f; // The amount of shake
    public void SetTrauma(float value)
    {
        _trauma = Mathf.Clamp01(_trauma + value); // Increasing the amount of shake
    }
    private void Start()
    {
        _seed = UnityEngine.Random.value; // Generating a random value
    }
    private void Update()
    {
        _shakeStrength = Mathf.Pow(_trauma, 2); // Calculating the strength of the shake
        // Shaking by changing the local position of the object
        float x = Mathf.PerlinNoise(_seed, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random movement on X axis
        float y = Mathf.PerlinNoise(_seed + 1.0f, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random movement on Y axis
        float z = Mathf.PerlinNoise(_seed + 2.0f, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random movement on Z axis
        // Using UnityEngine.Random.Range() to give some random movement on X , Y , Z axis
        transform.localPosition = new Vector3(x * shake.x, y * shake.y, z * shake.z) * _shakeStrength;  
        
        // Shaking by changing the local rotation of the object
        float rx = Mathf.PerlinNoise(_seed, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random rotation on X axis
        float ry = Mathf.PerlinNoise(_seed + 1.0f, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random rotation on Y axis
        float rz = Mathf.PerlinNoise(_seed + 2.0f, Time.time * speed) * 2.0f - 1.0f; // Using Perlin Noise to give some random rotation on Z axis
        // Applying the rotation to the object
        transform.localRotation = Quaternion.Euler(new Vector3(rx * shake.x, ry * shake.y, rz * shake.z) * _shakeStrength);
        
        _trauma = Mathf.Clamp01(_trauma - Time.deltaTime * recoverSpeed); // Decreasing the amount of shake
    }
}

// Relate to Path: Assets/Explosion.cs