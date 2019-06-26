using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
    public bool Enabled { set; get; } = true;

    void OnGUI()
    {
        if (!Enabled)
        {
            return;
        }
        OnTimeScaleGUI();
    }

    #region ChangeTimeScale
    private string _timeScaleTxt = "1";
    private float _deltaTimeScale = 0.1f;
    void OnTimeScaleGUI()
    {
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Time Scale: ");
        _timeScaleTxt = GUILayout.TextField(_timeScaleTxt, GUILayout.Width(30f));
        if (GUILayout.Button("-", GUILayout.Width(20f)))
        {
            if (float.TryParse(_timeScaleTxt, out float t))
            {
                t -= _deltaTimeScale;
                t = t <= 0f ? 0f : t;
                _timeScaleTxt = t.ToString();
            }
        }
        if (GUILayout.Button("+", GUILayout.Width(20f)))
        {
            if (float.TryParse(_timeScaleTxt, out float t))
            {
                t += _deltaTimeScale;
                t = t >= 2f ? 2f : t;
                _timeScaleTxt = t.ToString();
            }
        }

        if (float.TryParse(_timeScaleTxt, out float timeScale))
        {
            Time.timeScale = timeScale;
        }
        GUILayout.EndHorizontal();
    }
    #endregion
}
