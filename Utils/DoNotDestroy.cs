/**
 * Tag this object not to be destroyed on load
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;

namespace WordsOnPlay.Utils {
public class DoNotDestroy : MonoBehaviour
{

#region Init & Destroy
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
#endregion Init

}
}