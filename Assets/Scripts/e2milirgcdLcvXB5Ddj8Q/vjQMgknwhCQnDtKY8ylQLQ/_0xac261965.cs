using UnityEngine;

public class _0xac261965 : MonoBehaviour
{
    public bool IsBestScoreEnabled;
    public bool IsLevelIncrementOnWin;
    public bool IsSkipSplashEnabled;
    public static _0xac261965 Instance;
    public bool IsTimerEnabled;
    public bool IsOnlyWinGameEndEnabled;
    public bool IsCheckScoreEnabled;
    private void _0xf79571ee()
    {
        {
#if !B_LOGS
        {
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
#endif
        }

        QualitySettings.vSyncCount = 1;
        Application.runInBackground = true;
    //Application.targetFrameRate = 60;
    // Time.fixedDeltaTime = 0.03f; // USE CUSTOM PHYSICS TIME FOR OPTIMIZATION IF NEEDED
    // Add this once at startup to silence the specific assertion
    }

    public bool IsStoryEnabled;
    private void _0x01266ceb()
    {
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject.GetComponent<_0xac261965>();
            DontDestroyOnLoad(this.gameObject);
            this._0xf79571ee();
        }
        else
        {
            this._0x01266ceb();
            Destroy(this.gameObject);
        }
    }

    public bool IsLevelSelectorEnabled;
    public bool IsTutorialEnabled;
}