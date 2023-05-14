using System;
using System.IO;
using StvDEV.StarterPack;
using UnityEngine;

namespace BrainyJunior.MyGame.Scripts.Managers
{
    public class SaveDataInFileManager : MonoBehaviourSingleton<BackgroundMusicManager>
    {
        private TextWriter _tw; 
        private string _fullPathAndFileName;
        

        [SerializeField] private string fileNameAndPath = "Resource/test.csv";
        
        

        
        [ContextMenu("write")]
        public void WriteCsv(string i)
        {
            CustomDebugConsole.Instance.Debug(_fullPathAndFileName);
            _tw = new StreamWriter(_fullPathAndFileName, true);
            _tw.Write(i + ",");
            _tw.Close();
            

        }
        
        public void WriteEnterCsv(string i)
        {
            _tw = new StreamWriter(_fullPathAndFileName, true);
            _tw.Write("\n");
            _tw.Close();

        }

        private void Start()
        {
            _fullPathAndFileName = Application.persistentDataPath + fileNameAndPath; 
           
        }
        
        

    }
}
