using UnityEngine;

public class ParticleBetweenCube : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private Transform _fromCube;

    [SerializeField]
    private Transform _toCube;
    private void Update()
    {
        _particleSystem.startLifetime = SceneCubesInfo.Instance.Distance / 10;
        transform.position = _fromCube.position;
        transform.forward = _toCube.position - _fromCube.position;
    }
}
