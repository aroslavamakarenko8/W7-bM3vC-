using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class _0x3121f6e7 : MonoBehaviour
{
    private Touch? _0x54fd8612()
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
            return null;
        foreach (Touch _0xe9314556 in Touch.activeTouches)
            if (_0xe9314556.ended)
                if (this._0x6e9b1be8(_0xe9314556))
                    return _0xe9314556;
        return null;
    }

    private Touch? _0x3962634d(Bounds _0x3a112959)
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
            return null;
        foreach (Touch _0x50aaaa50 in Touch.activeTouches)
            if (!_0x50aaaa50.ended)
            {
                Vector3 _0x6829a28f = Camera.main.ScreenToWorldPoint(_0x50aaaa50.screenPosition);
                Vector3 _0x5fe5335d = new(_0x6829a28f.x, _0x6829a28f.y, _0x3a112959.center.z);
                if (_0x3a112959.Contains(_0x5fe5335d) && this._0x6e9b1be8(_0x50aaaa50))
                    return _0x50aaaa50;
            }

        return null;
    }

    private bool _0xd5504887(Touch? _0x20ec8ea3, Bounds _0xef58a4eb, TouchPhase _0xcc5e59fb)
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
        {
            _0x20ec8ea3 = null;
            return false;
        }

        if (_0x20ec8ea3 != null)
            if (_0x20ec8ea3.Value.phase == _0xcc5e59fb)
            {
                Vector3 _0x456ddd68 = Camera.main.ScreenToWorldPoint(_0x20ec8ea3.Value.screenPosition);
                Vector3 _0x9514f502 = new(_0x456ddd68.x, _0x456ddd68.y, _0xef58a4eb.center.z);
                if (_0xef58a4eb.Contains(_0x9514f502) && this._0x6e9b1be8(_0x20ec8ea3.Value))
                    return true;
            }

        return false;
    }

    private Touch? _0x58b83082()
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
            return null;
        foreach (Touch _0x875d8675 in Touch.activeTouches)
            if (!_0x875d8675.ended)
                if (this._0x6e9b1be8(_0x875d8675))
                    return _0x875d8675;
        return null;
    }

    private bool _0x6e9b1be8(Touch? _0x1c64ae6d)
    {
        if (!_0x1c64ae6d.HasValue)
            return false;
        Vector3 _0x493eeca1 = Camera.main.ScreenToWorldPoint(_0x1c64ae6d.Value.screenPosition);
        Vector3 _0x034b7908 = _0x493eeca1;
        _0x034b7908.z = this.CameraTouchBounds.transform.position.z;
        if (this.CameraTouchBounds.bounds.Contains(_0x034b7908))
            return true;
        _0x1c64ae6d = null;
        return false;
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _0x1a27834d = this.gameObject.GetComponent<_0x3121f6e7>();
    }

    public BoxCollider2D CameraTouchBounds;
    private Touch? _0xc2b577ae(Bounds _0x7bd25756, TouchPhase _0x36640988)
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
            return null;
        foreach (Touch _0x0243607e in Touch.activeTouches)
            if (_0x0243607e.phase == _0x36640988)
            {
                Vector3 _0xc8cf5c87 = Camera.main.ScreenToWorldPoint(_0x0243607e.screenPosition);
                Vector3 _0x4b162960 = new(_0xc8cf5c87.x, _0xc8cf5c87.y, _0x7bd25756.center.z);
                if (_0x7bd25756.Contains(_0x4b162960) && this._0x6e9b1be8(_0x0243607e))
                    return _0x0243607e;
            }

        return null;
    }

    private static _0x3121f6e7 _0x1a27834d;
    private void _0xd42d86d3(Touch? _0x13d2c5b2)
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
        {
            _0x13d2c5b2 = null;
            return;
        }

        int _0xab1e16d8 = _0x13d2c5b2.Value.touchId;
        _0x13d2c5b2 = Touch.activeTouches.FirstOrDefault(_0x368fe361 => _0x368fe361.touchId == _0xab1e16d8);
        if (!this._0x6e9b1be8(_0x13d2c5b2.Value))
            _0x13d2c5b2 = null;
    }

    private Touch? _0xd7789afe(Bounds _0x3cfde010)
    {
        if (!_0x639e6ff3.Instance._0x80a41f77)
            return null;
        foreach (Touch _0xda064fb1 in Touch.activeTouches)
            if (_0xda064fb1.ended)
            {
                Vector3 _0x88af1c01 = Camera.main.ScreenToWorldPoint(_0xda064fb1.screenPosition);
                Vector3 _0x6ef829db = new(_0x88af1c01.x, _0x88af1c01.y, _0x3cfde010.center.z);
                if (_0x3cfde010.Contains(_0x6ef829db) && this._0x6e9b1be8(_0xda064fb1))
                    return _0xda064fb1;
            }

        return null;
    }
}