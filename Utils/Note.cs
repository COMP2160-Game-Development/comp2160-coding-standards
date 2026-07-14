/**
 * A simple way to add notes to an object in the Inspector
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */

using UnityEngine;
 
namespace WordsOnPlay.Utils {
public class Note : MonoBehaviour
{
    [TextArea(5, 15)]
    public string notes = "";
}
}