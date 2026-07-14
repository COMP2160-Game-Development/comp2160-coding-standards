/**
 * Limit the framerate the game is executing at.
 * This is useful for testing framerate independance.
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */

using UnityEngine;

namespace WordsOnPlay.Utils {
public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;

    private int oldVSyncCount;

    void OnEnable()
    {
        oldVSyncCount = QualitySettings.vSyncCount;
        QualitySettings.vSyncCount = 0;
    }

    void OnDisable()
    {
        QualitySettings.vSyncCount = oldVSyncCount;
        Application.targetFrameRate = -1; // unlimited        
    }

    void Update()
    {
        Application.targetFrameRate = targetFPS;
    }
}
}
