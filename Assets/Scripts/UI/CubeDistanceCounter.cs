using TMPro;
using UnityEngine;

public class CubeDistanceCounter : MonoBehaviour
{
    private TMP_Text _counter;


    private void Awake()
    {
        _counter = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _counter.text = $"Distance {SceneCubesInfo.Instance.Distance}";
    }
}
