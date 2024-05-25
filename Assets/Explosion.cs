using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Explosion : MonoBehaviour
{
    [SerializeField] ShakeableTransform target;
    [SerializeField] float delay = 1.0f;
    [SerializeField] private float impactDistance = 30.0f; // The distance of the impact
    
    private float _distance; // The distance between the target and the explosion
    private float _impact; // The impact of the explosion
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        
        GetComponent<ParticleSystem>().Play();
        
        _distance = Vector3.Distance(transform.position, target.transform.position); // Calculating the distance between the target and the explosion
        _impact = Mathf.Clamp01(impactDistance / _distance); // Calculating the impact of the explosion
        target.SetTrauma(_impact); // Setting the impact of the explosion
    }
}

