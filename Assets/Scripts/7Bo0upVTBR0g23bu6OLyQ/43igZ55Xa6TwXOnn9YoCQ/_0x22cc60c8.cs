using AndroidInstallReferrer;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.CloudSave.Models.Data.Player;
using Unity.Services.Core;
using Unity.Services.PushNotifications;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class _0x22cc60c8 : MonoBehaviour
{
    private void OnApplicationFocus(bool _0x86c7b5ae)
    {
        isApplicationFocus = _0x86c7b5ae;
        if (_0x86c7b5ae && _0xaf398bc9)
        {
            _0xf425a05a();
        }
    }

    // NATIVE WEB VIEW METHODS
    private UniWebView _0x73590a68 = null;
    private void _0x58744ba2()
    {
        if (_0x73590a68 == null)
            return;
        if (_0xd585aacf)
            _0x73590a68.SetUserAgent(_0xaf793820());
        else
            _0x73590a68.SetUserAgent("");
    }

    public void _0x1964b544()
    {
        isDestroyedForce = true;
        StopAllCoroutines();
        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[18] { 74, 69, 116, 98, 101, 76, 49, 93, 112, 100, 127, 114, 121, 49, 86, 112, 124, 116 }, 17));
#endif
        }

        _0xe8a0442b.Instance?._0x9e9c6afe();
        _0x76586aa9.Instance._0x2d1a656b(_0x228d52ef._0x837759f6.DEFAULT);
    }

    private void Awake()
    {
        if (_0x40524e59 != null)
        {
            Destroy(this.gameObject);
            return;
        }

        EnhancedTouchSupport.Enable();
        Input.backButtonLeavesApp = false;
        {
#if !B_LOGS
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
#endif
        }

        _0x40524e59 = gameObject.GetComponent<_0x22cc60c8>();
        DontDestroyOnLoad(gameObject);
        _0x71e64abb = _0xbdd86da9 = _0x4890d725 = "";
        _0x7d1ce146 = "";
        _0xaf398bc9 = false;
    }

    private readonly List<UniWebViewPopup> _0xa9e558ff = new List<UniWebViewPopup>();
    internal bool isApplicationFocus = false;
    // MAIN FLOW
    private bool _0x29c47e3d { get; set; }

    private UniWebViewPopup _0xa2b7bf66()
    {
        for (int _0x29d4a756 = _0xa9e558ff.Count - 1; _0x29d4a756 >= 0; _0x29d4a756--)
        {
            var _0xc20fad47 = _0xa9e558ff[_0x29d4a756];
            if (_0xc20fad47 != null && _0xc20fad47.IsAlive)
                return _0xc20fad47;
            _0xa9e558ff.RemoveAt(_0x29d4a756);
        }

        return null;
    }

    private int _0xfd705bf6 = 0;
    private IEnumerator _0x08d46c57()
    {
        yield return RequestAndroidPermissionIfNeeded(Permission.Camera);
    }

    private bool TryOpenExternalLikeChrome(string _0x18be4a3a)
    {
        if (string.IsNullOrEmpty(_0x18be4a3a))
            return false;
        if (_0x18be4a3a.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[9] { 187, 188, 166, 183, 188, 166, 232, 253, 253 }, 210), StringComparison.OrdinalIgnoreCase))
            return _0x0e259480(_0x18be4a3a);
        if (_0x856b0a46(_0x18be4a3a))
            return _0x79b00872(_0x18be4a3a, null);
        if (!_0x18be4a3a.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[7] { 102, 122, 122, 126, 52, 33, 33 }, 14), StringComparison.OrdinalIgnoreCase) && !_0x18be4a3a.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[8] { 42, 54, 54, 50, 49, 120, 109, 109 }, 66), StringComparison.OrdinalIgnoreCase) && !_0x18be4a3a.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[11] { 48, 51, 62, 36, 37, 107, 51, 61, 48, 63, 58 }, 81), StringComparison.OrdinalIgnoreCase))
        {
            return _0xd783c68d(_0x18be4a3a);
        }

        return false;
    }

    internal bool IsGoogleAuthFlowUrl(string _0x5e1db475)
    {
        if (string.IsNullOrEmpty(_0x5e1db475))
            return false;
        return _0x5e1db475.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[19] { 156, 158, 158, 146, 136, 147, 137, 142, 211, 154, 146, 146, 154, 145, 152, 211, 158, 146, 144 }, 253), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5e1db475.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[16] { 222, 220, 220, 208, 202, 209, 203, 204, 145, 216, 208, 208, 216, 211, 218, 145 }, 191), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5e1db475.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[21] { 246, 254, 254, 246, 253, 244, 228, 226, 244, 227, 242, 254, 255, 229, 244, 255, 229, 191, 242, 254, 252 }, 145), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5e1db475.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[11] { 15, 27, 28, 9, 28, 1, 11, 70, 11, 7, 5 }, 104), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void _0x37b7483d()
    {
        if (_0xc2851432 != null)
            return;
        var _0x823d2231 = _0x6c3ad38f();
        _0xc2851432 = new GameObject(_0x4cc8c16a._0xd104ebf8(new byte[14] { 91, 105, 110, 90, 101, 105, 123, 95, 124, 101, 98, 98, 105, 126 }, 12), typeof(RectTransform), typeof(Text));
        _0x2073a206 = _0xc2851432.GetComponent<RectTransform>();
        _0x2073a206.SetParent(_0x823d2231.transform, false);
        _0x2073a206.anchorMin = new Vector2(0.5f, 0.5f);
        _0x2073a206.anchorMax = new Vector2(0.5f, 0.5f);
        _0x2073a206.pivot = new Vector2(0.5f, 0.5f);
        _0x2073a206.sizeDelta = new Vector2(600f, 600f);
        _0x2073a206.anchoredPosition = Vector2.zero;
        _0x980d9611 = _0xc2851432.GetComponent<Text>();
        _0x980d9611.text = _0x4cc8c16a._0xd104ebf8(new byte[1] { 33 }, 14);
        _0x980d9611.font = Resources.GetBuiltinResource<Font>(_0x4cc8c16a._0xd104ebf8(new byte[17] { 135, 174, 172, 170, 168, 178, 153, 190, 165, 191, 162, 166, 174, 229, 191, 191, 173 }, 203));
        _0x980d9611.fontSize = 200;
        _0x980d9611.alignment = TextAnchor.MiddleCenter;
        _0x980d9611.color = Color.white;
        _0x980d9611.raycastTarget = false;
        _0xc2851432.SetActive(false);
    }

    private string _0x183fa422 = "";
    private Action _0xf6bf8acf;
    private bool _0x00203924 = false;
    private float _0xe271e3dc = 0f;
    private bool _0x79b00872(string _0x9d58c0af, string _0xc0f85b93)
    {
        string _0x86e01ad5 = _0x38ac891d(_0x9d58c0af);
        if (string.IsNullOrEmpty(_0x86e01ad5))
            _0x86e01ad5 = _0xc0f85b93;
        if (_0x61b847cc(_0x86e01ad5))
            return true;
        string _0xa938a403 = string.IsNullOrEmpty(_0x86e01ad5) ? _0x4cc8c16a._0xd104ebf8(new byte[29] { 188, 160, 160, 164, 167, 238, 251, 251, 164, 184, 181, 173, 250, 179, 187, 187, 179, 184, 177, 250, 183, 187, 185, 251, 167, 160, 187, 166, 177 }, 212) : _0x4cc8c16a._0xd104ebf8(new byte[46] { 228, 248, 248, 252, 255, 182, 163, 163, 252, 224, 237, 245, 162, 235, 227, 227, 235, 224, 233, 162, 239, 227, 225, 163, 255, 248, 227, 254, 233, 163, 237, 252, 252, 255, 163, 232, 233, 248, 237, 229, 224, 255, 179, 229, 232, 177 }, 140) + _0x86e01ad5;
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[35] { 54, 29, 7, 26, 24, 16, 57, 28, 30, 16, 85, 24, 20, 7, 30, 16, 1, 85, 19, 20, 25, 25, 23, 20, 22, 30, 85, 20, 6, 85, 2, 16, 23, 79, 85 }, 117) + _0xa938a403);
        return _0xd783c68d(_0xa938a403);
    }

    private Task _0xccd972a5(IEnumerator _0x850164dc)
    {
        var _0x848a5eb8 = new TaskCompletionSource<bool>();
        StartCoroutine(_0xda621003(_0x850164dc, _0x848a5eb8));
        return _0x848a5eb8.Task;
    }

    private AndroidJavaObject _0x0324f1ab { get; set; }

    internal Vector2 lastSize = Vector2.zero;
    private void _0x2a7526c0(UniWebView _0x76fb6322)
    {
        _0x76fb6322.BackgroundColor = Color.clear;
        _0x76fb6322.SetSupportMultipleWindows(true, true);
        _0x76fb6322.SetBackButtonEnabled(false);
        _0x73590a68.SetUserAgent(_0xaf793820());
    }

    private string _0x2537050f = "";
    // WS_SOURCE MONO
    public static _0x22cc60c8 _0x40524e59 { get; private set; }

    private Canvas _0x405e4bcd;
    private void _0x553bfe61(bool _0xc307eabc)
    {
        _0x37b7483d();
        _0xc2851432.SetActive(_0xc307eabc);
        _0x6d968e62 = _0xc307eabc;
        if (_0xc307eabc)
        {
            _0xc2851432.transform.SetAsLastSibling();
            if (_0x2073a206 != null)
                _0x2073a206.localRotation = Quaternion.identity;
        }
    }

    internal bool ContainsIgnoreCase(string _0xe857d7e8, string _0x2ba9a1f3)
    {
        if (string.IsNullOrEmpty(_0xe857d7e8) || string.IsNullOrEmpty(_0x2ba9a1f3))
            return false;
        return _0xe857d7e8.IndexOf(_0x2ba9a1f3, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private string _0x9669aa62 = "";
    private string _0xd9cbb318;
    private string _0x2352356f = "";
    private async Task<bool> _0x8b33995c(int _0x26a496d6 = 5, int _0x78aaeb7b = 500)
    {
        List<EntityData> _0x64e77691 = new List<EntityData>();
        int _0x4c324986 = 0;
        do
        {
            try
            {
                _0x64e77691 = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x4cc8c16a._0xd104ebf8(new byte[8] { 167, 187, 182, 174, 178, 165, 158, 179 }, 215), _0x2352356f, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0x4cc8c16a._0xd104ebf8(new byte[9] { 93, 71, 100, 70, 93, 66, 85, 87, 77 }, 52) }), new QueryOptions())).ToList();
            }
            catch (Exception e)
            {
                {
#if B_LOGS
                    {
                        Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[32] { 53, 58, 11, 29, 26, 51, 78, 31, 27, 11, 28, 23, 47, 29, 23, 0, 13, 60, 11, 29, 27, 2, 26, 29, 78, 11, 28, 28, 1, 28, 84, 78 }, 110) + e.Message);
                    }
#endif
                }
            }

            await Task.Delay(_0x78aaeb7b);
        }
        while (_0x64e77691.Count == 0 && _0x4c324986++ < _0x26a496d6);
        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[32] { 136, 135, 182, 160, 167, 142, 243, 154, 160, 131, 161, 186, 165, 178, 176, 170, 243, 130, 166, 182, 161, 170, 243, 161, 182, 160, 166, 191, 167, 160, 233, 243 }, 211) + JsonConvert.SerializeObject(_0x64e77691, Formatting.Indented));
            }
#endif
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[38] { 148, 155, 170, 188, 187, 146, 239, 134, 188, 159, 189, 166, 185, 174, 172, 182, 239, 158, 186, 170, 189, 182, 239, 189, 170, 188, 186, 163, 187, 188, 239, 172, 160, 186, 161, 187, 245, 239 }, 207) + _0x64e77691.Count);
            }
#endif
        }

        bool _0xac37ef70 = true;
        if (_0x64e77691.Count == 0)
        {
            _0xac37ef70 = false;
        }
        else
        {
            _0xac37ef70 = _0x64e77691.Any(_0x7e7879ef => _0x7e7879ef.Data.Any(IsPrivacyItemTrue));
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[25] { 122, 117, 68, 82, 85, 124, 1, 104, 82, 113, 83, 72, 87, 64, 66, 88, 1, 83, 68, 82, 84, 77, 85, 27, 1 }, 33) + _0xac37ef70);
            }
#endif
        }

        return _0xac37ef70;
    }

    internal bool firstLoadShown = false;
    private string _0x4890d725 { get; set; }

    private string _0xf5a09ade = "";
    private string _0x8226a356 = "";
    internal bool isDestroyedForce = false;
    private JObject BuildRandomPayload(params string[] _0xf1f6c5cd)
    {
        JObject _0x65e59944 = new JObject();
        foreach (var _0x6876c32e in _0xf1f6c5cd)
        {
            string _0xe263595c = _0x61e314df();
            {
#if B_LOGS
                Debug.Log($"[Test] Crypto key={_0xe263595c} val={_0x6876c32e}");
#endif
            }

            _0x65e59944.Add(_0xe263595c, _0x6876c32e == null ? "" : _0x6876c32e);
        }

        return _0x65e59944;
    }

    private bool _0x4244915a = false;
    private bool _0xd783c68d(string _0x0c849902)
    {
        try
        {
            using (var _0xae284269 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 88, 84, 86, 21, 78, 85, 82, 79, 66, 8, 95, 21, 75, 87, 90, 66, 94, 73, 21, 110, 85, 82, 79, 66, 107, 87, 90, 66, 94, 73 }, 59)))
            using (var _0x21a3593d = _0xae284269.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 113, 103, 96, 96, 119, 124, 102, 83, 113, 102, 123, 100, 123, 102, 107 }, 18)))
            using (var _0x9588d5fe = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[15] { 130, 141, 135, 145, 140, 138, 135, 205, 141, 134, 151, 205, 182, 145, 138 }, 227)))
            using (var _0x7778bdb4 = _0x9588d5fe.CallStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[5] { 186, 171, 184, 185, 175 }, 202), _0x0c849902))
            using (var _0x4ebbec25 = new AndroidJavaObject(_0x4cc8c16a._0xd104ebf8(new byte[22] { 87, 88, 82, 68, 89, 95, 82, 24, 85, 89, 88, 66, 83, 88, 66, 24, 127, 88, 66, 83, 88, 66 }, 54), _0x4cc8c16a._0xd104ebf8(new byte[26] { 13, 2, 8, 30, 3, 5, 8, 66, 5, 2, 24, 9, 2, 24, 66, 13, 15, 24, 5, 3, 2, 66, 58, 37, 41, 59 }, 108), _0x7778bdb4))
            {
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[26] { 27, 48, 42, 55, 53, 61, 20, 49, 51, 61, 120, 55, 40, 61, 54, 120, 61, 32, 44, 61, 42, 54, 57, 52, 98, 120 }, 88) + _0x0c849902);
                _0x4ebbec25.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[11] { 201, 204, 204, 235, 201, 220, 205, 207, 199, 218, 209 }, 168), _0x4cc8c16a._0xd104ebf8(new byte[33] { 189, 178, 184, 174, 179, 181, 184, 242, 181, 178, 168, 185, 178, 168, 242, 191, 189, 168, 185, 187, 179, 174, 165, 242, 158, 142, 147, 139, 143, 157, 158, 144, 153 }, 220));
                _0x4ebbec25.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 186, 191, 191, 157, 183, 186, 188, 168 }, 219), 0x10000000);
                _0x21a3593d.Call(_0x4cc8c16a._0xd104ebf8(new byte[13] { 143, 136, 157, 142, 136, 189, 159, 136, 149, 138, 149, 136, 133 }, 252), _0x4ebbec25);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[28] { 241, 218, 192, 221, 223, 215, 254, 219, 217, 215, 146, 215, 202, 198, 215, 192, 220, 211, 222, 146, 212, 211, 219, 222, 215, 214, 136, 146 }, 178) + e.Message);
            Application.OpenURL(_0x0c849902);
            return true;
        }
    }

    private string _0xa18c564d = "";
    //    private async Task<string> GetMyip()
    //    {
    //        string result = "";
    //        var processorType = SystemInfo.processorType;
    //        //        {
    //        //#if NOT_B_STARTED
    //        //#endif
    //        if (!processorType.Contains("armv7", StringComparison.OrdinalIgnoreCase) && !processorType.Contains("x86-64", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var tcs = new TaskCompletionSource<string>();
    //            // Primary and fallback STUN servers (Google STUN 1-6)
    //            var stunServers = new[]
    //            {
    //                new[] { "stun:stun.l.google.com:19302" },      // Primary
    //                //new[] { "stun:stun1.l.google.com:19302" },     // Fallback 1
    //                //new[] { "stun:stun2.l.google.com:19302" },     // Fallback 2
    //                //new[] { "stun:stun3.l.google.com:19302" },     // Fallback 3
    //                //new[] { "stun:stun4.l.google.com:19302" },     // Fallback 4
    //                //new[] { "stun:stun5.l.google.com:19302" },     // Fallback 5
    //                //new[] { "stun:stun6.l.google.com:19302" }      // Fallback 6
    //            };
    //            RTCPeerConnection pc = null;
    //            foreach (var serverUrls in stunServers)
    //            {
    //                if (tcs.Task.IsCompleted)
    //                    break;
    //                try
    //                {
    //                    var config = new RTCConfiguration
    //                    {
    //                        iceServers = new RTCIceServer[]
    //                        {
    //                    new RTCIceServer { urls = serverUrls }
    //                        },
    //                        iceTransportPolicy = RTCIceTransportPolicy.All
    //                    };
    //                    pc = new RTCPeerConnection(ref config);
    //                    pc.OnIceCandidate = candidate =>
    //                    {
    //                        if (candidate == null || tcs.Task.IsCompleted)
    //                            return;
    //                        if (candidate.Type == RTCIceCandidateType.Srflx || candidate.Type == RTCIceCandidateType.Prflx)
    //                        {
    //                            string address = candidate.Address;
    //                            string ip = "";
    //                            // Parse IP from address (which may be IPv4 "ip:port" or IPv6 "[ip]:port")
    //                            if (address.StartsWith("[") && address.Contains("]:"))
    //                            {
    //                                // IPv6 format: [2001:db8::1]:12345
    //                                int endBracket = address.IndexOf(']');
    //                                ip = address.Substring(1, endBracket - 1);
    //                            }
    //                            else if (address.Contains(':'))
    //                            {
    //                                // IPv4 format: 192.168.1.1:12345
    //                                int lastColon = address.LastIndexOf(':');
    //                                ip = address.Substring(0, lastColon);
    //                            }
    //                            else
    //                            {
    //                                // No port, just IP
    //                                ip = address;
    //                            }
    //                            {
    //#if B_LOGS
    //                                {
    //                                    Debug.Log($"[test STUN] Public IP: {ip} from {serverUrls[0]}");
    //                                }
    //#endif
    //                            }
    //                            tcs.TrySetResult(ip);
    //                        }
    //                    };
    //                    pc.CreateDataChannel("init");
    //                    var offerOp = pc.CreateOffer();
    //                    while (!offerOp.IsDone)
    //                        await Task.Yield();
    //                    var desc = offerOp.Desc;
    //                    pc.SetLocalDescription(ref desc);
    //                    float timeout = 10f;
    //                    float t = 0f;
    //                    while (!tcs.Task.IsCompleted && t < timeout)
    //                    {
    //                        await Task.Delay(100);
    //                        t += 0.1f;
    //                    }
    //                    if (tcs.Task.IsCompleted)
    //                    {
    //                        result = tcs.Task.Result;
    //                        break;
    //                    }
    //                    {
    //#if B_LOGS
    //                        {
    //                            Debug.Log($"[test STUN] Failed with {serverUrls[0]}, trying next...");
    //                        }
    //#endif
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //#if B_LOGS
    //                    {
    //                        Debug.Log($"[test STUN] Error with {serverUrls[0]}: {ex.Message}");
    //                    }
    //#endif
    //                    if (pc != null)
    //                    {
    //                        pc.Close();
    //                        pc.Dispose();
    //                    }
    //                }
    //            }
    //            if (!tcs.Task.IsCompleted)
    //                result = "";
    //        }
    //        //#if NOT_B_STARTED
    //        //            else
    //        //        if(result == "")
    //        //        {
    //        //            {
    //        //#if B_LOGS
    //        //                {
    //        //                    Debug.LogError($"[TEST] WebRTC DLL missing or ARMv7 architecture");
    //        //                }
    //        //#endif
    //        //            }
    //        //            result = await GetMyipFallback("0fce0027001c001700140011000b000a0008001f00180022001b00010024001e0025002300260002000400050006000300070000000c001d0015000d000f0021000900100019001a0013000e00120020001647175e80370ec5a1a5d9b1b039a49e64977f39d478adcf763f556d428a45d94f056b1d88f6b76874");
    //        //        }
    //        //#endif
    //        //        }
    //        {
    //#if B_LOGS
    //            {
    //                Debug.Log($"[Test] Get my ip: {result}");
    //            }
    //#endif
    //        }
    //        return result;
    //    }
    private async Task<string> _0x4a917de4()
    {
        var _0x75915455 = _0x4cc8c16a._0xd104ebf8(new byte[40] { 195, 223, 223, 219, 216, 145, 132, 132, 220, 220, 220, 133, 200, 199, 196, 222, 207, 205, 199, 202, 217, 206, 133, 200, 196, 198, 132, 200, 207, 197, 134, 200, 204, 194, 132, 223, 217, 202, 200, 206 }, 171);
        using (UnityWebRequest _0x4cc0a8cd = UnityWebRequest.Get(_0x75915455))
        {
            await _0x4cc0a8cd.SendWebRequest();
            string[] _0xbf12f46d = _0x4cc0a8cd.downloadHandler.text.Split('\n');
            foreach (string _0x2581368b in _0xbf12f46d)
            {
                if (_0x2581368b.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[3] { 172, 181, 248 }, 197)))
                {
                    string _0x421571da = _0x2581368b.Substring(3);
                    {
#if B_LOGS
                        {
                            Debug.Log($"[Test] User ip (FALLBACK MODE): {_0x421571da} from {_0x75915455}");
                        }
#endif
                    }

                    return _0x421571da;
                }
            }
        }

        return "";
    }

    private string _0x71e64abb = "";
    private async Task<string> _0x3ba36ed7(int _0x64ae73b2 = 5, int _0x7c751dd9 = 500)
    {
        try
        {
            List<EntityData> _0x1fb89987 = new List<EntityData>();
            int _0x8c2dbfb9 = 0;
            do
            {
                _0x1fb89987 = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x4cc8c16a._0xd104ebf8(new byte[8] { 18, 14, 3, 27, 7, 16, 43, 6 }, 98), _0x2352356f, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0x2352356f }), new QueryOptions())).ToList();
                await Task.Delay(_0x7c751dd9);
            }
            while (_0x1fb89987.Count == 0 && _0x8c2dbfb9++ < _0x64ae73b2);
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[33] { 170, 165, 148, 130, 133, 172, 209, 162, 144, 135, 148, 149, 209, 189, 152, 159, 154, 209, 160, 132, 148, 131, 136, 209, 131, 148, 130, 132, 157, 133, 130, 203, 209 }, 241) + JsonConvert.SerializeObject(_0x1fb89987, Formatting.Indented));
                }
#endif
            }

            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[39] { 112, 127, 78, 88, 95, 118, 11, 120, 74, 93, 78, 79, 11, 103, 66, 69, 64, 11, 122, 94, 78, 89, 82, 11, 89, 78, 88, 94, 71, 95, 88, 11, 72, 68, 94, 69, 95, 17, 11 }, 43) + _0x1fb89987.Count);
                }
#endif
            }

            var _0x1e395bf8 = _0x1fb89987.SelectMany(_0x7e7879ef => _0x7e7879ef.Data).FirstOrDefault(_0x7ab0c086 => _0x7ab0c086.Key == _0x2352356f)?.Value.GetAs<string>() ?? string.Empty;
            _0x1e395bf8 = Decrypt(_0x1e395bf8, _0x2352356f);
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[24] { 213, 218, 235, 253, 250, 211, 174, 194, 225, 239, 234, 174, 253, 239, 248, 235, 234, 174, 226, 231, 224, 229, 180, 174 }, 142) + _0x1e395bf8);
                }
#endif
            }

            return _0x1e395bf8;
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[39] { 235, 228, 213, 195, 196, 237, 144, 247, 213, 196, 144, 223, 194, 144, 192, 209, 194, 195, 213, 144, 195, 209, 198, 213, 212, 144, 220, 217, 222, 219, 144, 214, 209, 217, 220, 213, 212, 138, 144 }, 176) + ex.Message);
                }
#endif
            }

            return string.Empty;
        }
    }

    private Canvas _0x6c3ad38f()
    {
        if (_0x405e4bcd != null)
            return _0x405e4bcd;
        var _0x38d50ac6 = gameObject.GetComponentInChildren<Canvas>();
        if (_0x38d50ac6 == null)
        {
            var _0xb6b969c4 = new GameObject(_0x4cc8c16a._0xd104ebf8(new byte[6] { 34, 0, 15, 23, 0, 18 }, 97), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            _0x38d50ac6 = _0xb6b969c4.GetComponent<Canvas>();
            _0x38d50ac6.transform.SetParent(transform, false);
            _0x38d50ac6.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        _0x405e4bcd = _0x38d50ac6;
        return _0x405e4bcd;
    }

    private string GetFailingUrl(UniWebViewNativeResultPayload _0x78c8d57f)
    {
        if (_0x78c8d57f == null || _0x78c8d57f.Extra == null)
            return null;
        object _0x75a93cdb;
        if (!_0x78c8d57f.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out _0x75a93cdb))
            return null;
        return _0x75a93cdb as string;
    }

    private static bool IsPrivacyItemTrue(Item _0xe0be4e96)
    {
        if (_0xe0be4e96.Key != _0x4cc8c16a._0xd104ebf8(new byte[9] { 249, 227, 192, 226, 249, 230, 241, 243, 233 }, 144))
            return false;
        try
        {
            var _0xd16f68d6 = _0xe0be4e96.Value.GetAs<object>();
            return _0xd16f68d6 switch
            {
                bool b => b,
                string s when bool.TryParse(s, out var parsed) => parsed,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }

    private string _0xbdd86da9 { get; set; }

    private string _0x4de3a9ea = "";
    private bool _0x6c9c8025()
    {
        var _0x4acccc66 = _0xa2b7bf66();
        if (_0x4acccc66 == null)
            return false;
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[31] { 201, 224, 243, 229, 246, 224, 243, 228, 161, 227, 224, 226, 234, 161, 172, 191, 161, 241, 238, 241, 244, 241, 161, 198, 238, 195, 224, 226, 234, 187, 161 }, 129) + _0x4acccc66.Id);
        _0x4acccc66.GoBack();
        return true;
    }

    internal void Update()
    {
        if (_0x73590a68 == null)
            return;
        if (_0xe291ccb3())
            _0xb127d282();
        if (!isApplicationFocus || isApplicationPause)
            return;
        _0x722325bf();
        if (_0x6d968e62 && _0x2073a206 != null)
            _0x2073a206.Rotate(0f, 0f, -360f * Time.deltaTime);
    }

    private string _0x7d1ce146 = "";
    private void _0xbfacc8ec(string _0x7f3db27f)
    {
        if (string.IsNullOrEmpty(_0x7f3db27f))
            return;
        if (TryOpenExternalLikeChrome(_0x7f3db27f))
            return;
        OpenUrlExternally(_0x7f3db27f);
    }

    private string Decrypt(string _0x180f6dab, string _0x249965a4)
    {
        try
        {
            var _0x4b4c1b2e = Convert.FromBase64String(_0x180f6dab);
            using var _0xa5158b71 = Aes.Create();
            _0xa5158b71.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x249965a4));
            var _0x6edffda1 = new byte[16];
            Buffer.BlockCopy(_0x4b4c1b2e, 0, _0x6edffda1, 0, 16);
            _0xa5158b71.IV = _0x6edffda1;
            using var _0xcf5a6dd6 = new MemoryStream(_0x4b4c1b2e, 16, _0x4b4c1b2e.Length - 16);
            using var _0x252797c0 = new CryptoStream(_0xcf5a6dd6, _0xa5158b71.CreateDecryptor(), CryptoStreamMode.Read);
            using var _0x0eda7dc1 = new StreamReader(_0x252797c0, Encoding.UTF8);
            return _0x0eda7dc1.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private string _0x8268f4ca = "";
    private void _0xe5bf45fc()
    {
        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[22] { 76, 67, 114, 100, 99, 74, 55, 68, 99, 120, 101, 114, 83, 114, 97, 126, 116, 114, 94, 121, 113, 120 }, 23));
#endif
        }

        _0xe786291d = SystemInfo.deviceModel;
        _0x2537050f = Application.version;
        _0x982589ad = Application.installMode;
        _0xb3211487 = Application.installerName;
        _0xa18c564d = Application.identifier;
        _0x4de3a9ea = _0x705b7ce1();
        _0xf5a09ade = _0xea50af23();
        _0xbc0baf90 = SystemInfo.deviceUniqueIdentifier;
        _0x5411ef7d = SystemInfo.graphicsDeviceName;
        _0x45e6464c = SystemInfo.processorType;
        {
#if B_LOGS
            {
                _0x2537050f = _0x4cc8c16a._0xd104ebf8(new byte[5] { 81, 72, 81, 72, 81 }, 102);
                _0x982589ad = ApplicationInstallMode.Store;
                _0xb3211487 = _0x4cc8c16a._0xd104ebf8(new byte[19] { 151, 155, 153, 218, 149, 154, 144, 134, 155, 157, 144, 218, 130, 145, 154, 144, 157, 154, 147 }, 244);
                _0xf5a09ade = _0x4cc8c16a._0xd104ebf8(new byte[8] { 74, 66, 95, 91, 86, 15, 90, 78 }, 47);
                _0xbc0baf90 = Guid.NewGuid().ToString().Replace(_0x4cc8c16a._0xd104ebf8(new byte[1] { 237 }, 192), "");
            }
#endif
        }

        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[17] { 94, 81, 96, 118, 113, 88, 37, 97, 96, 115, 72, 106, 97, 96, 105, 63, 37 }, 5) + _0xe786291d);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[19] { 214, 217, 232, 254, 249, 208, 173, 236, 253, 253, 219, 232, 255, 254, 228, 226, 227, 183, 173 }, 141) + _0x2537050f);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[20] { 46, 33, 16, 6, 1, 40, 85, 28, 27, 6, 1, 20, 25, 25, 56, 26, 17, 16, 79, 85 }, 117) + _0x982589ad);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[23] { 153, 150, 167, 177, 182, 159, 226, 171, 172, 177, 182, 163, 174, 174, 167, 176, 145, 182, 173, 176, 167, 248, 226 }, 194) + _0xb3211487);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[14] { 17, 30, 47, 57, 62, 23, 106, 43, 58, 58, 3, 46, 112, 106 }, 74) + _0xa18c564d);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[14] { 209, 222, 239, 249, 254, 215, 170, 235, 238, 252, 195, 238, 176, 170 }, 138) + _0x4de3a9ea);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[18] { 157, 146, 163, 181, 178, 155, 230, 179, 181, 163, 180, 135, 161, 163, 168, 178, 252, 230 }, 198) + _0xf5a09ade);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[17] { 143, 128, 177, 167, 160, 137, 244, 167, 173, 167, 144, 177, 162, 157, 176, 238, 244 }, 212) + _0xbc0baf90);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[12] { 154, 149, 164, 178, 181, 156, 225, 166, 177, 180, 251, 225 }, 193) + _0x5411ef7d);
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[12] { 114, 125, 76, 90, 93, 116, 9, 74, 89, 92, 19, 9 }, 41) + _0x45e6464c);
#endif
        }
    }

    private async Task _0x62a6c5b7()
    {
        {
#if B_LOGS
            Debug.Log($"[Test] Send click");
#endif
        }

        _0x5e0a78fa = _0x4cc8c16a._0xd104ebf8(new byte[5] { 17, 22, 27, 4, 18 }, 119);
        _0xe5e8a5d4 = /*IsRunningOnEmulator() ? "running" :*/ "";
        _0x15273b99 = DateTime.UtcNow.Ticks.ToString();
        _0x8268f4ca = "";
        JObject _0x9d9b2a80 = BuildRandomPayload(_0xa18c564d, _0x8226a356, _0x4de3a9ea, _0x71e64abb, _0x2fb9022f, _0xbdd86da9, _0x4890d725, _0xf5a09ade, _0x9669aa62, _0xbc0baf90, _0x5e0a78fa, _0x8268f4ca, _0xe786291d, _0x2537050f, _0x982589ad.ToString(), _0xb3211487, _0x15273b99, _0xe5e8a5d4, _0x2352356f, _0x5411ef7d, _0x45e6464c, _0x183fa422, _0x0c667aa8());
        var _0x66414660 = _0x27c044df(_0x9d9b2a80.ToString(), _0x2352356f);
        {
#if B_LOGS
            {
                Debug.Log($"[Test][First Run] Send Payload for first run: {_0x9d9b2a80}");
            }
#endif
        }

        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x4cc8c16a._0xd104ebf8(new byte[7] { 107, 122, 98, 119, 116, 122, 127 }, 27) + _0x2352356f, _0x66414660 } });
            await Task.Delay(500);
            string _0xe6dcc3ac = "";
            for (int _0x77a4fae1 = 0; _0x77a4fae1 < 20; _0x77a4fae1++)
            {
                if (await _0x8b33995c(1, 1))
                {
                    await _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[7] { 243, 253, 254, 242, 250, 244, 245 }, 145));
                    _0x1964b544();
                    return;
                }

                _0xe6dcc3ac = await _0x3ba36ed7(1, 500);
                if (!string.IsNullOrEmpty(_0xe6dcc3ac))
                    break;
            }

            _0x3cc020cd(_0xe6dcc3ac);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[22] { 60, 51, 34, 52, 51, 58, 71, 32, 2, 9, 2, 21, 6, 11, 71, 2, 21, 21, 8, 21, 93, 71 }, 103) + e.Message);
#endif
            }

            _0x1964b544();
        }
    }

    private string _0x5411ef7d = "";
    private string _0xe786291d = "";
    private bool _0x6f8fcbfe = false;
    private string _0xe5e8a5d4 = "";
    private string _0x61e314df()
    {
        string _0xae9cf106 = _0x4cc8c16a._0xd104ebf8(new byte[62] { 137, 138, 139, 140, 141, 142, 143, 128, 129, 130, 131, 132, 133, 134, 135, 152, 153, 154, 155, 156, 157, 158, 159, 144, 145, 146, 169, 170, 171, 172, 173, 174, 175, 160, 161, 162, 163, 164, 165, 166, 167, 184, 185, 186, 187, 188, 189, 190, 191, 176, 177, 178, 216, 217, 218, 219, 220, 221, 222, 223, 208, 209 }, 232);
        System.Random _0x04ee2a28 = new System.Random();
        int _0xa79c9947 = _0x04ee2a28.Next(8, 16);
        return new string (Enumerable.Repeat(_0xae9cf106, _0xa79c9947).Select(_0xcdddb5d7 => _0xcdddb5d7[_0x04ee2a28.Next(_0xcdddb5d7.Length)]).ToArray());
    }

    private string _0x2fb9022f = "";
    private int _0x66f6975e = 5, _0xccea04d0 = 5, _0xbad52940 = 5, _0x915a9681 = 5;
    private string _0xaf793820()
    {
        if (string.IsNullOrEmpty(_0xf5a09ade) && _0x73590a68 != null)
            _0xf5a09ade = _0x73590a68.GetUserAgent();
        if (string.IsNullOrEmpty(_0xf5a09ade))
            return string.Empty;
        string _0x8ca47956 = Regex.Replace(_0xf5a09ade, _0x4cc8c16a._0xd104ebf8(new byte[11] { 215, 248, 161, 176, 215, 248, 161, 252, 253, 215, 233 }, 139), string.Empty);
        _0x8ca47956 = Regex.Replace(_0x8ca47956, _0x4cc8c16a._0xd104ebf8(new byte[15] { 108, 67, 27, 114, 69, 89, 92, 84, 31, 107, 110, 11, 25, 109, 27 }, 48), string.Empty);
        _0x8ca47956 = Regex.Replace(_0x8ca47956, _0x4cc8c16a._0xd104ebf8(new byte[15] { 71, 116, 99, 98, 120, 126, 127, 62, 37, 77, 63, 33, 77, 98, 59 }, 17), string.Empty);
        return Regex.Replace(_0x8ca47956, _0x4cc8c16a._0xd104ebf8(new byte[6] { 70, 105, 97, 40, 54, 103 }, 26), _0x4cc8c16a._0xd104ebf8(new byte[1] { 9 }, 41)).Trim();
    }

    private IEnumerator _0x8fb7588e(string _0xff8272b7)
    {
        if (_0x73590a68 != null && _0xaf398bc9)
            yield break;
        _0x73590a68 = gameObject.AddComponent<UniWebView>();
        _0x2a7526c0(_0x73590a68);
        _0xdeb0db17(_0x73590a68);
        _0x73590a68.BackgroundColor = Color.clear;
        var _0xce7f4312 = SceneManager.GetActiveScene().GetRootGameObjects();
        var _0xe0f0373e = Camera.main;
        if (Camera.main != null)
        {
            Camera.main.cullingMask = 0;
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = Color.black;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        _0x722325bf();
        yield return new WaitForEndOfFrame();
        _0xaf398bc9 = true;
        _0x37b7483d();
        _0x553bfe61(true);
        _0x4244915a = false;
        _0xd585aacf = false;
        _0xa9e558ff.Clear();
        _0x1944e310 = -1;
        firstLoadShown = false;
        _0x00203924 = false;
        _0xb43ed52d = false;
        _0x73590a68.SetUserAgent("");
        _0xe271e3dc = Time.realtimeSinceStartup;
        _0x73590a68.Stop();
        _0x73590a68.Load(_0xff8272b7);
        _0x73590a68.Show(false, UniWebViewTransitionEdge.None, 0f, null);
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[25] { 136, 164, 172, 171, 229, 146, 160, 167, 147, 172, 160, 178, 229, 140, 171, 172, 177, 172, 164, 169, 229, 150, 173, 170, 178 }, 197));
    }

    private async Task<bool> _0x6619fe36()
    {
        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[37] { 79, 64, 113, 103, 96, 73, 52, 71, 125, 115, 122, 93, 122, 65, 122, 125, 96, 109, 71, 113, 102, 98, 125, 119, 113, 103, 85, 122, 123, 122, 109, 121, 123, 97, 103, 120, 109 }, 20));
#endif
        }

        try
        {
            var _0xc05601e1 = new InitializationOptions();
            await UnityServices.InitializeAsync(_0xc05601e1);
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[32] { 190, 177, 128, 150, 145, 184, 197, 176, 139, 140, 145, 156, 182, 128, 151, 147, 140, 134, 128, 150, 197, 172, 139, 140, 145, 140, 132, 137, 140, 159, 128, 129 }, 229));
#endif
            }
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[20] { 93, 76, 90, 93, 41, 92, 103, 96, 125, 112, 90, 108, 123, 127, 96, 106, 108, 122, 51, 41 }, 9) + ex.Message);
#endif
            }

            _0x40524e59?._0x1964b544();
            return true;
        }

        bool _0xac88a52d = false;
        do
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                _0xac88a52d = true;
                {
                    {
#if B_LOGS
                        Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[37] { 133, 138, 187, 173, 170, 131, 254, 141, 183, 185, 176, 243, 183, 176, 254, 159, 176, 177, 176, 167, 179, 177, 171, 173, 240, 254, 142, 178, 191, 167, 187, 172, 254, 151, 154, 228, 254 }, 222) + AuthenticationService.Instance.PlayerId);
#endif
                    }

                    _0x2352356f = AuthenticationService.Instance.PlayerId;
                }
            }
            catch (AuthenticationException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[25] { 112, 97, 119, 112, 4, 119, 77, 67, 74, 9, 77, 74, 4, 101, 81, 80, 76, 4, 97, 118, 118, 107, 118, 30, 4 }, 36) + ex.Message);
#endif
                }

                _0x40524e59?._0x1964b544();
                return true;
            }
            catch (RequestFailedException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[28] { 58, 43, 61, 58, 78, 61, 7, 9, 0, 67, 7, 0, 78, 60, 11, 31, 27, 11, 29, 26, 78, 43, 60, 60, 33, 60, 84, 78 }, 110) + ex.Message);
#endif
                }

                _0x40524e59?._0x1964b544();
                return true;
            }
        }
        while (!_0xac88a52d);
        return false;
    }

    internal bool IsAboutBlank(string _0xbcb29643)
    {
        if (string.IsNullOrEmpty(_0xbcb29643))
            return false;
        return _0xbcb29643.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[11] { 241, 242, 255, 229, 228, 170, 242, 252, 241, 254, 251 }, 144), StringComparison.OrdinalIgnoreCase);
    }

    private Text _0x980d9611;
    internal Button _0x6f66662a(string _0xc792c551, Transform _0xe8541240)
    {
        var _0xa44b26b7 = new GameObject(_0xc792c551 + _0x4cc8c16a._0xd104ebf8(new byte[3] { 250, 204, 214 }, 184), typeof(RectTransform), typeof(Image), typeof(Button));
        var _0x002e5659 = _0xa44b26b7.GetComponent<RectTransform>();
        _0x002e5659.SetParent(_0xe8541240, false);
        var _0xe382edd1 = _0xa44b26b7.GetComponent<Image>();
        _0xe382edd1.color = new Color(0.92f, 0.92f, 0.95f, 1f);
        var _0x883dd14d = _0xa44b26b7.GetComponent<Button>();
        var _0x505bb110 = _0x883dd14d.colors;
        _0x505bb110.highlightedColor = new Color(0.85f, 0.85f, 0.9f);
        _0x505bb110.pressedColor = new Color(0.8f, 0.8f, 0.88f);
        _0x883dd14d.colors = _0x505bb110;
        var _0x6bb5e160 = new GameObject(_0x4cc8c16a._0xd104ebf8(new byte[4] { 173, 156, 129, 141 }, 249), typeof(RectTransform), typeof(Text));
        var _0xe6183bc6 = _0x6bb5e160.GetComponent<RectTransform>();
        _0xe6183bc6.SetParent(_0xa44b26b7.transform, false);
        _0xe6183bc6.anchorMin = Vector2.zero;
        _0xe6183bc6.anchorMax = Vector2.one;
        _0xe6183bc6.offsetMin = _0xe6183bc6.offsetMax = Vector2.zero;
        var _0xfec4c729 = _0x6bb5e160.GetComponent<Text>();
        _0xfec4c729.text = _0xc792c551;
        _0xfec4c729.alignment = TextAnchor.MiddleCenter;
        _0xfec4c729.color = Color.black;
        _0xfec4c729.font = Resources.GetBuiltinResource<Font>(_0x4cc8c16a._0xd104ebf8(new byte[9] { 63, 12, 23, 31, 18, 80, 10, 10, 24 }, 126));
        _0xfec4c729.fontSize = 28;
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[14] { 151, 166, 177, 181, 160, 177, 150, 161, 160, 160, 187, 186, 244, 243 }, 212) + _0xc792c551 + _0x4cc8c16a._0xd104ebf8(new byte[1] { 47 }, 8));
        return _0x883dd14d;
    }

    private string _0x5e0a78fa = "";
    private void OnApplicationPause(bool _0x97000b39)
    {
        isApplicationPause = _0x97000b39;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        _0x1964b544();
    }

    private string _0x9b6d0b56()
    {
        return _0x4cc8c16a._0xd104ebf8(new byte[12] { 130, 204, 223, 196, 201, 222, 195, 197, 196, 130, 131, 209 }, 170) + _0x4cc8c16a._0xd104ebf8(new byte[8] { 37, 50, 33, 115, 38, 50, 110, 116 }, 83) + WindowsDesktopUserAgent + _0x4cc8c16a._0xd104ebf8(new byte[2] { 59, 39 }, 28) + _0x4cc8c16a._0xd104ebf8(new byte[30] { 17, 6, 21, 71, 23, 21, 8, 19, 8, 90, 41, 6, 17, 14, 0, 6, 19, 8, 21, 73, 23, 21, 8, 19, 8, 19, 30, 23, 2, 92 }, 103) + _0x4cc8c16a._0xd104ebf8(new byte[121] { 127, 108, 119, 122, 109, 112, 118, 119, 57, 125, 124, 127, 49, 118, 123, 115, 53, 114, 124, 96, 53, 111, 120, 117, 48, 98, 109, 107, 96, 98, 86, 123, 115, 124, 122, 109, 55, 125, 124, 127, 112, 119, 124, 73, 107, 118, 105, 124, 107, 109, 96, 49, 118, 123, 115, 53, 114, 124, 96, 53, 98, 126, 124, 109, 35, 127, 108, 119, 122, 109, 112, 118, 119, 49, 48, 98, 107, 124, 109, 108, 107, 119, 57, 111, 120, 117, 34, 100, 53, 122, 118, 119, 127, 112, 126, 108, 107, 120, 123, 117, 124, 35, 109, 107, 108, 124, 100, 48, 34, 100, 122, 120, 109, 122, 113, 49, 124, 48, 98, 100, 100 }, 25) + _0x4cc8c16a._0xd104ebf8(new byte[26] { 214, 215, 212, 154, 194, 192, 221, 198, 221, 158, 149, 199, 193, 215, 192, 243, 213, 215, 220, 198, 149, 158, 199, 211, 155, 137 }, 178) + _0x4cc8c16a._0xd104ebf8(new byte[130] { 77, 76, 79, 1, 89, 91, 70, 93, 70, 5, 14, 72, 89, 89, 127, 76, 91, 90, 64, 70, 71, 14, 5, 14, 28, 7, 25, 9, 1, 126, 64, 71, 77, 70, 94, 90, 9, 103, 125, 9, 24, 25, 7, 25, 18, 9, 126, 64, 71, 31, 29, 18, 9, 81, 31, 29, 0, 9, 104, 89, 89, 69, 76, 126, 76, 75, 98, 64, 93, 6, 28, 26, 30, 7, 26, 31, 9, 1, 98, 97, 125, 100, 101, 5, 9, 69, 64, 66, 76, 9, 110, 76, 74, 66, 70, 0, 9, 106, 65, 91, 70, 68, 76, 6, 24, 27, 25, 7, 25, 7, 25, 7, 25, 9, 122, 72, 79, 72, 91, 64, 6, 28, 26, 30, 7, 26, 31, 14, 0, 18 }, 41) + _0x4cc8c16a._0xd104ebf8(new byte[30] { 128, 129, 130, 204, 148, 150, 139, 144, 139, 200, 195, 148, 136, 133, 144, 130, 139, 150, 137, 195, 200, 195, 179, 141, 138, 215, 214, 195, 205, 223 }, 228) + _0x4cc8c16a._0xd104ebf8(new byte[34] { 148, 149, 150, 216, 128, 130, 159, 132, 159, 220, 215, 134, 149, 158, 148, 159, 130, 215, 220, 215, 183, 159, 159, 151, 156, 149, 208, 185, 158, 147, 222, 215, 217, 203 }, 240) + _0x4cc8c16a._0xd104ebf8(new byte[30] { 196, 197, 198, 136, 208, 210, 207, 212, 207, 140, 135, 205, 193, 216, 244, 207, 213, 195, 200, 240, 207, 201, 206, 212, 211, 135, 140, 144, 137, 155 }, 160) + _0x4cc8c16a._0xd104ebf8(new byte[449] { 189, 187, 176, 178, 191, 168, 187, 233, 188, 168, 173, 244, 178, 171, 187, 168, 167, 173, 186, 243, 146, 178, 171, 187, 168, 167, 173, 243, 238, 138, 161, 187, 166, 164, 160, 188, 164, 238, 229, 191, 172, 187, 186, 160, 166, 167, 243, 238, 248, 251, 249, 238, 180, 229, 178, 171, 187, 168, 167, 173, 243, 238, 142, 166, 166, 174, 165, 172, 233, 138, 161, 187, 166, 164, 172, 238, 229, 191, 172, 187, 186, 160, 166, 167, 243, 238, 248, 251, 249, 238, 180, 229, 178, 171, 187, 168, 167, 173, 243, 238, 135, 166, 189, 244, 136, 246, 139, 187, 168, 167, 173, 238, 229, 191, 172, 187, 186, 160, 166, 167, 243, 238, 251, 253, 238, 180, 148, 229, 164, 166, 171, 160, 165, 172, 243, 175, 168, 165, 186, 172, 229, 185, 165, 168, 189, 175, 166, 187, 164, 243, 238, 158, 160, 167, 173, 166, 190, 186, 238, 229, 174, 172, 189, 129, 160, 174, 161, 140, 167, 189, 187, 166, 185, 176, 159, 168, 165, 188, 172, 186, 243, 175, 188, 167, 170, 189, 160, 166, 167, 225, 224, 178, 187, 172, 189, 188, 187, 167, 233, 153, 187, 166, 164, 160, 186, 172, 231, 187, 172, 186, 166, 165, 191, 172, 225, 178, 168, 187, 170, 161, 160, 189, 172, 170, 189, 188, 187, 172, 243, 238, 177, 241, 255, 238, 229, 171, 160, 189, 167, 172, 186, 186, 243, 238, 255, 253, 238, 229, 164, 166, 171, 160, 165, 172, 243, 175, 168, 165, 186, 172, 229, 164, 166, 173, 172, 165, 243, 238, 238, 229, 185, 165, 168, 189, 175, 166, 187, 164, 243, 238, 158, 160, 167, 173, 166, 190, 186, 238, 229, 185, 165, 168, 189, 175, 166, 187, 164, 159, 172, 187, 186, 160, 166, 167, 243, 238, 248, 252, 231, 249, 231, 249, 238, 229, 188, 168, 143, 188, 165, 165, 159, 172, 187, 186, 160, 166, 167, 243, 238, 248, 251, 249, 231, 249, 231, 249, 231, 249, 238, 180, 224, 242, 180, 180, 242, 134, 171, 163, 172, 170, 189, 231, 173, 172, 175, 160, 167, 172, 153, 187, 166, 185, 172, 187, 189, 176, 225, 185, 187, 166, 189, 166, 229, 238, 188, 186, 172, 187, 136, 174, 172, 167, 189, 141, 168, 189, 168, 238, 229, 178, 174, 172, 189, 243, 175, 188, 167, 170, 189, 160, 166, 167, 225, 224, 178, 187, 172, 189, 188, 187, 167, 233, 188, 168, 173, 242, 180, 229, 170, 166, 167, 175, 160, 174, 188, 187, 168, 171, 165, 172, 243, 189, 187, 188, 172, 180, 224, 242, 180, 170, 168, 189, 170, 161, 225, 172, 224, 178, 180 }, 201) + _0x4cc8c16a._0xd104ebf8(new byte[112] { 214, 215, 212, 154, 193, 209, 192, 215, 215, 220, 158, 149, 197, 219, 214, 198, 218, 149, 158, 131, 139, 128, 130, 155, 137, 214, 215, 212, 154, 193, 209, 192, 215, 215, 220, 158, 149, 218, 215, 219, 213, 218, 198, 149, 158, 131, 130, 138, 130, 155, 137, 214, 215, 212, 154, 193, 209, 192, 215, 215, 220, 158, 149, 211, 196, 211, 219, 222, 229, 219, 214, 198, 218, 149, 158, 131, 139, 128, 130, 155, 137, 214, 215, 212, 154, 193, 209, 192, 215, 215, 220, 158, 149, 211, 196, 211, 219, 222, 250, 215, 219, 213, 218, 198, 149, 158, 131, 130, 134, 130, 155, 137 }, 178) + _0x4cc8c16a._0xd104ebf8(new byte[45] { 7, 1, 10, 8, 4, 26, 29, 23, 28, 4, 93, 28, 29, 7, 28, 6, 16, 27, 0, 7, 18, 1, 7, 78, 6, 29, 23, 22, 21, 26, 29, 22, 23, 72, 14, 16, 18, 7, 16, 27, 91, 22, 90, 8, 14 }, 115) + _0x4cc8c16a._0xd104ebf8(new byte[721] { 107, 109, 102, 100, 105, 126, 109, 63, 112, 109, 118, 120, 34, 104, 118, 113, 123, 112, 104, 49, 114, 126, 107, 124, 119, 82, 122, 123, 118, 126, 49, 125, 118, 113, 123, 55, 104, 118, 113, 123, 112, 104, 54, 36, 104, 118, 113, 123, 112, 104, 49, 114, 126, 107, 124, 119, 82, 122, 123, 118, 126, 34, 121, 106, 113, 124, 107, 118, 112, 113, 55, 110, 54, 100, 105, 126, 109, 63, 108, 34, 76, 107, 109, 118, 113, 120, 55, 110, 54, 49, 107, 112, 83, 112, 104, 122, 109, 92, 126, 108, 122, 55, 54, 36, 118, 121, 55, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 111, 112, 118, 113, 107, 122, 109, 37, 63, 124, 112, 126, 109, 108, 122, 56, 54, 33, 34, 47, 99, 99, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 119, 112, 105, 122, 109, 37, 63, 113, 112, 113, 122, 56, 54, 33, 34, 47, 99, 99, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 114, 126, 103, 50, 104, 118, 123, 107, 119, 56, 54, 33, 34, 47, 99, 99, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 114, 126, 103, 50, 123, 122, 105, 118, 124, 122, 50, 104, 118, 123, 107, 119, 56, 54, 33, 34, 47, 54, 109, 122, 107, 106, 109, 113, 63, 100, 114, 126, 107, 124, 119, 122, 108, 37, 121, 126, 115, 108, 122, 51, 114, 122, 123, 118, 126, 37, 110, 51, 112, 113, 124, 119, 126, 113, 120, 122, 37, 113, 106, 115, 115, 51, 126, 123, 123, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 109, 122, 114, 112, 105, 122, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 126, 123, 123, 90, 105, 122, 113, 107, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 109, 122, 114, 112, 105, 122, 90, 105, 122, 113, 107, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 123, 118, 108, 111, 126, 107, 124, 119, 90, 105, 122, 113, 107, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 109, 122, 107, 106, 109, 113, 63, 121, 126, 115, 108, 122, 36, 98, 98, 36, 118, 121, 55, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 111, 112, 118, 113, 107, 122, 109, 37, 63, 121, 118, 113, 122, 56, 54, 33, 34, 47, 99, 99, 108, 49, 118, 113, 123, 122, 103, 80, 121, 55, 56, 119, 112, 105, 122, 109, 37, 63, 119, 112, 105, 122, 109, 56, 54, 33, 34, 47, 54, 109, 122, 107, 106, 109, 113, 63, 100, 114, 126, 107, 124, 119, 122, 108, 37, 107, 109, 106, 122, 51, 114, 122, 123, 118, 126, 37, 110, 51, 112, 113, 124, 119, 126, 113, 120, 122, 37, 113, 106, 115, 115, 51, 126, 123, 123, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 109, 122, 114, 112, 105, 122, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 126, 123, 123, 90, 105, 122, 113, 107, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 109, 122, 114, 112, 105, 122, 90, 105, 122, 113, 107, 83, 118, 108, 107, 122, 113, 122, 109, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 98, 51, 123, 118, 108, 111, 126, 107, 124, 119, 90, 105, 122, 113, 107, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 109, 122, 107, 106, 109, 113, 63, 121, 126, 115, 108, 122, 36, 98, 98, 36, 109, 122, 107, 106, 109, 113, 63, 112, 109, 118, 120, 55, 110, 54, 36, 98, 36, 98, 124, 126, 107, 124, 119, 55, 122, 54, 100, 98 }, 31) + _0x4cc8c16a._0xd104ebf8(new byte[5] { 132, 208, 209, 208, 194 }, 249);
    }

    private void _0xb127d282()
    {
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[21] { 238, 199, 212, 194, 209, 199, 212, 195, 134, 196, 199, 197, 205, 134, 214, 212, 195, 213, 213, 195, 194 }, 166));
        if (Time.frameCount == _0x1944e310)
            return;
        _0x1944e310 = Time.frameCount;
        if (_0x8d8c500a())
            return;
        _0x7adae379();
    }

    // WEB VIEW LOGIC END
    internal void _0xd26313d5()
    {
        // Ensure channel exists (safe to call multiple times)
        var _0xf8cd069a = new AndroidNotificationChannel
        {
            Id = _0x4cc8c16a._0xd104ebf8(new byte[15] { 145, 144, 147, 148, 128, 153, 129, 170, 150, 157, 148, 155, 155, 144, 153 }, 245),
            Name = _0x4cc8c16a._0xd104ebf8(new byte[15] { 162, 131, 128, 135, 147, 138, 146, 198, 165, 142, 135, 136, 136, 131, 138 }, 230),
            Importance = Importance.High,
            Description = _0x4cc8c16a._0xd104ebf8(new byte[21] { 18, 48, 59, 48, 39, 52, 57, 117, 59, 58, 33, 60, 51, 60, 54, 52, 33, 60, 58, 59, 38 }, 85)
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_0xf8cd069a);
        // Build notification
        var _0x4779b99b = new AndroidNotification
        {
            Title = _0xa86a937e[UnityEngine.Random.Range(0, _0xa86a937e.Length)],
            Text = _0x4cc8c16a._0xd104ebf8(new byte[21] { 154, 169, 190, 251, 162, 180, 174, 251, 168, 174, 169, 190, 251, 175, 180, 251, 190, 163, 178, 175, 228 }, 219),
            FireTime = System.DateTime.Now
        };
        // Send immediately
        AndroidNotificationCenter.SendNotification(_0x4779b99b, _0x4cc8c16a._0xd104ebf8(new byte[15] { 98, 99, 96, 103, 115, 106, 114, 89, 101, 110, 103, 104, 104, 99, 106 }, 6));
    }

    /* ============================= */
    /* ENCRYPT / DECRYPT             */
    /* ============================= */
    private string _0x27c044df(string _0xf60b541f, string _0x0d80f8fe)
    {
        try
        {
            using var _0x9d79fdd6 = Aes.Create();
            _0x9d79fdd6.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x0d80f8fe));
            _0x9d79fdd6.GenerateIV();
            using var _0xb675d647 = new MemoryStream();
            _0xb675d647.Write(_0x9d79fdd6.IV, 0, _0x9d79fdd6.IV.Length);
            using (var _0x6e0d46eb = new CryptoStream(_0xb675d647, _0x9d79fdd6.CreateEncryptor(), CryptoStreamMode.Write))
            {
                var _0x23fe84a4 = Encoding.UTF8.GetBytes(_0xf60b541f);
                _0x6e0d46eb.Write(_0x23fe84a4, 0, _0x23fe84a4.Length);
                _0x6e0d46eb.FlushFinalBlock();
            }

            return Convert.ToBase64String(_0xb675d647.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private bool _0x6d968e62 = false;
    internal string _0x38ac891d(string _0xd63a2d04)
    {
        int _0x713e92ec = _0xd63a2d04.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[3] { 147, 158, 199 }, 250), StringComparison.OrdinalIgnoreCase);
        if (_0x713e92ec < 0)
            return null;
        string _0xd872fec2 = _0xd63a2d04.Substring(_0x713e92ec + 3);
        int _0xba0c0e48 = _0xd872fec2.IndexOf('&');
        return _0xba0c0e48 >= 0 ? _0xd872fec2.Substring(0, _0xba0c0e48) : _0xd872fec2;
    }

    private void _0xf425a05a()
    {
        using (var _0x60abbfef = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 147, 159, 157, 222, 133, 158, 153, 132, 137, 195, 148, 222, 128, 156, 145, 137, 149, 130, 222, 165, 158, 153, 132, 137, 160, 156, 145, 137, 149, 130 }, 240)))
        using (var _0xc97d4ebb = _0x60abbfef.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 197, 211, 212, 212, 195, 200, 210, 231, 197, 210, 207, 208, 207, 210, 223 }, 166)))
        using (var _0xb04bff6d = _0xc97d4ebb.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[9] { 11, 9, 24, 37, 2, 24, 9, 2, 24 }, 108)))
        {
            if (_0xb04bff6d == null)
                return;
            using (var _0xb9846dfb = _0xb04bff6d.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[9] { 133, 135, 150, 167, 154, 150, 144, 131, 145 }, 226)))
            {
                if (_0xb9846dfb == null)
                    return;
                using (var _0x7c0f0b7b = new AndroidJavaObject(_0x4cc8c16a._0xd104ebf8(new byte[19] { 72, 85, 64, 9, 77, 84, 72, 73, 9, 109, 116, 104, 105, 104, 69, 77, 66, 68, 83 }, 39)))
                using (var _0xec95fe6c = _0xb9846dfb.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[6] { 119, 121, 101, 79, 121, 104 }, 28)))
                using (var _0x20336451 = _0xec95fe6c.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 94, 67, 82, 69, 86, 67, 88, 69 }, 55)))
                {
                    while (_0x20336451.Call<bool>(_0x4cc8c16a._0xd104ebf8(new byte[7] { 116, 125, 111, 82, 121, 100, 104 }, 28)))
                    {
                        string _0x35ab0338 = _0x20336451.Call<string>(_0x4cc8c16a._0xd104ebf8(new byte[4] { 169, 162, 191, 179 }, 199));
                        using (var _0x46127549 = _0xb9846dfb.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[3] { 206, 204, 221 }, 169), _0x35ab0338))
                        {
                            _0x7c0f0b7b.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[3] { 210, 215, 214 }, 162), _0x35ab0338, _0x46127549);
                        }
                    }

                    string _0x327cfb87 = _0x7c0f0b7b.Call<string>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 96, 123, 71, 96, 102, 125, 122, 115 }, 20));
                    if (!string.IsNullOrEmpty(_0x327cfb87))
                    {
                        _0xc1009b3f(_0x327cfb87);
                    }
                }
            }
        }
    }

    private void _0x992e6e67()
    {
        _0xd585aacf = true;
        if (_0x73590a68 != null)
            _0x73590a68.SetUserAgent(_0xaf793820());
    }

    private bool _0xc6b8ec3e = false;
    private IEnumerator RequestAndroidPermissionIfNeeded(string _0x434edf26)
    {
        if (Permission.HasUserAuthorizedPermission(_0x434edf26))
            yield break;
        bool _0xba31900c = false;
        var _0x420e8ae7 = new PermissionCallbacks();
        _0x420e8ae7.PermissionGranted += _0x9ccbcd74 => _0xba31900c = true;
        _0x420e8ae7.PermissionDenied += _0x9ccbcd74 => _0xba31900c = true;
        Permission.RequestUserPermission(_0x434edf26, _0x420e8ae7);
        yield return new WaitUntil(() => _0xba31900c);
    }

    private IEnumerator _0xd60fdb6a()
    {
        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[26] { 190, 177, 128, 150, 145, 184, 197, 172, 139, 140, 145, 140, 132, 137, 140, 159, 128, 183, 128, 131, 131, 128, 151, 128, 151, 197 }, 229));
            }
#endif
        }

        bool _0xc8f24e27 = false;
        InstallReferrer.GetReferrer((_0x56dc3ea6) =>
        {
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[24] { 79, 64, 113, 103, 96, 52, 70, 113, 114, 113, 102, 102, 113, 102, 73, 52, 115, 113, 96, 52, 246, 146, 134, 52 }, 20) + _0x2fb9022f);
            if (_0x56dc3ea6.IsSuccess)
            {
                _0x2fb9022f = _0x56dc3ea6.InstallReferrer ?? "";
                {
#if B_LOGS
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[28] { 151, 152, 169, 191, 184, 236, 158, 169, 170, 169, 190, 190, 169, 190, 145, 236, 159, 185, 175, 175, 169, 191, 191, 236, 46, 74, 94, 236 }, 204) + _0x2fb9022f);
#endif
                }
            }
            else
            {
                {
#if B_LOGS
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[27] { 127, 112, 65, 87, 80, 4, 118, 65, 66, 65, 86, 86, 65, 86, 121, 4, 98, 69, 77, 72, 65, 64, 4, 198, 162, 182, 4 }, 36) + _0x56dc3ea6);
#endif
                }

                _0x2fb9022f = "";
            }

            _0x29c47e3d = true;
        });
        StartCoroutine(_0xed7e3dd8(2f));
        yield return new WaitUntil(() => _0x29c47e3d);
        {
#if B_LOGS
            Debug.Log($"[Test] check google atr {_0x2fb9022f}");
#endif
        }

        bool _0xc1e9b5dc = _0x2fb9022f.Contains(_0x4cc8c16a._0xd104ebf8(new byte[6] { 112, 116, 123, 126, 115, 42 }, 23));
        _0xc8f24e27 = _0xc1e9b5dc || _0x2fb9022f.Contains(_0x4cc8c16a._0xd104ebf8(new byte[18] { 63, 46, 46, 45, 112, 55, 48, 45, 42, 63, 57, 44, 63, 51, 112, 61, 49, 51 }, 94)) || _0x2fb9022f.Contains(_0x4cc8c16a._0xd104ebf8(new byte[17] { 145, 128, 128, 131, 222, 150, 145, 147, 149, 146, 159, 159, 155, 222, 147, 159, 157 }, 240));
        _0xbdd86da9 = _0xc1e9b5dc ? "" : (_0xc8f24e27 ? "" : _0xbdd86da9);
        _0xbdd86da9 = _0xbdd86da9 ?? "";
        _0x4890d725 = _0x4890d725 ?? "";
        {
#if B_LOGS
            Debug.Log($"[Test] oneLinkData (FB): {_0xbdd86da9}");
#endif
        }
    }

    // PART 3
    private string _0x705b7ce1()
    {
        try
        {
            var _0x2e5d319d = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 39, 43, 41, 106, 49, 42, 45, 48, 61, 119, 32, 106, 52, 40, 37, 61, 33, 54, 106, 17, 42, 45, 48, 61, 20, 40, 37, 61, 33, 54 }, 68));
            var _0x0be42dca = _0x2e5d319d.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 183, 161, 166, 166, 177, 186, 160, 149, 183, 160, 189, 162, 189, 160, 173 }, 212));
            var _0xc5e65a88 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[57] { 17, 29, 31, 92, 21, 29, 29, 21, 30, 23, 92, 19, 28, 22, 0, 29, 27, 22, 92, 21, 31, 1, 92, 19, 22, 1, 92, 27, 22, 23, 28, 6, 27, 20, 27, 23, 0, 92, 51, 22, 4, 23, 0, 6, 27, 1, 27, 28, 21, 59, 22, 49, 30, 27, 23, 28, 6 }, 114));
            var _0x5912f5d4 = _0xc5e65a88.CallStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[20] { 122, 120, 105, 92, 121, 107, 120, 111, 105, 116, 110, 116, 115, 122, 84, 121, 84, 115, 123, 114 }, 29), _0x0be42dca);
            var _0xd0b9b691 = _0x5912f5d4.Call<string>(_0x4cc8c16a._0xd104ebf8(new byte[5] { 49, 51, 34, 31, 50 }, 86));
            {
#if B_LOGS
                Debug.Log($"[Test] Google Advertiding Id (ad id): {_0xd0b9b691}");
#endif
            }

            return string.IsNullOrEmpty(_0xd0b9b691) ? "" : _0xd0b9b691;
        }
        catch
        {
            return "";
        }
    }

    private bool _0x0e259480(string _0x803cce8e)
    {
        try
        {
            using (var _0xc9bcb259 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 15, 3, 1, 66, 25, 2, 5, 24, 21, 95, 8, 66, 28, 0, 13, 21, 9, 30, 66, 57, 2, 5, 24, 21, 60, 0, 13, 21, 9, 30 }, 108)))
            using (var _0x48114378 = _0xc9bcb259.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 102, 112, 119, 119, 96, 107, 113, 68, 102, 113, 108, 115, 108, 113, 124 }, 5)))
            using (var _0x1dd725bc = _0x48114378.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[17] { 19, 17, 0, 36, 21, 23, 31, 21, 19, 17, 57, 21, 26, 21, 19, 17, 6 }, 116)))
            using (var _0xa5b6bc9e = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[22] { 137, 134, 140, 154, 135, 129, 140, 198, 139, 135, 134, 156, 141, 134, 156, 198, 161, 134, 156, 141, 134, 156 }, 232)))
            using (var _0x65117bb7 = _0xa5b6bc9e.CallStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 178, 163, 176, 177, 167, 151, 176, 171 }, 194), _0x803cce8e, 1))
            {
                string _0x23aac06f = _0x65117bb7.Call<string>(_0x4cc8c16a._0xd104ebf8(new byte[14] { 116, 118, 103, 64, 103, 97, 122, 125, 116, 86, 107, 103, 97, 114 }, 19), _0x4cc8c16a._0xd104ebf8(new byte[20] { 72, 88, 69, 93, 89, 79, 88, 117, 76, 75, 70, 70, 72, 75, 73, 65, 117, 95, 88, 70 }, 42));
                string _0x25489a51 = _0x65117bb7.Call<string>(_0x4cc8c16a._0xd104ebf8(new byte[10] { 159, 157, 140, 168, 153, 155, 147, 153, 159, 157 }, 248));
                _0x65117bb7.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[11] { 98, 103, 103, 64, 98, 119, 102, 100, 108, 113, 122 }, 3), _0x4cc8c16a._0xd104ebf8(new byte[33] { 206, 193, 203, 221, 192, 198, 203, 129, 198, 193, 219, 202, 193, 219, 129, 204, 206, 219, 202, 200, 192, 221, 214, 129, 237, 253, 224, 248, 252, 238, 237, 227, 234 }, 175));
                _0x65117bb7.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[11] { 16, 7, 15, 13, 20, 7, 39, 26, 22, 16, 3 }, 98), _0x4cc8c16a._0xd104ebf8(new byte[20] { 22, 6, 27, 3, 7, 17, 6, 43, 18, 21, 24, 24, 22, 21, 23, 31, 43, 1, 6, 24 }, 116));
                if (_0x65117bb7.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 136, 159, 137, 149, 150, 140, 159, 187, 153, 142, 147, 140, 147, 142, 131 }, 250), _0x1dd725bc) != null)
                {
                    WLog(_0x4cc8c16a._0xd104ebf8(new byte[24] { 117, 94, 68, 89, 91, 83, 122, 95, 93, 83, 22, 89, 70, 83, 88, 22, 95, 88, 66, 83, 88, 66, 12, 22 }, 54) + _0x803cce8e);
                    _0x65117bb7.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 234, 239, 239, 205, 231, 234, 236, 248 }, 139), 0x10000000);
                    _0x48114378.Call(_0x4cc8c16a._0xd104ebf8(new byte[13] { 125, 122, 111, 124, 122, 79, 109, 122, 103, 120, 103, 122, 119 }, 14), _0x65117bb7);
                    return true;
                }

                if (_0x61b847cc(_0x25489a51))
                    return true;
                if (!string.IsNullOrEmpty(_0x23aac06f))
                {
                    WLog(_0x4cc8c16a._0xd104ebf8(new byte[28] { 238, 197, 223, 194, 192, 200, 225, 196, 198, 200, 141, 196, 195, 217, 200, 195, 217, 141, 203, 204, 193, 193, 207, 204, 206, 198, 151, 141 }, 173) + _0x23aac06f);
                    if (_0x856b0a46(_0x23aac06f))
                        return _0x79b00872(_0x23aac06f, _0x25489a51);
                    return _0xd783c68d(_0x23aac06f);
                }

                WLog(_0x4cc8c16a._0xd104ebf8(new byte[30] { 151, 188, 166, 187, 185, 177, 152, 189, 191, 177, 244, 189, 186, 160, 177, 186, 160, 244, 186, 187, 244, 188, 181, 186, 176, 184, 177, 166, 238, 244 }, 212) + _0x803cce8e);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[26] { 155, 176, 170, 183, 181, 189, 148, 177, 179, 189, 248, 177, 182, 172, 189, 182, 172, 248, 190, 185, 177, 180, 189, 188, 226, 248 }, 216) + e.Message);
            return true;
        }
    }

    private bool _0xc971c5ef = false;
    internal bool isApplicationPause = false;
    private async Task _0x012b5e21()
    {
        if (await _0x6619fe36())
            return;
        if (await _0xda96cae9())
            return;
        if (await _0x6cd4a711())
            return;
        _0xe5bf45fc();
        await _0xccd972a5(_0xd60fdb6a());
        _0x9669aa62 = await _0x4a917de4();
        await _0x62a6c5b7();
    }

    private bool _0x2d86fb52 = false;
    private string _0x15273b99 = "";
    private ApplicationInstallMode _0x982589ad = ApplicationInstallMode.Unknown;
    private void StopCurrentFailedLoad(UniWebView _0x149319ee)
    {
        _0x553bfe61(false);
        if (_0x149319ee == null)
            return;
        _0x149319ee.Stop();
        if (_0x149319ee.CanGoBack)
            _0x149319ee.GoBack();
    }

    private string _0xf94fd9be()
    {
        string _0xe8e5ddef = _0xaf793820();
        if (string.IsNullOrEmpty(_0xe8e5ddef))
            return _0x4cc8c16a._0xd104ebf8(new byte[7] { 86, 79, 73, 68, 0, 16, 27 }, 32);
        string _0x68d7b21b = _0xe8e5ddef.Replace(_0x4cc8c16a._0xd104ebf8(new byte[1] { 76 }, 16), _0x4cc8c16a._0xd104ebf8(new byte[2] { 60, 60 }, 96)).Replace(_0x4cc8c16a._0xd104ebf8(new byte[1] { 30 }, 57), _0x4cc8c16a._0xd104ebf8(new byte[2] { 185, 194 }, 229));
        var _0xeeb4491f = Regex.Match(_0xe8e5ddef, _0x4cc8c16a._0xd104ebf8(new byte[12] { 154, 177, 171, 182, 180, 188, 246, 241, 133, 189, 242, 240 }, 217));
        string _0xf0655a68 = _0xeeb4491f.Success ? _0xeeb4491f.Groups[1].Value : _0x4cc8c16a._0xd104ebf8(new byte[3] { 224, 227, 225 }, 209);
        return _0x4cc8c16a._0xd104ebf8(new byte[12] { 231, 169, 186, 161, 172, 187, 166, 160, 161, 231, 230, 180 }, 207) + _0x4cc8c16a._0xd104ebf8(new byte[8] { 131, 148, 135, 213, 128, 148, 200, 210 }, 245) + _0x68d7b21b + _0x4cc8c16a._0xd104ebf8(new byte[2] { 206, 210 }, 233) + _0x4cc8c16a._0xd104ebf8(new byte[30] { 182, 161, 178, 224, 176, 178, 175, 180, 175, 253, 142, 161, 182, 169, 167, 161, 180, 175, 178, 238, 176, 178, 175, 180, 175, 180, 185, 176, 165, 251 }, 192) + _0x4cc8c16a._0xd104ebf8(new byte[121] { 64, 83, 72, 69, 82, 79, 73, 72, 6, 66, 67, 64, 14, 73, 68, 76, 10, 77, 67, 95, 10, 80, 71, 74, 15, 93, 82, 84, 95, 93, 105, 68, 76, 67, 69, 82, 8, 66, 67, 64, 79, 72, 67, 118, 84, 73, 86, 67, 84, 82, 95, 14, 73, 68, 76, 10, 77, 67, 95, 10, 93, 65, 67, 82, 28, 64, 83, 72, 69, 82, 79, 73, 72, 14, 15, 93, 84, 67, 82, 83, 84, 72, 6, 80, 71, 74, 29, 91, 10, 69, 73, 72, 64, 79, 65, 83, 84, 71, 68, 74, 67, 28, 82, 84, 83, 67, 91, 15, 29, 91, 69, 71, 82, 69, 78, 14, 67, 15, 93, 91, 91 }, 38) + _0x4cc8c16a._0xd104ebf8(new byte[26] { 26, 27, 24, 86, 14, 12, 17, 10, 17, 82, 89, 11, 13, 27, 12, 63, 25, 27, 16, 10, 89, 82, 11, 31, 87, 69 }, 126) + _0x4cc8c16a._0xd104ebf8(new byte[52] { 238, 239, 236, 162, 250, 248, 229, 254, 229, 166, 173, 235, 250, 250, 220, 239, 248, 249, 227, 229, 228, 173, 166, 255, 235, 164, 248, 239, 250, 230, 235, 233, 239, 162, 165, 212, 199, 229, 240, 227, 230, 230, 235, 214, 165, 165, 166, 173, 173, 163, 163, 177 }, 138) + _0x4cc8c16a._0xd104ebf8(new byte[37] { 115, 114, 113, 63, 103, 101, 120, 99, 120, 59, 48, 103, 123, 118, 99, 113, 120, 101, 122, 48, 59, 48, 91, 126, 121, 98, 111, 55, 118, 101, 122, 97, 47, 123, 48, 62, 44 }, 23) + _0x4cc8c16a._0xd104ebf8(new byte[34] { 19, 18, 17, 95, 7, 5, 24, 3, 24, 91, 80, 1, 18, 25, 19, 24, 5, 80, 91, 80, 48, 24, 24, 16, 27, 18, 87, 62, 25, 20, 89, 80, 94, 76 }, 119) + _0x4cc8c16a._0xd104ebf8(new byte[30] { 71, 70, 69, 11, 83, 81, 76, 87, 76, 15, 4, 78, 66, 91, 119, 76, 86, 64, 75, 115, 76, 74, 77, 87, 80, 4, 15, 22, 10, 24 }, 35) + _0x4cc8c16a._0xd104ebf8(new byte[48] { 210, 212, 223, 221, 208, 199, 212, 134, 211, 199, 194, 155, 221, 196, 212, 199, 200, 194, 213, 156, 253, 221, 196, 212, 199, 200, 194, 156, 129, 229, 206, 212, 201, 203, 207, 211, 203, 129, 138, 208, 195, 212, 213, 207, 201, 200, 156, 129 }, 166) + _0xf0655a68 + _0x4cc8c16a._0xd104ebf8(new byte[35] { 105, 51, 98, 53, 44, 60, 47, 32, 42, 116, 105, 9, 33, 33, 41, 34, 43, 110, 13, 38, 60, 33, 35, 43, 105, 98, 56, 43, 60, 61, 39, 33, 32, 116, 105 }, 78) + _0xf0655a68 + _0x4cc8c16a._0xd104ebf8(new byte[238] { 127, 37, 116, 35, 58, 42, 57, 54, 60, 98, 127, 22, 55, 44, 101, 25, 103, 26, 42, 57, 54, 60, 127, 116, 46, 61, 42, 43, 49, 55, 54, 98, 127, 106, 108, 127, 37, 5, 116, 53, 55, 58, 49, 52, 61, 98, 44, 42, 45, 61, 116, 40, 52, 57, 44, 62, 55, 42, 53, 98, 127, 25, 54, 60, 42, 55, 49, 60, 127, 116, 63, 61, 44, 16, 49, 63, 48, 29, 54, 44, 42, 55, 40, 33, 14, 57, 52, 45, 61, 43, 98, 62, 45, 54, 59, 44, 49, 55, 54, 112, 113, 35, 42, 61, 44, 45, 42, 54, 120, 8, 42, 55, 53, 49, 43, 61, 118, 42, 61, 43, 55, 52, 46, 61, 112, 35, 57, 42, 59, 48, 49, 44, 61, 59, 44, 45, 42, 61, 98, 127, 57, 42, 53, 127, 116, 58, 49, 44, 54, 61, 43, 43, 98, 127, 110, 108, 127, 116, 53, 55, 58, 49, 52, 61, 98, 44, 42, 45, 61, 116, 53, 55, 60, 61, 52, 98, 127, 127, 116, 40, 52, 57, 44, 62, 55, 42, 53, 98, 127, 25, 54, 60, 42, 55, 49, 60, 127, 116, 40, 52, 57, 44, 62, 55, 42, 53, 14, 61, 42, 43, 49, 55, 54, 98, 127, 105, 108, 118, 104, 118, 104, 127, 116, 45, 57, 30, 45, 52, 52, 14, 61, 42, 43, 49, 55, 54, 98, 127 }, 88) + _0xf0655a68 + _0x4cc8c16a._0xd104ebf8(new byte[117] { 154, 132, 154, 132, 154, 132, 147, 201, 157, 143, 201, 201, 143, 251, 214, 222, 209, 215, 192, 154, 208, 209, 210, 221, 218, 209, 228, 198, 219, 196, 209, 198, 192, 205, 156, 196, 198, 219, 192, 219, 152, 147, 193, 199, 209, 198, 245, 211, 209, 218, 192, 240, 213, 192, 213, 147, 152, 207, 211, 209, 192, 142, 210, 193, 218, 215, 192, 221, 219, 218, 156, 157, 207, 198, 209, 192, 193, 198, 218, 148, 193, 213, 208, 143, 201, 152, 215, 219, 218, 210, 221, 211, 193, 198, 213, 214, 216, 209, 142, 192, 198, 193, 209, 201, 157, 143, 201, 215, 213, 192, 215, 220, 156, 209, 157, 207, 201 }, 180) + _0x4cc8c16a._0xd104ebf8(new byte[5] { 253, 169, 168, 169, 187 }, 128);
    }

    private string _0xb3211487 = "";
    private bool _0xe291ccb3()
    {
        var _0x207f5227 = Keyboard.current;
        return _0x207f5227 != null && _0x207f5227.escapeKey.wasPressedThisFrame;
    }

    private void _0xb8a56f31(string _0x244da1dd)
    {
        _0xf425a05a();
        StartCoroutine(_0x8fb7588e(_0x244da1dd));
    }

    private void _0x7adae379()
    {
        if (_0xb43ed52d)
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[18] { 236, 209, 192, 221, 137, 200, 197, 219, 204, 200, 205, 208, 137, 218, 193, 198, 222, 199 }, 169));
            return;
        }

        _0x553bfe61(false);
        WLog(_0x4cc8c16a._0xd104ebf8(new byte[46] { 92, 112, 120, 127, 49, 70, 116, 115, 71, 120, 116, 102, 49, 65, 100, 98, 121, 49, 95, 126, 101, 120, 119, 120, 114, 112, 101, 120, 126, 127, 49, 57, 121, 112, 99, 117, 102, 112, 99, 116, 49, 115, 112, 114, 122, 56 }, 17));
        ++_0xfd705bf6;
        _0xd26313d5();
        if (_0xfd705bf6 <= 1)
            return;
        if (_0x884f01ce())
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[37] { 115, 78, 95, 66, 22, 69, 93, 95, 70, 70, 83, 82, 22, 27, 8, 22, 70, 89, 70, 67, 70, 69, 22, 69, 66, 95, 90, 90, 22, 89, 70, 83, 88, 83, 82, 12, 22 }, 54) + _0xa9e558ff.Count);
            return;
        }

        Application.Quit();
    }

    private void WLog(string _0x0a9c1992)
    {
#if B_LOGS
        {
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[7] { 234, 229, 212, 194, 197, 236, 145 }, 177) + _0x0a9c1992);
        }
#endif
    }

    private void _0x3cc020cd(string _0x1a36aa79)
    {
        bool _0x6a8617af = !string.IsNullOrEmpty(_0x1a36aa79);
        if (_0x6a8617af)
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[13] { 3, 12, 61, 43, 44, 5, 120, 11, 48, 55, 47, 98, 120 }, 88) + _0x1a36aa79);
#endif
            }

            _0xb8a56f31(_0x1a36aa79);
            return;
        }
        else
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[39] { 114, 125, 76, 90, 93, 116, 9, 111, 72, 69, 69, 75, 72, 74, 66, 9, 203, 175, 187, 9, 110, 72, 68, 76, 9, 1, 71, 70, 9, 79, 64, 71, 72, 69, 9, 124, 123, 101, 0 }, 41));
#endif
            }

            _0x1964b544();
            return;
        }
    }

    private IEnumerator _0xc6c3e5dc(Dictionary<string, object> _0x1652fbfc)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[30] { 187, 180, 133, 147, 148, 189, 192, 166, 133, 148, 131, 136, 192, 165, 152, 148, 146, 129, 192, 176, 149, 147, 136, 192, 164, 129, 148, 129, 218, 192 }, 224) + string.Join(_0x4cc8c16a._0xd104ebf8(new byte[1] { 219 }, 210), _0x1652fbfc));
#endif
            }
        }

        string _0x1447a478 = "";
        // Primary source: nested JSON under "notificationData"
        if (_0x1652fbfc != null && _0x1652fbfc.TryGetValue(_0x4cc8c16a._0xd104ebf8(new byte[16] { 141, 140, 151, 138, 133, 138, 128, 130, 151, 138, 140, 141, 167, 130, 151, 130 }, 227), out var raw))
        {
            try
            {
                var _0xdceac08f = raw?.ToString();
                var _0x7dec9ab0 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xdceac08f);
                if (_0x7dec9ab0 != null && _0x7dec9ab0.TryGetValue(_0x4cc8c16a._0xd104ebf8(new byte[6] { 229, 243, 248, 242, 255, 242 }, 150), out var val))
                {
                    _0x1447a478 = val?.ToString();
                }
            }
            catch (Exception e)
            {
#if B_LOGS
                Debug.LogError(_0x4cc8c16a._0xd104ebf8(new byte[30] { 165, 170, 155, 141, 138, 222, 174, 139, 141, 150, 163, 222, 180, 173, 177, 176, 222, 142, 159, 140, 141, 155, 222, 155, 140, 140, 145, 140, 196, 222 }, 254) + e);
#endif
            }
        }

        // Fallback: flat structure
        if (string.IsNullOrEmpty(_0x1447a478) && _0x1652fbfc != null && _0x1652fbfc.TryGetValue(_0x4cc8c16a._0xd104ebf8(new byte[6] { 234, 252, 247, 253, 240, 253 }, 153), out var lab))
        {
            _0x1447a478 = lab?.ToString();
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[38] { 160, 175, 158, 136, 143, 219, 171, 142, 136, 147, 166, 219, 189, 158, 143, 152, 147, 158, 159, 219, 136, 158, 149, 159, 146, 159, 219, 157, 137, 148, 150, 219, 145, 136, 148, 149, 193, 219 }, 251) + _0x1447a478);
            }
#endif
        }

        if (string.IsNullOrEmpty(_0x1447a478))
            yield break;
        {
#if B_LOGS
            {
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[38] { 29, 18, 35, 53, 50, 102, 22, 51, 53, 46, 27, 102, 17, 39, 47, 50, 102, 50, 41, 102, 41, 54, 35, 40, 102, 49, 47, 50, 46, 102, 53, 35, 40, 34, 47, 34, 124, 102 }, 70) + _0x1447a478);
            }
#endif
        }

        _0xe2ba7572 = _0x1447a478;
        yield return new WaitUntil(() => _0xaf398bc9);
        var _0xb6bf9a6c = _0x3ba36ed7(2, 100);
        yield return new WaitUntil(() => _0xb6bf9a6c.IsCompleted);
        string _0x7273e6b2 = _0xb6bf9a6c.Result;
        if (!string.IsNullOrEmpty(_0x7273e6b2))
        {
            string _0x9edb2eab = _0x8e0ae47a(_0x7273e6b2, _0x1447a478);
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[33] { 87, 88, 105, 127, 120, 44, 92, 121, 127, 100, 81, 44, 94, 105, 96, 99, 109, 104, 44, 91, 105, 110, 90, 101, 105, 123, 44, 123, 101, 120, 100, 54, 44 }, 12) + _0x9edb2eab);
#endif
            }

            _0x73590a68.Load(_0x9edb2eab);
        }
    }

    private async Task<bool> _0x6cd4a711()
    {
        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[29] { 144, 159, 174, 184, 191, 150, 235, 130, 184, 155, 185, 162, 189, 170, 168, 178, 138, 165, 175, 152, 170, 189, 174, 175, 136, 163, 174, 168, 160 }, 203));
#endif
        }

        string _0xb7ee5ddf = "";
        for (int _0x9ca5c998 = 0; _0x9ca5c998 < 2; _0x9ca5c998++)
        {
            if (await _0x8b33995c(1, 100))
            {
                await _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[7] { 236, 226, 225, 237, 229, 235, 234 }, 142));
                _0x1964b544();
                return true;
            }

            _0xb7ee5ddf = await _0x3ba36ed7(1, 100);
            if (!string.IsNullOrEmpty(_0xb7ee5ddf))
                break;
        }

        try
        {
            if (!string.IsNullOrEmpty(_0xb7ee5ddf))
            {
                if (!string.IsNullOrEmpty(_0xe2ba7572))
                {
                    _0xb7ee5ddf = _0x8e0ae47a(_0xb7ee5ddf, _0xe2ba7572);
                    {
#if B_LOGS
                        Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[53] { 84, 91, 106, 124, 123, 82, 47, 76, 110, 108, 103, 106, 107, 47, 105, 102, 97, 110, 99, 90, 125, 99, 47, 120, 102, 123, 103, 47, 124, 106, 97, 107, 102, 107, 47, 237, 137, 157, 47, 124, 103, 96, 120, 47, 88, 106, 109, 89, 102, 106, 120, 53, 47 }, 15) + _0xb7ee5ddf);
#endif
                    }
                }
                else
                {
                    {
#if B_LOGS
                        Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[39] { 180, 187, 138, 156, 155, 178, 207, 172, 142, 140, 135, 138, 139, 207, 137, 134, 129, 142, 131, 186, 157, 131, 207, 13, 105, 125, 207, 156, 135, 128, 152, 207, 184, 138, 141, 185, 134, 138, 152 }, 239));
#endif
                    }
                }

                _0xc6b8ec3e = true;
                _0xb8a56f31(_0xb7ee5ddf);
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[44] { 24, 23, 38, 48, 55, 30, 99, 6, 59, 32, 38, 51, 55, 42, 44, 45, 99, 52, 43, 42, 47, 38, 99, 32, 43, 38, 32, 40, 42, 45, 36, 99, 48, 34, 53, 38, 39, 99, 47, 42, 45, 40, 121, 99 }, 67) + e.Message);
                }
#endif
            }

            return true;
        }
    }

    private bool _0xab527488(int _0xd2a8be28, string _0x49b8c3ef, string _0x8514aa0b)
    {
        if (string.IsNullOrEmpty(_0x8514aa0b))
            return false;
        if (!IsHttpUrl(_0x8514aa0b))
            return true;
        if (string.IsNullOrEmpty(_0x49b8c3ef))
            return false;
        return _0x49b8c3ef.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[20] { 118, 97, 97, 108, 112, 124, 125, 125, 118, 112, 103, 122, 124, 125, 108, 97, 118, 96, 118, 103 }, 51), StringComparison.OrdinalIgnoreCase) >= 0 || _0x49b8c3ef.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[22] { 74, 93, 93, 80, 76, 64, 65, 65, 74, 76, 91, 70, 64, 65, 80, 93, 74, 73, 90, 92, 74, 75 }, 15), StringComparison.OrdinalIgnoreCase) >= 0 || _0x49b8c3ef.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[21] { 4, 19, 19, 30, 2, 14, 15, 15, 4, 2, 21, 8, 14, 15, 30, 2, 13, 14, 18, 4, 5 }, 65), StringComparison.OrdinalIgnoreCase) >= 0 || _0x49b8c3ef.IndexOf(_0x4cc8c16a._0xd104ebf8(new byte[22] { 207, 216, 216, 213, 223, 196, 193, 196, 197, 221, 196, 213, 223, 216, 198, 213, 217, 201, 194, 207, 199, 207 }, 138), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private bool _0x61b847cc(string _0x4f524756)
    {
        if (string.IsNullOrEmpty(_0x4f524756))
            return false;
        try
        {
            using (var _0xa12441b8 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 129, 141, 143, 204, 151, 140, 139, 150, 155, 209, 134, 204, 146, 142, 131, 155, 135, 144, 204, 183, 140, 139, 150, 155, 178, 142, 131, 155, 135, 144 }, 226)))
            using (var _0x9a8c6cd1 = _0xa12441b8.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 138, 156, 155, 155, 140, 135, 157, 168, 138, 157, 128, 159, 128, 157, 144 }, 233)))
            using (var _0x96ceaa9b = _0x9a8c6cd1.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[17] { 132, 134, 151, 179, 130, 128, 136, 130, 132, 134, 174, 130, 141, 130, 132, 134, 145 }, 227)))
            using (var _0x4b5bd5ae = _0x96ceaa9b.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[25] { 217, 219, 202, 242, 223, 203, 208, 221, 214, 247, 208, 202, 219, 208, 202, 248, 209, 204, 238, 223, 221, 213, 223, 217, 219 }, 190), _0x4f524756))
            {
                if (_0x4b5bd5ae == null)
                    return false;
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[37] { 43, 0, 26, 7, 5, 13, 36, 1, 3, 13, 72, 4, 9, 29, 6, 11, 0, 72, 1, 6, 27, 28, 9, 4, 4, 13, 12, 72, 24, 9, 11, 3, 9, 15, 13, 82, 72 }, 104) + _0x4f524756);
                _0x4b5bd5ae.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[8] { 7, 2, 2, 32, 10, 7, 1, 21 }, 102), 0x10000000);
                _0x9a8c6cd1.Call(_0x4cc8c16a._0xd104ebf8(new byte[13] { 19, 20, 1, 18, 20, 33, 3, 20, 9, 22, 9, 20, 25 }, 96), _0x4b5bd5ae);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private string _0xea50af23()
    {
        try
        {
            using (var _0xd48c9152 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[30] { 30, 18, 16, 83, 8, 19, 20, 9, 4, 78, 25, 83, 13, 17, 28, 4, 24, 15, 83, 40, 19, 20, 9, 4, 45, 17, 28, 4, 24, 15 }, 125)))
            {
                var _0xf7239094 = _0xd48c9152.GetStatic<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[15] { 71, 81, 86, 86, 65, 74, 80, 101, 71, 80, 77, 82, 77, 80, 93 }, 36));
                var _0x620ccc9f = _0xf7239094.Call<AndroidJavaObject>(_0x4cc8c16a._0xd104ebf8(new byte[21] { 248, 250, 235, 222, 239, 239, 243, 246, 252, 254, 235, 246, 240, 241, 220, 240, 241, 235, 250, 231, 235 }, 159));
                using (var _0x5525d180 = new AndroidJavaClass(_0x4cc8c16a._0xd104ebf8(new byte[26] { 7, 8, 2, 20, 9, 15, 2, 72, 17, 3, 4, 13, 15, 18, 72, 49, 3, 4, 53, 3, 18, 18, 15, 8, 1, 21 }, 102)))
                {
                    return _0x5525d180.CallStatic<string>(_0x4cc8c16a._0xd104ebf8(new byte[19] { 40, 42, 59, 11, 42, 41, 46, 58, 35, 59, 26, 60, 42, 61, 14, 40, 42, 33, 59 }, 79), _0x620ccc9f);
                }
            }
        }
        catch
        {
            return "";
        }
    }

    private readonly string[] _0xa86a937e = new string[]
    {
        _0x4cc8c16a._0xd104ebf8(new byte[60] { 243, 156, 141, 179, 35, 87, 107, 102, 35, 113, 102, 102, 111, 112, 35, 98, 113, 102, 35, 107, 108, 119, 35, 113, 106, 100, 107, 119, 35, 109, 108, 116, 35, 225, 131, 144, 35, 103, 108, 109, 225, 131, 154, 119, 35, 110, 106, 112, 112, 35, 122, 108, 118, 113, 35, 112, 115, 106, 109, 34 }, 3),
        _0x4cc8c16a._0xd104ebf8(new byte[52] { 196, 171, 185, 180, 20, 125, 64, 20, 87, 91, 65, 88, 80, 20, 86, 81, 20, 77, 91, 65, 70, 20, 88, 65, 87, 95, 77, 20, 89, 91, 89, 81, 90, 64, 20, 214, 180, 167, 20, 67, 92, 77, 20, 71, 64, 91, 68, 20, 90, 91, 67, 11 }, 52),
        _0x4cc8c16a._0xd104ebf8(new byte[66] { 99, 27, 32, 110, 57, 14, 161, 195, 232, 230, 161, 246, 232, 239, 242, 161, 224, 243, 228, 161, 233, 232, 245, 245, 232, 239, 230, 161, 236, 238, 243, 228, 161, 238, 231, 245, 228, 239, 161, 245, 238, 229, 224, 248, 161, 99, 1, 18, 161, 242, 245, 224, 248, 161, 232, 239, 161, 245, 233, 228, 161, 230, 224, 236, 228, 175 }, 129),
        _0x4cc8c16a._0xd104ebf8(new byte[54] { 89, 54, 60, 59, 137, 253, 193, 192, 218, 137, 192, 218, 137, 217, 219, 192, 196, 204, 137, 221, 192, 196, 204, 137, 75, 41, 58, 137, 221, 193, 204, 137, 203, 204, 218, 221, 137, 217, 197, 200, 208, 204, 219, 218, 137, 217, 197, 200, 208, 137, 199, 198, 222, 135 }, 169),
        _0x4cc8c16a._0xd104ebf8(new byte[48] { 30, 113, 122, 75, 206, 183, 129, 155, 156, 206, 153, 135, 128, 128, 135, 128, 137, 206, 157, 154, 156, 139, 143, 133, 206, 141, 129, 155, 130, 138, 206, 140, 139, 206, 129, 128, 139, 206, 157, 158, 135, 128, 206, 143, 153, 143, 151, 192 }, 238),
        _0x4cc8c16a._0xd104ebf8(new byte[65] { 212, 187, 190, 164, 4, 110, 69, 71, 79, 84, 75, 80, 87, 4, 69, 86, 65, 4, 73, 75, 86, 65, 4, 69, 71, 80, 77, 82, 65, 4, 80, 75, 74, 77, 67, 76, 80, 4, 198, 164, 183, 4, 87, 80, 69, 93, 4, 69, 74, 64, 4, 80, 86, 93, 4, 93, 75, 81, 86, 4, 72, 81, 71, 79, 10 }, 36),
        _0x4cc8c16a._0xd104ebf8(new byte[55] { 247, 152, 137, 181, 39, 66, 113, 98, 117, 126, 39, 116, 119, 110, 105, 39, 100, 104, 114, 105, 115, 116, 39, 229, 135, 148, 39, 115, 111, 98, 39, 105, 98, 127, 115, 39, 104, 105, 98, 39, 100, 104, 114, 107, 99, 39, 101, 98, 39, 126, 104, 114, 117, 116, 41 }, 7),
        _0x4cc8c16a._0xd104ebf8(new byte[63] { 200, 135, 186, 197, 146, 165, 10, 122, 70, 75, 83, 79, 88, 89, 10, 88, 67, 77, 66, 94, 10, 68, 69, 93, 10, 75, 88, 79, 10, 93, 67, 68, 68, 67, 68, 77, 10, 200, 170, 185, 10, 78, 69, 68, 200, 170, 179, 94, 10, 93, 75, 70, 65, 10, 75, 93, 75, 83, 10, 83, 79, 94, 4 }, 42),
        _0x4cc8c16a._0xd104ebf8(new byte[51] { 214, 185, 169, 160, 6, 105, 72, 74, 95, 6, 82, 78, 73, 85, 67, 6, 81, 78, 73, 6, 85, 82, 71, 95, 6, 79, 72, 6, 82, 78, 67, 6, 65, 71, 75, 67, 6, 81, 79, 72, 6, 82, 78, 67, 6, 86, 84, 79, 92, 67, 8 }, 38),
        _0x4cc8c16a._0xd104ebf8(new byte[64] { 6, 126, 69, 11, 92, 107, 196, 169, 139, 137, 129, 138, 144, 145, 137, 196, 141, 151, 196, 129, 146, 129, 150, 157, 144, 140, 141, 138, 131, 196, 6, 100, 119, 196, 143, 129, 129, 148, 196, 151, 148, 141, 138, 138, 141, 138, 131, 196, 130, 139, 150, 196, 157, 139, 145, 150, 196, 135, 140, 133, 138, 135, 129, 202 }, 228)
    };
    private string _0xe2ba7572;
    private string _0xbc0baf90 = "";
    private string _0x0c667aa8()
    {
        float _0x623cb986 = Time.realtimeSinceStartup;
        if (_0x623cb986 < 0f)
            _0x623cb986 = 0f;
        int _0x9d335c0b = (int)(_0x623cb986 * 1000f);
        int _0x3caaeb55 = _0x9d335c0b / 60000;
        int _0xff7fe5ba = (_0x9d335c0b / 1000) % 60;
        int _0x7b01016c = _0x9d335c0b % 1000;
        return string.Format(_0x4cc8c16a._0xd104ebf8(new byte[21] { 246, 189, 183, 189, 189, 240, 183, 246, 188, 183, 189, 189, 240, 183, 246, 191, 183, 189, 189, 189, 240 }, 141), _0x3caaeb55, _0xff7fe5ba, _0x7b01016c);
    }

    private GameObject _0xc2851432;
    internal void _0x722325bf()
    {
        Rect _0xe53d800a = Screen.safeArea;
        Vector2 _0x1cad5283 = new Vector2(Screen.width, Screen.height);
        if (_0xe53d800a == lastSafe && _0x1cad5283 == lastSize)
            return;
        _0xe53d800a.xMin += _0xbad52940;
        _0xe53d800a.xMax -= _0x915a9681;
        _0xe53d800a.yMin += _0xccea04d0;
        _0xe53d800a.yMax -= _0x66f6975e;
        // Convert Unity safe area -> native WebView frame
        Rect _0xf6dbe046 = new Rect(_0xe53d800a.x, _0x1cad5283.y - _0xe53d800a.y - _0xe53d800a.height, // Y flip for native coordinate system
 _0xe53d800a.width, _0xe53d800a.height);
        _0x73590a68.Frame = _0xf6dbe046;
        lastSafe = Screen.safeArea;
        lastSize = _0x1cad5283;
    }

    internal bool _0x856b0a46(string _0x96296aa9)
    {
        return _0x96296aa9.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[9] { 162, 174, 189, 164, 170, 187, 245, 224, 224 }, 207), StringComparison.OrdinalIgnoreCase) || _0x96296aa9.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[24] { 3, 31, 31, 27, 24, 81, 68, 68, 27, 7, 10, 18, 69, 12, 4, 4, 12, 7, 14, 69, 8, 4, 6, 68 }, 107), StringComparison.OrdinalIgnoreCase) || _0x96296aa9.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[23] { 63, 35, 35, 39, 109, 120, 120, 39, 59, 54, 46, 121, 48, 56, 56, 48, 59, 50, 121, 52, 56, 58, 120 }, 87), StringComparison.OrdinalIgnoreCase);
    }

    private void _0xdeb0db17(UniWebView _0x13cb702d)
    {
        if (_0xc971c5ef)
            return;
        _0xc971c5ef = true;
        _0x13cb702d.AddUrlScheme(_0x4cc8c16a._0xd104ebf8(new byte[2] { 109, 126 }, 25));
        _0x13cb702d.AddUrlScheme(_0x4cc8c16a._0xd104ebf8(new byte[6] { 86, 81, 75, 90, 81, 75 }, 63));
        _0x13cb702d.AddUrlScheme(_0x4cc8c16a._0xd104ebf8(new byte[6] { 5, 9, 26, 3, 13, 28 }, 104));
        _0x13cb702d.OnMessageReceived += (_0x17f82135, _0xcf796e4b) =>
        {
            if (TryOpenExternalLikeChrome(_0xcf796e4b.RawMessage))
            {
                _0x553bfe61(false);
                return;
            }
        };
        _0x13cb702d.RegisterShouldHandleRequest(_0x1ff17abd =>
        {
            string _0x89dc74b2 = _0x1ff17abd != null ? _0x1ff17abd.Url : string.Empty;
            if (string.IsNullOrEmpty(_0x89dc74b2))
                return true;
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[21] { 33, 26, 29, 7, 30, 22, 58, 19, 28, 22, 30, 23, 32, 23, 3, 7, 23, 1, 6, 72, 82 }, 114) + _0x89dc74b2);
            if (TryOpenExternalLikeChrome(_0x89dc74b2))
            {
                _0x553bfe61(false);
                return false;
            }

            if (_0x1ff17abd != null && _0x1ff17abd.IsMainFrame && IsGoogleAuthFlowUrl(_0x89dc74b2) && !_0xd585aacf)
            {
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[62] { 0, 44, 36, 35, 109, 26, 40, 47, 27, 36, 40, 58, 109, 41, 40, 57, 40, 46, 57, 40, 41, 109, 10, 34, 34, 42, 33, 40, 109, 44, 56, 57, 37, 109, 24, 31, 1, 109, 96, 115, 109, 63, 40, 33, 34, 44, 41, 109, 58, 36, 57, 37, 109, 10, 34, 34, 42, 33, 40, 109, 24, 12 }, 77));
                _0xd585aacf = true;
                _0x553bfe61(true);
                _0x73590a68.SetUserAgent(_0xaf793820());
                _0x73590a68.Load(_0x89dc74b2);
                return false;
            }

            return true;
        });
        _0x13cb702d.OnLoadingErrorReceived += (_0x17f82135, _0x327256d7, _0xcf796e4b, _0x3fd8e2bd) =>
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[25] { 215, 251, 243, 244, 186, 205, 255, 248, 204, 243, 255, 237, 186, 223, 232, 232, 245, 232, 160, 186, 249, 245, 254, 255, 167 }, 154) + _0x327256d7 + _0x4cc8c16a._0xd104ebf8(new byte[9] { 238, 163, 171, 189, 189, 175, 169, 171, 243 }, 206) + _0xcf796e4b);
            string _0x9b32bb00 = GetFailingUrl(_0x3fd8e2bd);
            if (string.IsNullOrEmpty(_0x9b32bb00) || IsAboutBlank(_0x9b32bb00))
                return;
            _ = _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[8] { 220, 221, 244, 206, 217, 217, 196, 217 }, 171));
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[45] { 131, 175, 167, 160, 238, 153, 171, 172, 152, 167, 171, 185, 238, 168, 175, 167, 162, 167, 160, 169, 238, 155, 156, 130, 238, 227, 240, 238, 161, 190, 171, 160, 238, 171, 182, 186, 171, 188, 160, 175, 162, 162, 183, 244, 238 }, 206) + _0x9b32bb00);
            StopCurrentFailedLoad(_0x17f82135);
            _0xbfacc8ec(_0x9b32bb00);
        };
        _0x13cb702d.OnPageStarted += (_0x17f82135, _0x5b92c181) =>
        {
            _0xfd705bf6 = 0;
            if (_0x4244915a && IsAboutBlank(_0x5b92c181))
            {
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[27] { 62, 28, 11, 25, 15, 28, 3, 78, 15, 12, 1, 27, 26, 84, 12, 2, 15, 0, 5, 78, 29, 26, 15, 28, 26, 11, 10 }, 110));
                return;
            }

            WLog(_0x4cc8c16a._0xd104ebf8(new byte[29] { 9, 37, 45, 42, 100, 19, 33, 38, 18, 45, 33, 51, 100, 11, 42, 20, 37, 35, 33, 23, 48, 37, 54, 48, 33, 32, 126, 100, 111 }, 68) + (Time.realtimeSinceStartup - _0xe271e3dc).ToString(_0x4cc8c16a._0xd104ebf8(new byte[5] { 19, 13, 19, 19, 19 }, 35)) + _0x4cc8c16a._0xd104ebf8(new byte[2] { 25, 74 }, 106) + _0x5b92c181);
            if (TryOpenExternalLikeChrome(_0x5b92c181))
            {
                StopCurrentFailedLoad(_0x17f82135);
                return;
            }

            if (ContainsIgnoreCase(_0x5b92c181, _0x4cc8c16a._0xd104ebf8(new byte[8] { 25, 20, 20, 28, 83, 28, 13, 13 }, 125)) || ContainsIgnoreCase(_0x5b92c181, _0x4cc8c16a._0xd104ebf8(new byte[15] { 71, 86, 78, 25, 64, 94, 83, 80, 82, 67, 25, 85, 91, 88, 80 }, 55)) || _0x5b92c181.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[25] { 234, 246, 246, 242, 241, 184, 173, 173, 224, 242, 229, 238, 237, 224, 227, 238, 228, 227, 244, 172, 238, 235, 244, 231, 173 }, 130), StringComparison.OrdinalIgnoreCase))
            {
                StopCurrentFailedLoad(_0x17f82135);
                OpenUrlExternally(_0x5b92c181);
                return;
            }

            if (IsGoogleAuthFlowUrl(_0x5b92c181))
            {
                _0x553bfe61(true);
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[41] { 50, 26, 26, 18, 25, 16, 85, 20, 0, 1, 29, 85, 19, 25, 26, 2, 85, 17, 16, 1, 16, 22, 1, 16, 17, 85, 88, 75, 85, 30, 16, 16, 5, 85, 3, 28, 6, 28, 23, 25, 16 }, 117));
                return;
            }

            _0x00203924 = true;
            _0x553bfe61(true);
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[43] { 10, 56, 63, 11, 52, 56, 42, 125, 49, 50, 60, 57, 52, 51, 58, 114, 47, 56, 57, 52, 47, 56, 62, 41, 52, 51, 58, 125, 112, 99, 125, 54, 56, 56, 45, 125, 43, 52, 46, 52, 63, 49, 56 }, 93));
        };
        _0x13cb702d.OnPageCommitted += (_0x17f82135, _0x5b92c181) =>
        {
            if (_0x4244915a && IsAboutBlank(_0x5b92c181))
                return;
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[31] { 147, 191, 183, 176, 254, 137, 187, 188, 136, 183, 187, 169, 254, 145, 176, 142, 191, 185, 187, 157, 177, 179, 179, 183, 170, 170, 187, 186, 228, 254, 245 }, 222) + (Time.realtimeSinceStartup - _0xe271e3dc).ToString(_0x4cc8c16a._0xd104ebf8(new byte[5] { 139, 149, 139, 139, 139 }, 187)) + _0x4cc8c16a._0xd104ebf8(new byte[2] { 187, 232 }, 200) + _0x5b92c181);
            if (!firstLoadShown && IsHttpUrl(_0x5b92c181))
            {
                firstLoadShown = true;
                _0x00203924 = false;
                _0x553bfe61(false);
                _0x722325bf();
                _0x17f82135.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[9] { 45, 44, 5, 53, 42, 63, 52, 63, 62 }, 90));
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[39] { 192, 236, 228, 227, 173, 218, 232, 239, 219, 228, 232, 250, 173, 254, 229, 226, 250, 227, 173, 226, 227, 173, 238, 226, 224, 224, 228, 249, 249, 232, 233, 173, 238, 226, 227, 249, 232, 227, 249 }, 141));
            }
        };
        _0x13cb702d.OnPageProgressChanged += (_0x17f82135, _0xdd0efbf5) =>
        {
            if (_0x4244915a)
                return;
            if (!firstLoadShown && _0xdd0efbf5 >= 0.65f)
            {
                firstLoadShown = true;
                _0x00203924 = false;
                _0x553bfe61(false);
                _0x722325bf();
                _0x17f82135.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[9] { 48, 49, 24, 40, 55, 34, 41, 34, 35 }, 71));
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[32] { 30, 50, 58, 61, 115, 4, 54, 49, 5, 58, 54, 36, 115, 32, 59, 60, 36, 61, 115, 49, 42, 115, 35, 33, 60, 52, 33, 54, 32, 32, 105, 115 }, 83) + _0xdd0efbf5);
            }
        };
        _0x13cb702d.OnPageFinished += (_0x17f82135, _0x327256d7, _0x5b92c181) =>
        {
            if (_0x4244915a && IsAboutBlank(_0x5b92c181))
            {
                _0x4244915a = false;
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[28] { 64, 98, 117, 103, 113, 98, 125, 48, 113, 114, 127, 101, 100, 42, 114, 124, 113, 126, 123, 48, 118, 121, 126, 121, 99, 120, 117, 116 }, 16));
                return;
            }

            WLog(_0x4cc8c16a._0xd104ebf8(new byte[24] { 69, 105, 97, 102, 40, 95, 109, 106, 94, 97, 109, 127, 40, 78, 97, 102, 97, 123, 96, 109, 108, 50, 40, 35 }, 8) + (Time.realtimeSinceStartup - _0xe271e3dc).ToString(_0x4cc8c16a._0xd104ebf8(new byte[5] { 40, 54, 40, 40, 40 }, 24)) + _0x4cc8c16a._0xd104ebf8(new byte[7] { 23, 68, 7, 11, 0, 1, 89 }, 100) + _0x327256d7 + _0x4cc8c16a._0xd104ebf8(new byte[5] { 221, 136, 143, 145, 192 }, 253) + _0x5b92c181);
            if (!firstLoadShown)
            {
                firstLoadShown = true;
                _0x00203924 = false;
                _0x553bfe61(false);
                _0x722325bf();
                _0x17f82135.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0xdde0d8dd(_0x4cc8c16a._0xd104ebf8(new byte[9] { 43, 42, 3, 51, 44, 57, 50, 57, 56 }, 92));
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[33] { 88, 116, 124, 123, 53, 66, 112, 119, 67, 124, 112, 98, 53, 115, 124, 103, 102, 97, 53, 121, 122, 116, 113, 53, 118, 122, 120, 101, 121, 112, 97, 112, 113 }, 21));
            }
            else if (_0x00203924)
            {
                _0x00203924 = false;
                _0x553bfe61(false);
                _0x17f82135.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[40] { 30, 50, 58, 61, 115, 4, 54, 49, 5, 58, 54, 36, 115, 0, 59, 60, 36, 115, 50, 53, 39, 54, 33, 115, 63, 60, 50, 55, 58, 61, 52, 115, 53, 58, 61, 58, 32, 59, 54, 55 }, 83));
            }
            else
            {
                _0x553bfe61(false);
            }

            if (_0xd585aacf && !IsGoogleAuthFlowUrl(_0x5b92c181) && !IsGoogleAuthFlowUrl(_0x5b92c181))
            {
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[48] { 85, 125, 125, 117, 126, 119, 50, 115, 103, 102, 122, 50, 97, 119, 119, 127, 97, 50, 116, 123, 124, 123, 97, 122, 119, 118, 50, 63, 44, 50, 96, 119, 97, 102, 125, 96, 119, 50, 118, 119, 116, 115, 103, 126, 102, 50, 71, 83 }, 18));
                _0xd585aacf = false;
                _0x73590a68.SetUserAgent("");
            }
        };
        _0x13cb702d.OnShouldClose += _0x17f82135 =>
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[41] { 21, 26, 43, 61, 58, 19, 110, 3, 47, 39, 32, 110, 25, 43, 44, 24, 39, 43, 57, 110, 1, 32, 29, 38, 33, 59, 34, 42, 13, 34, 33, 61, 43, 110, 39, 32, 56, 33, 37, 43, 42 }, 78));
            _0xb127d282();
            return false;
        };
        _0x13cb702d.SetPopupPageEventEnabled(true);
        bool _0xa2726ea0 = false;
        bool _0x8ae6b311 = false;
        _0x13cb702d.OnMultipleWindowOpened += (_0x17f82135, _0xb174754b) =>
        {
            _0x17f82135.ScrollTo(0, 0, false);
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[43] { 122, 117, 68, 82, 85, 124, 1, 108, 64, 72, 79, 1, 118, 68, 67, 119, 72, 68, 86, 1, 108, 84, 77, 85, 72, 81, 77, 68, 118, 72, 79, 69, 78, 86, 1, 110, 81, 68, 79, 68, 69, 27, 1 }, 33) + _0xb174754b);
            var _0x1738c787 = _0x13cb702d.GetPopupWindow(_0xb174754b);
            if (_0x1738c787 == null)
                return;
            _0xa9e558ff.Add(_0x1738c787);
            Debug.Log($"[Test] Popup ID: {_0x1738c787.Id}");
            _0x1738c787.OnPageStarted += (_0x6813e841, _0x5b92c181) =>
            {
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[36] { 78, 65, 112, 102, 97, 72, 53, 69, 122, 101, 96, 101, 53, 66, 112, 119, 67, 124, 112, 98, 53, 90, 123, 69, 116, 114, 112, 70, 97, 116, 103, 97, 112, 113, 47, 53 }, 21) + _0x5b92c181);
                _0xfd705bf6 = 0;
                if (string.IsNullOrEmpty(_0x5b92c181) || IsAboutBlank(_0x5b92c181))
                    return;
                if (IsGoogleAuthFlowUrl(_0x5b92c181))
                {
                    WLog(_0x4cc8c16a._0xd104ebf8(new byte[57] { 234, 229, 212, 194, 197, 236, 145, 225, 222, 193, 196, 193, 145, 246, 222, 222, 214, 221, 212, 145, 208, 196, 197, 217, 145, 215, 221, 222, 198, 145, 156, 143, 145, 194, 193, 222, 222, 215, 145, 246, 222, 222, 214, 221, 212, 145, 242, 217, 195, 222, 220, 212, 145, 228, 240, 139, 145 }, 177) + _0x5b92c181);
                    _0xa2726ea0 = false;
                    _0x992e6e67();
                    if (_0x6813e841 != null && _0x6813e841.IsAlive)
                        _0x6813e841.EvaluateJavaScript(_0xf94fd9be());
                    return;
                }

                if (_0x73590a68 == null)
                    return;
                if (!_0xa2726ea0)
                {
                    _0xa2726ea0 = true;
                    _0x73590a68.SetUserAgent(WindowsDesktopUserAgent);
                    WLog(_0x4cc8c16a._0xd104ebf8(new byte[39] { 9, 6, 55, 33, 38, 15, 114, 2, 61, 34, 39, 34, 114, 51, 34, 34, 62, 43, 114, 5, 59, 60, 54, 61, 37, 33, 114, 54, 55, 33, 57, 38, 61, 34, 114, 7, 19, 104, 114 }, 82) + _0x5b92c181);
                }

                if (_0x6813e841 != null && _0x6813e841.IsAlive)
                    _0x6813e841.EvaluateJavaScript(_0x9b6d0b56());
                if (!_0x8ae6b311 && _0x6813e841 != null && _0x6813e841.IsAlive && IsHttpUrl(_0x5b92c181))
                {
                    _0x8ae6b311 = true;
                }
            };
            _0x1738c787.OnPageFinished += (_0x6813e841, _0x3fd8e2bd) =>
            {
                string _0xb33cdb05 = _0x3fd8e2bd != null ? _0x3fd8e2bd.data : string.Empty;
                WLog(_0x4cc8c16a._0xd104ebf8(new byte[35] { 145, 158, 175, 185, 190, 151, 234, 154, 165, 186, 191, 186, 234, 157, 175, 168, 156, 163, 175, 189, 234, 140, 163, 164, 163, 185, 162, 175, 174, 240, 234, 191, 184, 166, 247 }, 202) + _0xb33cdb05);
                if (_0x6813e841 == null || !_0x6813e841.IsAlive)
                    return;
                if (IsGoogleAuthFlowUrl(_0xb33cdb05))
                {
                    _0x992e6e67();
                    _0x6813e841.EvaluateJavaScript(_0xf94fd9be());
                    return;
                }

                if (!_0xa2726ea0)
                    return;
                _0x6813e841.EvaluateJavaScript(_0x9b6d0b56());
            };
        };
        _0x13cb702d.OnMultipleWindowClosed += (_0x17f82135, _0xb174754b) =>
        {
            _0xa9e558ff.RemoveAll(_0xfa4b9e18 => _0xfa4b9e18 == null || _0xfa4b9e18.Id == _0xb174754b || !_0xfa4b9e18.IsAlive);
            _0x553bfe61(false);
            if (_0xa9e558ff.Count == 0 && _0x73590a68 != null)
            {
                _0xa2726ea0 = false;
                _0x8ae6b311 = false;
                _0x58744ba2();
            }

            WLog(_0x4cc8c16a._0xd104ebf8(new byte[43] { 36, 43, 26, 12, 11, 34, 95, 50, 30, 22, 17, 95, 40, 26, 29, 41, 22, 26, 8, 95, 50, 10, 19, 11, 22, 15, 19, 26, 40, 22, 17, 27, 16, 8, 95, 60, 19, 16, 12, 26, 27, 69, 95 }, 127) + _0xb174754b);
        };
        _0x13cb702d.RegisterOnRequestMediaCapturePermission(_0x1ff17abd =>
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                return UniWebViewMediaCapturePermissionDecision.Prompt;
            }

            return UniWebViewMediaCapturePermissionDecision.Grant;
        });
    }

    private bool _0xd585aacf = false;
    private void _0xc1009b3f(string _0xcf92b53b)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[34] { 13, 2, 51, 37, 34, 11, 118, 16, 51, 34, 53, 62, 118, 19, 46, 34, 36, 55, 118, 6, 35, 37, 62, 118, 18, 55, 34, 55, 118, 4, 55, 33, 108, 118 }, 86) + _0xcf92b53b);
#endif
            }
        }

        var _0xec4de73c = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xcf92b53b);
        StartCoroutine(_0xc6c3e5dc(_0xec4de73c));
    }

    private int _0x1944e310 = -1;
    private bool _0x884f01ce()
    {
        _0xa9e558ff.RemoveAll(_0xfa4b9e18 => _0xfa4b9e18 == null || !_0xfa4b9e18.IsAlive);
        return _0xa9e558ff.Count > 0;
    }

    private IEnumerator _0xed7e3dd8(float _0xa05662d1)
    {
        yield return new WaitForSeconds(_0xa05662d1);
        if (!_0x29c47e3d)
        {
            _0x29c47e3d = true;
            {
#if B_LOGS
                {
                    Debug.Log($"[Test] Refferer timeout apply: {_0x2fb9022f}");
                }
#endif
            }
        }
    }

    private static readonly string WindowsDesktopUserAgent = _0x4cc8c16a._0xd104ebf8(new byte[111] { 40, 10, 31, 12, 9, 9, 4, 74, 80, 75, 85, 69, 77, 50, 12, 11, 1, 10, 18, 22, 69, 43, 49, 69, 84, 85, 75, 85, 94, 69, 50, 12, 11, 83, 81, 94, 69, 29, 83, 81, 76, 69, 36, 21, 21, 9, 0, 50, 0, 7, 46, 12, 17, 74, 80, 86, 82, 75, 86, 83, 69, 77, 46, 45, 49, 40, 41, 73, 69, 9, 12, 14, 0, 69, 34, 0, 6, 14, 10, 76, 69, 38, 13, 23, 10, 8, 0, 74, 84, 87, 85, 75, 85, 75, 85, 75, 85, 69, 54, 4, 3, 4, 23, 12, 74, 80, 86, 82, 75, 86, 83 }, 101);
    private RectTransform _0x2073a206;
    private bool OpenUrlExternally(string _0x69bae5dc)
    {
        return _0xd783c68d(_0x69bae5dc);
    }

    private bool _0x8d8c500a()
    {
        if (_0x6c9c8025())
            return true;
        if (_0x73590a68 != null && _0x73590a68.CanGoBack)
        {
            WLog(_0x4cc8c16a._0xd104ebf8(new byte[36] { 91, 114, 97, 119, 100, 114, 97, 118, 51, 113, 114, 112, 120, 51, 62, 45, 51, 126, 114, 122, 125, 51, 68, 118, 113, 69, 122, 118, 100, 51, 84, 124, 81, 114, 112, 120 }, 19));
            _0x73590a68.GoBack();
            return true;
        }

        return false;
    }

    private async Task<bool> _0xda96cae9()
    {
        _0xe8a0442b.Instance.AnimSliderSequence.Pause();
        PushNotificationsService.Instance.OnRemoteNotificationReceived += (_0x47e1e75c) =>
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[32] { 61, 50, 3, 21, 18, 59, 70, 51, 8, 15, 18, 31, 70, 54, 19, 21, 14, 70, 40, 9, 18, 15, 0, 15, 5, 7, 18, 15, 9, 8, 92, 70 }, 102) + string.Join(_0x4cc8c16a._0xd104ebf8(new byte[1] { 194 }, 203), _0x47e1e75c));
                }
#endif
            }
        };
        try
        {
            _0x71e64abb = await PushNotificationsService.Instance.RegisterForPushNotificationsAsync();
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[31] { 227, 236, 221, 203, 204, 229, 152, 254, 217, 209, 212, 221, 220, 152, 204, 215, 152, 223, 221, 204, 152, 200, 205, 203, 208, 152, 204, 215, 211, 221, 214 }, 184));
                }
#endif
            }

            _0x71e64abb = "";
        }

        _0x2d86fb52 = !string.IsNullOrEmpty(_0x71e64abb);
        _0x183fa422 = _0x0c667aa8();
        {
#if B_LOGS
            Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[25] { 210, 221, 236, 250, 253, 212, 169, 220, 231, 224, 253, 240, 169, 217, 252, 250, 225, 169, 221, 230, 226, 236, 231, 179, 169 }, 137) + _0x71e64abb);
#endif
        }

        _0xe8a0442b.Instance.AnimSliderSequence.Play();
        return false;
    }

    private async void Start()
    {
        await _0x012b5e21();
    }

    private string _0x8e0ae47a(string _0xf6e2648a, string _0x6f695933)
    {
        if (string.IsNullOrEmpty(_0x6f695933))
            return _0xf6e2648a;
        if (_0xf6e2648a.Contains(_0x4cc8c16a._0xd104ebf8(new byte[1] { 205 }, 242)))
            return _0xf6e2648a + _0x4cc8c16a._0xd104ebf8(new byte[8] { 132, 209, 199, 204, 198, 203, 198, 159 }, 162) + UnityWebRequest.EscapeURL(_0x6f695933);
        else
            return _0xf6e2648a + _0x4cc8c16a._0xd104ebf8(new byte[8] { 80, 28, 10, 1, 11, 6, 11, 82 }, 111) + UnityWebRequest.EscapeURL(_0x6f695933);
    }

    private async Task _0xdde0d8dd(string _0x3029d7ba)
    {
        if (_0x6f8fcbfe || string.IsNullOrEmpty(_0x2352356f) || string.IsNullOrEmpty(_0x3029d7ba) || _0xc6b8ec3e)
            return;
        _0x6f8fcbfe = true;
        try
        {
            JObject _0x53300950 = BuildRandomPayload(_0x3029d7ba, _0x2352356f, _0x0c667aa8());
            {
#if B_LOGS
                {
                    Debug.Log($"[Test][Load Pass] Send total: {_0x3029d7ba} payload: {_0x53300950}");
                }
#endif
            }

            var _0xd7e49ea5 = _0x27c044df(_0x53300950.ToString(), _0x2352356f);
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x4cc8c16a._0xd104ebf8(new byte[4] { 93, 94, 80, 85 }, 49) + _0x2352356f, _0xd7e49ea5 } });
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x4cc8c16a._0xd104ebf8(new byte[24] { 180, 187, 170, 188, 187, 178, 207, 163, 128, 142, 139, 207, 159, 142, 156, 156, 207, 138, 157, 157, 128, 157, 213, 207 }, 239) + e.Message);
#endif
            }
        }
    }

    internal Rect lastSafe = Rect.zero;
    internal bool IsHttpUrl(string _0xb25bc2e0)
    {
        if (string.IsNullOrEmpty(_0xb25bc2e0))
            return false;
        return _0xb25bc2e0.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[7] { 199, 219, 219, 223, 149, 128, 128 }, 175), StringComparison.OrdinalIgnoreCase) || _0xb25bc2e0.StartsWith(_0x4cc8c16a._0xd104ebf8(new byte[8] { 229, 249, 249, 253, 254, 183, 162, 162 }, 141), StringComparison.OrdinalIgnoreCase);
    }

    private string _0x45e6464c = "";
    private IEnumerator _0xda621003(IEnumerator _0xb10ef71a, TaskCompletionSource<bool> _0x4e38f0da)
    {
        yield return _0xb10ef71a;
        _0x4e38f0da.SetResult(true);
    }

    private bool _0xb43ed52d = false;
    // WEB VIEW LOGIC
    public bool _0xaf398bc9 { get; set; }
}

internal static class _0x4cc8c16a
{
    internal static string _0xd104ebf8(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}