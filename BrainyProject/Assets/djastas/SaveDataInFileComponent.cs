using System;
using System.IO;
using UnityEngine;

namespace Pixelcrew
{
    public class SaveDataInFileComponent : MonoBehaviour
    {
        private TextWriter _tw; 
        private string _fullPathAndFileName;
        

        [SerializeField] private string fileNameAndPath = "/test.csv";
        
        

        
        [ContextMenu("write")]
        public void WriteCsv(string i)
        {
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
            _fullPathAndFileName = Application.dataPath + fileNameAndPath; 
           
        }


        
        
     

        //[SerializeField] private TextAsset textAssetForRead;
        // public PlayerList playerList = new PlayerList();
        // [ContextMenu("read")]
        // public void ReadCvs()
        // {
        //     string[] data = textAssetForRead.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);
        //     int tableSize = data.Length / 2 - 1;
        //     playerList.players = new Player[tableSize];
        //     for (int i = 0; i < tableSize; i++)
        //     {
        //         playerList.players[i] = new Player();
        //         playerList.players[i].name = data[2* (i + 1)];
        //         playerList.players[i].rer = data[2* (i + 1 ) + 1];
        //     }
        // } не используемый метод

        
        
        // не используемый класс
        public class Player
        {
            public string name;
            public string rer;
        }
        
        [Serializable]
        public class PlayerList
        {
            public Player[] players;
        }

    }
}
