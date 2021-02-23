using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace GitHub.Unity
{
    [InitializeOnLoad]
    public class UnityAPIWrapper : ScriptableSingleton<UnityAPIWrapper>
    {
        static UnityAPIWrapper()
        {
#if UNITY_LESS_THAN_2020
            Editor.finishedDefaultHeaderGUI += editor => {
                UnityShim.Raise_Editor_finishedDefaultHeaderGUI(editor);
            };
#endif
        }
    }
}