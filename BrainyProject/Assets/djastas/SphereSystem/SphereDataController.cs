using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pixelcrew;
using UnityEngine;
using UnityEngine.Events;

namespace djastas
{
   public class SphereDataController : MonoBehaviour
   {
      [SerializeField] private SphereController[] sphereControllers;
      [SerializeField] private FakeSphere[] fakeSphereControllers;
      
      [SerializeField] private StringAction sendWeight; // unityEvent который отправляет в SaveDataInFileComponent вес шаров
      

      private List<string> GetData()
      {
         List<string> data = new List<string>();
         
         foreach (var sphereController in sphereControllers)
         {
            var i = (sphereController.weight - sphereController.expectedWeight).ToString(CultureInfo.InvariantCulture);
            data = data.Append(i).ToList();
         }

         foreach (var fakeSphere in fakeSphereControllers)
         {
            var i = fakeSphere.stopwatchComponent.time;
            data = data.Append(i.ToString(CultureInfo.InvariantCulture)).ToList();
         }

         return data;
      }
      
      
      [ContextMenu("Test")]
      public void SendData()
      {
         var weightList = GetData();
         foreach (var i in weightList)
         {
            sendWeight.Invoke(i);
         }
         

      }
      
      
      
      [Serializable]
      class StringAction : UnityEvent<string>
      {
         
      }
   }
}
