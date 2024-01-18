using UnityEngine;

public class SphereMaterial : MonoBehaviour
{
    private MeshRenderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    public void Init(Texture texture)
    {
        _renderer = GetComponent<MeshRenderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();

        _materialPropertyBlock.SetTexture("_BaseColorMap", texture);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }
}
