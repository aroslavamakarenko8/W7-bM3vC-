using UnityEngine;

/// <summary>
/// Draws a fresh yard for every attempt and refuses to hand one over until a
/// greedy bot has proved it can be finished inside the line clock (rule C.11).
/// The randomness comes from a private System.Random seeded per attempt, never
/// from UnityEngine.Random, which is global state shared with the template.
/// </summary>
public sealed class _0xe9ab41a3
{
    private bool _0x5e7c60f5(_0xed49d1c5 _0xb2143d38, int _0x2b0da6c9)
    {
        for (int _0x1b3e1de1 = 0; _0x1b3e1de1 < _0xb2143d38.HazardLanes.Length; _0x1b3e1de1++)
        {
            if (_0xb2143d38.HazardLanes[_0x1b3e1de1] == _0x2b0da6c9)
                return true;
        }

        return false;
    }

    /// <summary>The colour chain the order strip walks, never three alike in a row.</summary>
    private int[] _0x334f94d3(int _0x00149d39, System.Random _0xaaa0a055)
    {
        int[] _0xff382336 = new int[_0x00149d39];
        for (int _0x4a30181e = 0; _0x4a30181e < _0x00149d39; _0x4a30181e++)
        {
            int _0x55bc36ad = _0xaaa0a055.Next(_0x6f92d6a9.CrateKinds);
            if (_0x4a30181e >= 2 && _0xff382336[_0x4a30181e - 1] == _0x55bc36ad && _0xff382336[_0x4a30181e - 2] == _0x55bc36ad)
                _0x55bc36ad = (_0x55bc36ad + 1 + _0xaaa0a055.Next(_0x6f92d6a9.CrateKinds - 1)) % _0x6f92d6a9.CrateKinds;
            _0xff382336[_0x4a30181e] = _0x55bc36ad;
        }

        return _0xff382336;
    }

    private int _0xf283658c(_0xed49d1c5 _0x3a1475af, int _0x9b258e19)
    {
        if (!this._0x5e7c60f5(_0x3a1475af, _0x9b258e19) && _0x3a1475af.DecoyLane != _0x9b258e19)
            return _0x9b258e19;
        for (int _0xb7456bd6 = 0; _0xb7456bd6 < _0x6f92d6a9.Lanes; _0xb7456bd6++)
        {
            if (!this._0x5e7c60f5(_0x3a1475af, _0xb7456bd6) && _0x3a1475af.DecoyLane != _0xb7456bd6)
                return _0xb7456bd6;
        }

        for (int _0xd9db0ab7 = 0; _0xd9db0ab7 < _0x6f92d6a9.Lanes; _0xd9db0ab7++)
        {
            if (!this._0x5e7c60f5(_0x3a1475af, _0xd9db0ab7))
                return _0xd9db0ab7;
        }

        return _0x9b258e19;
    }

    // -- solver ----------------------------------------------------------------
    /// <summary>
    /// A greedy driver walks the plan: on every row it steps into the lane of the
    /// wanted crate, and on a row without one it parks in a lane nothing blocks. A
    /// row is reachable when the fall from the spawn line to the cart outlasts the
    /// lane changes needed to meet it - with three lanes that is at most two slides,
    /// an order of magnitude under the fall. The route is accepted only when the
    /// driver finishes with real slack left on the line clock.
    /// </summary>
    public bool _0x7eb9cc5e(_0xbddf612c _0xe75b7594, _0x0a9f4dbc _0x4a104156, float _0xeea88638)
    {
        float _0xf391f3d3 = _0x4a104156.LineSeconds - _0x6f92d6a9.SolverSlackSeconds;
        int _0xfa4b925b = 1;
        int _0xcf3d1580 = 0;
        _0xe75b7594.SolvedRows = _0xe75b7594.Rows.Length;
        _0xe75b7594.SolvedSeconds = _0x4a104156.LineSeconds;
        for (int _0x2f69c6d0 = 0; _0x2f69c6d0 < _0xe75b7594.Rows.Length; _0x2f69c6d0++)
        {
            _0xed49d1c5 _0xd75d61da = _0xe75b7594.Rows[_0x2f69c6d0];
            float _0x67b46374 = _0x2f69c6d0 * _0x4a104156.RowInterval + _0xeea88638;
            int _0x2862ed04 = _0xd75d61da.WantedLane >= 0 ? _0xd75d61da.WantedLane : this._0xf283658c(_0xd75d61da, _0xfa4b925b);
            float _0x429a7f12 = Mathf.Abs(_0x2862ed04 - _0xfa4b925b) * _0x6f92d6a9.LaneSlideSeconds;
            if (_0x429a7f12 > _0xeea88638)
                continue;
            _0xfa4b925b = _0x2862ed04;
            if (_0xd75d61da.WantedLane == _0xfa4b925b && !this._0x5e7c60f5(_0xd75d61da, _0xfa4b925b))
                _0xcf3d1580++;
            if (_0xcf3d1580 >= _0xe75b7594._0x8a0f87ee)
            {
                _0xe75b7594.SolvedRows = _0x2f69c6d0 + 1;
                _0xe75b7594.SolvedSeconds = _0x67b46374;
                return _0x67b46374 <= _0xf391f3d3;
            }
        }

        return false;
    }

    /// <summary>
    /// A layout that cannot be unwinnable: every row carries the wanted crate, and a
    /// barrier only ever stands in a lane the crate is not in. Reached only when
    /// twenty drawn layouts failed the solver, which the weights say should not
    /// happen - it exists so a bad seed can never ship a dead run.
    /// </summary>
    private _0xbddf612c _0x0490c6b3(int _0x5a9574a1, int _0x0760b5ec, int _0x3d6c27e2, _0x0a9f4dbc _0x2b8279a5, System.Random _0xcd522a14)
    {
        _0xbddf612c _0xbd2d18d5 = new _0xbddf612c();
        _0xbd2d18d5.RouteIndex = _0x5a9574a1;
        _0xbd2d18d5.Attempt = _0x0760b5ec;
        _0xbd2d18d5.Seed = _0x3d6c27e2;
        _0xbd2d18d5.Sequence = this._0x334f94d3(_0x2b8279a5.Crates, _0xcd522a14);
        int _0x1767a8b8 = Mathf.CeilToInt(_0x2b8279a5.LineSeconds / _0x2b8279a5.RowInterval) + 6;
        _0xed49d1c5[] _0x70e65131 = new _0xed49d1c5[_0x1767a8b8];
        for (int _0x6ad79432 = 0; _0x6ad79432 < _0x1767a8b8; _0x6ad79432++)
        {
            _0xed49d1c5 _0x7badf8b3 = new _0xed49d1c5();
            _0x7badf8b3.WantedLane = _0x6ad79432 % _0x6f92d6a9.Lanes;
            _0x7badf8b3.MarkerSide = _0x6ad79432 % 4 == 0 ? -1 : (_0x6ad79432 % 4 == 2 ? 1 : 0);
            if (_0x6ad79432 >= _0x2b8279a5.HazardFromRow && _0x6ad79432 % 3 == 0)
                _0x7badf8b3.HazardLanes = new[]
                {
                    (_0x7badf8b3.WantedLane + 1) % _0x6f92d6a9.Lanes
                };
            _0x70e65131[_0x6ad79432] = _0x7badf8b3;
        }

        _0xbd2d18d5.Rows = _0x70e65131;
        return _0xbd2d18d5;
    }

    // -- layout ----------------------------------------------------------------
    private _0xbddf612c _0x9383582f(int _0x646ee155, int _0xaad8900f, int _0x1270bd66, _0x0a9f4dbc _0x8584da13, System.Random _0xcd180f9d)
    {
        _0xbddf612c _0x66dc2dd2 = new _0xbddf612c();
        _0x66dc2dd2.RouteIndex = _0x646ee155;
        _0x66dc2dd2.Attempt = _0xaad8900f;
        _0x66dc2dd2.Seed = _0x1270bd66;
        _0x66dc2dd2.Sequence = this._0x334f94d3(_0x8584da13.Crates, _0xcd180f9d);
        int _0xe3bcacd1 = Mathf.CeilToInt(_0x8584da13.LineSeconds / _0x8584da13.RowInterval) + 6;
        _0xed49d1c5[] _0x89f22a19 = new _0xed49d1c5[_0xe3bcacd1];
        for (int _0x3465918b = 0; _0x3465918b < _0xe3bcacd1; _0x3465918b++)
            _0x89f22a19[_0x3465918b] = this._0xb64901bc(_0x3465918b, _0x8584da13, _0xcd180f9d);
        _0x66dc2dd2.Rows = _0x89f22a19;
        return _0x66dc2dd2;
    }

    private _0xed49d1c5 _0xb64901bc(int _0x88a4afb7, _0x0a9f4dbc _0x74a85c2b, System.Random _0x265df3c2)
    {
        _0xed49d1c5 _0xff65830c = new _0xed49d1c5();
        _0xff65830c.MarkerSide = _0x265df3c2.Next(5) == 0 ? (_0x265df3c2.Next(2) == 0 ? -1 : 1) : 0;
        _0xff65830c.HazardVariant = _0x265df3c2.Next(2);
        int _0x802387ef = _0x265df3c2.Next(100);
        bool _0x4df96b29 = _0x88a4afb7 >= _0x74a85c2b.HazardFromRow;
        if (_0x802387ef < _0x6f92d6a9.WeightSolo)
        {
            // SOLO - one crate, usually the one the order is asking for.
            int _0xd303667f = _0x265df3c2.Next(_0x6f92d6a9.Lanes);
            if (_0x265df3c2.Next(100) < 70)
            {
                _0xff65830c.WantedLane = _0xd303667f;
            }
            else
            {
                _0xff65830c.DecoyLane = _0xd303667f;
                _0xff65830c.DecoyOffset = 1 + _0x265df3c2.Next(_0x6f92d6a9.CrateKinds - 1);
            }

            return _0xff65830c;
        }

        if (_0x802387ef < _0x6f92d6a9.WeightSolo + _0x6f92d6a9.WeightPair)
        {
            // PAIR - the wanted crate and one liar, never in the same lane.
            int _0x61d53f9e = _0x265df3c2.Next(_0x6f92d6a9.Lanes);
            int _0xd79f38c5 = (_0x61d53f9e + 1 + _0x265df3c2.Next(_0x6f92d6a9.Lanes - 1)) % _0x6f92d6a9.Lanes;
            _0xff65830c.WantedLane = _0x61d53f9e;
            _0xff65830c.DecoyLane = _0xd79f38c5;
            _0xff65830c.DecoyOffset = 1 + _0x265df3c2.Next(_0x6f92d6a9.CrateKinds - 1);
            return _0xff65830c;
        }

        if (_0x802387ef < _0x6f92d6a9.WeightSolo + _0x6f92d6a9.WeightPair + _0x6f92d6a9.WeightGuard)
        {
            // GUARD - a crate with a barrier standing in another lane.
            int _0x3f4bee6d = _0x265df3c2.Next(_0x6f92d6a9.Lanes);
            if (_0x265df3c2.Next(100) < 60)
            {
                _0xff65830c.WantedLane = _0x3f4bee6d;
            }
            else
            {
                _0xff65830c.DecoyLane = _0x3f4bee6d;
                _0xff65830c.DecoyOffset = 1 + _0x265df3c2.Next(_0x6f92d6a9.CrateKinds - 1);
            }

            if (_0x4df96b29)
            {
                int _0x671fe70c = (_0x3f4bee6d + 1 + _0x265df3c2.Next(_0x6f92d6a9.Lanes - 1)) % _0x6f92d6a9.Lanes;
                _0xff65830c.HazardLanes = new[]
                {
                    _0x671fe70c
                };
            }

            return _0xff65830c;
        }

        // GAP - breathing room, or one or two barriers with nothing to collect.
        if (_0x4df96b29)
        {
            int _0x2e71216f = _0x265df3c2.Next(_0x6f92d6a9.Lanes);
            if (_0x74a85c2b.HazardMax >= 2 && _0x265df3c2.Next(100) < 35)
            {
                int _0xdb59beff = (_0x2e71216f + 1 + _0x265df3c2.Next(_0x6f92d6a9.Lanes - 1)) % _0x6f92d6a9.Lanes;
                _0xff65830c.HazardLanes = new[]
                {
                    _0x2e71216f,
                    _0xdb59beff
                };
            }
            else
            {
                _0xff65830c.HazardLanes = new[]
                {
                    _0x2e71216f
                };
            }
        }

        return _0xff65830c;
    }

    /// <summary>
    /// Build a route for this attempt. Up to twenty layouts are drawn and tested
    /// against <paramref name = "fallSeconds"/> - the time a row needs to travel from
    /// the spawn line down to the cart, measured from the camera by the caller. If
    /// none is clearable the safety net below is used instead.
    /// </summary>
    public _0xbddf612c Build(int _0x59c33e19, int _0x0b219126, float _0x83304111)
    {
        _0x0a9f4dbc _0x904ffefa = _0x6f92d6a9.Route(_0x59c33e19);
        int _0x94d53449 = (_0x59c33e19 * 7919) ^ (_0x0b219126 * 104729);
        System.Random _0x1b538349 = new System.Random(_0x94d53449);
        _0xbddf612c _0x3c98de4e = null;
        for (int _0x144e3c3c = 0; _0x144e3c3c < 20; _0x144e3c3c++)
        {
            _0xbddf612c _0x522fe6ed = this._0x9383582f(_0x59c33e19, _0x0b219126, _0x94d53449, _0x904ffefa, _0x1b538349);
            if (this._0x7eb9cc5e(_0x522fe6ed, _0x904ffefa, _0x83304111))
            {
                _0x3c98de4e = _0x522fe6ed;
                break;
            }
        }

        if (_0x3c98de4e == null)
        {
            _0x3c98de4e = this._0x0490c6b3(_0x59c33e19, _0x0b219126, _0x94d53449, _0x904ffefa, _0x1b538349);
            _0x3c98de4e.FromFallback = true;
            this._0x7eb9cc5e(_0x3c98de4e, _0x904ffefa, _0x83304111);
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x76f3ee90._0xe99d731f(new byte[13] { 184, 145, 140, 150, 151, 134, 190, 195, 144, 134, 134, 135, 222 }, 227) + _0x3c98de4e.Seed + _0x76f3ee90._0xe99d731f(new byte[5] { 90, 22, 31, 20, 71 }, 122) + _0x3c98de4e._0x8a0f87ee + _0x76f3ee90._0xe99d731f(new byte[6] { 252, 174, 179, 171, 175, 225 }, 220) + _0x3c98de4e.Rows.Length + _0x76f3ee90._0xe99d731f(new byte[8] { 132, 215, 203, 200, 210, 193, 192, 153 }, 164) + _0x3c98de4e.SolvedRows + _0x76f3ee90._0xe99d731f(new byte[4] { 136, 193, 198, 136 }, 168) + _0x3c98de4e.SolvedSeconds.ToString(_0x76f3ee90._0xe99d731f(new byte[3] { 237, 243, 237 }, 221)) + _0x76f3ee90._0xe99d731f(new byte[1] { 166 }, 213) + (_0x3c98de4e.FromFallback ? _0x76f3ee90._0xe99d731f(new byte[13] { 154, 146, 201, 219, 220, 223, 206, 195, 154, 212, 223, 206, 147 }, 186) : string.Empty));
            }
#endif
        }

        return _0x3c98de4e;
    }
}

internal static class _0x76f3ee90
{
    internal static string _0xe99d731f(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}