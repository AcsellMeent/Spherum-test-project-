using UnityEngine;

public class SceneCubesInfo : MonoBehaviour
{
    public static SceneCubesInfo Instance { get; private set; }

    [SerializeField]
    private bool _destroyOnLoad;

    [SerializeField]
    private Transform _redCube;

    [SerializeField]
    private Transform _greenCube;

    public float Distance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (_destroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
            return;
        }

        Destroy(this.gameObject);
    }

    private void Update()
    {
        Distance = Vector3.Distance(_redCube.position, _greenCube.position);
    }
}
