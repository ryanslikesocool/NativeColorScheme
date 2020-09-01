using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSchemeManager : MonoBehaviour
{
    private void Start()
    {
        ChangeScheme();
    }

    /// Automatically detect system dark mode from native plugin
    /// Will set to light scheme if plugin is not supported on platform
    public void ChangeScheme()
    {
        ColorScheme newScheme = DarkDetector.IsDarkModeEnabled() ? ColorScheme.Dark : ColorScheme.Light;
        ChangeScheme(newScheme);
    }

    public void ChangeScheme(ColorScheme scheme)
    {
        /// Replace this with your integration
        Camera.main.backgroundColor = scheme == ColorScheme.Light ? Color.white : Color.black;
    }

    /// This will call ChangeScheme when the application regains focus from being in the background
    /// This covers most, if not all cases where the system theme might change at runtime
    private void OnApplicationFocus(bool focusStatus)
    {
        ChangeScheme();
    }
}

public enum ColorScheme
{
    Light,
    Dark
}