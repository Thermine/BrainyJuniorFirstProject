using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace djastas
{
   public class SphereDataController : MonoBehaviour
   {
      [SerializeField] private SphereController[] sphereControllers;

      [ContextMenu("Test")]
      public void Test()
      {
         Debug.Log(GetData());
      }
      
      public List<string> GetData()
      {
         List<string> data = new List<string>();
         foreach (var sphereController in sphereControllers)
         {
            var i = sphereController.expectedWeight.ToString(CultureInfo.InvariantCulture);
            data = data.Append(i).ToList();
         }

         return data;
      }
   }
}
