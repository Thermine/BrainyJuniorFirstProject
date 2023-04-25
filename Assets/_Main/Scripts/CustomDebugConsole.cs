using StvDEV.StarterPack;
using TMPro;
using UnityEngine;


namespace BrainyJunior.MyGame.Scripts.Managers
{
    public class CustomDebugConsole : MonoBehaviourSingleton<CustomDebugConsole>
    {
        [SerializeField] private TMP_Text consoleText;
        [SerializeField] private int limitRows;
        
        public void Debug(string value)
        {
            if (consoleText.textInfo.lineCount >= limitRows )
            {
                consoleText.text = consoleText.text.Remove(0,consoleText.textInfo.lineInfo[0].characterCount);
            }
            consoleText.text += value;
        }

    }
}
