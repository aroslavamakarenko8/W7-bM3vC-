using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class _0x976fb745 : MonoBehaviour
{
    private Vector3 _0x3bf07707 { get; set; }
    private float _0xf8ab0486 { get; set; }
    private Vector3 _0x2dfa2711 { get; set; }

    private float _0x6ec1ce3a = 1;
    private static _0x976fb745 _0x6e266b1b;
    private Vector3 _0x597a0488 { get; set; }
    private Vector3 _0x2ba6a6d8 { get; set; }
    private Vector3 _0xd61a901d { get; set; }

    private _0x37edb1ab _0x6414c925 = _0x37edb1ab.Portrait;
    private Vector3 _0x131edd9f { get; set; }

    private void Awake()
    {
        this._0x8621c123 = this.GetComponent<Camera>();
        _0x6e266b1b = this;
        this._0x7505f435();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = this._0x7a054636;
        Matrix4x4 _0x0edccda2 = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        if (this._0x8621c123.orthographic)
        {
            float _0x099673cb = this._0x8621c123.farClipPlane - this._0x8621c123.nearClipPlane;
            float _0x5c8da3e2 = (this._0x8621c123.farClipPlane + this._0x8621c123.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, _0x5c8da3e2), new Vector3(this._0x8621c123.orthographicSize * 2 * this._0x8621c123.aspect, this._0x8621c123.orthographicSize * 2, _0x099673cb));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, this._0x8621c123.fieldOfView, this._0x8621c123.farClipPlane, this._0x8621c123.nearClipPlane, this._0x8621c123.aspect);
        }

        Gizmos.matrix = _0x0edccda2;
    }

    private Vector3 _0x7e715222 { get; set; }

    private new Camera _0x8621c123;
    private Vector3 _0x10c7a2a4 { get; set; }

    public enum _0x37edb1ab
    {
        Landscape,
        Portrait
    }

    private Vector3 _0x199cea30 { get; set; }

    private Color _0x7a054636 = Color.white;
    //public bool executeInUpdate;
    private float _0x788f35d3 { get; set; }

    private void _0x7505f435()
    {
        float _0x6f453434, _0x7e9b7789, _0x5c3826a7, _0xa5f08fc5;
        if (this._0x6414c925 == _0x37edb1ab.Landscape)
            this._0x8621c123.orthographicSize = 1f / this._0x8621c123.aspect * this._0x6ec1ce3a / 2f;
        else
            this._0x8621c123.orthographicSize = this._0x6ec1ce3a / 2f;
        this._0xf8ab0486 = 2f * this._0x8621c123.orthographicSize;
        this._0x788f35d3 = this._0xf8ab0486 * this._0x8621c123.aspect;
        float _0x0d92901a = this._0x8621c123.transform.position.x;
        float _0x3d174b59 = this._0x8621c123.transform.position.y;
        _0x6f453434 = _0x0d92901a - this._0x788f35d3 / 2;
        _0x7e9b7789 = _0x0d92901a + this._0x788f35d3 / 2;
        _0x5c3826a7 = _0x3d174b59 + this._0xf8ab0486 / 2;
        _0xa5f08fc5 = _0x3d174b59 - this._0xf8ab0486 / 2;
        this._0x10c7a2a4 = new Vector3(_0x6f453434, _0xa5f08fc5, 0);
        this._0x2ba6a6d8 = new Vector3(_0x0d92901a, _0xa5f08fc5, 0);
        this._0x597a0488 = new Vector3(_0x7e9b7789, _0xa5f08fc5, 0);
        this._0x199cea30 = new Vector3(_0x6f453434, _0x3d174b59, 0);
        this._0xd61a901d = new Vector3(_0x0d92901a, _0x3d174b59, 0);
        this._0x7e715222 = new Vector3(_0x7e9b7789, _0x3d174b59, 0);
        this._0x3bf07707 = new Vector3(_0x6f453434, _0x5c3826a7, 0);
        this._0x2dfa2711 = new Vector3(_0x0d92901a, _0x5c3826a7, 0);
        this._0x131edd9f = new Vector3(_0x7e9b7789, _0x5c3826a7, 0);
    }
}