using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _sphere;

    [SerializeField]
    private int _sphereCount;

    [SerializeField]
    private float _spawnRange;

    [SerializeField]
    private float _spawnRadius;

    public Texture[] textures;

    private bool _spheresIsActive;

    private GameObject[] _spheres;

    private void Awake()
    {
        _spheres = new GameObject[_sphereCount];

        float step = _spawnRange / _sphereCount;
        float currentAngle = 0;
        for (int i = 0; i < _sphereCount; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * currentAngle);
            float z = Mathf.Sin(Mathf.Deg2Rad * currentAngle);

            SphereMaterial sphere = Instantiate(_sphere, new Vector3(x, 0, z) * _spawnRadius, Quaternion.identity, transform).GetComponent<SphereMaterial>();

            _spheres[i] = sphere.gameObject;

            sphere.Init(textures[i]);
            currentAngle += step;
        }
    }

    private void Update()
    {
        if (SceneCubesInfo.Instance.Distance < 2)
        {
            if (!_spheresIsActive)
            {
                _spheresIsActive = true;
                foreach (var obj in _spheres)
                {
                    obj.SetActive(true);
                }
            }
        }
        else
        {
            if (_spheresIsActive)
            {
                _spheresIsActive = false;
                foreach (var obj in _spheres)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
