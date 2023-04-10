
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class SphereController : MonoBehaviour
{
    [SerializeField]private float _weight; //для просмотра
    
   [SerializeField] private float num; // для тестов без клавиатуры

   [SerializeField] private Transform up;
   [SerializeField] private Transform down;
   [SerializeField] private Transform target;
   [SerializeField] private float speed;

   [SerializeField] private float minScale;
   [SerializeField] private float maxScale;

   private void Start()
   {
      _weight = Random.Range(15,85);
      var i = Remap(_weight, 15, 85, minScale, maxScale);
      target.transform.localScale = new Vector3(i,i,i);
      num = _weight - 99;
   }

   public void SetNum(int i)
   {
      num = i;
   }

   private void Update()
   {
      var i =  _weight - num;

      
      var posIdeal = ((up.localPosition.y - down.localPosition.y) / 100) * i;
      var position = target.localPosition;
      var posY =Mathf.Lerp(position.y ,posIdeal , speed);

      var colIdeal = Color.blue;
      if (i >= 0 && i <= 25)
      {
         colIdeal = Color.green;
      }

      if (i >= 25 && i <= 50)
      {
         colIdeal = Color.yellow;
      }
      if (i >= 50 && i <= 99)
      {
         colIdeal = Color.red;
      }
      if (i >= 99 && i <= 100)
      {
         colIdeal = Color.black;
      }
      
      
      if (i <= 0 && i >= -25)
      {
         colIdeal = Color.green;
      }

      if (i <= -25 && i >= -50)
      {
         colIdeal = Color.yellow;
      }
      if (i <= -50 && i >= -99)
      {
         colIdeal = Color.red;
      }
      if (i <= -99 && i >= -100)
      {
         colIdeal = Color.black;
      }


      var color = target.gameObject.GetComponent<Renderer>().materials[0].GetColor("_MainColor");
      
      target.gameObject.GetComponent<Renderer>().materials[0].SetColor("_MainColor",Color.Lerp( color,colIdeal, speed));
      target.localPosition = new Vector3(position.x,posY,position.x);
   }
   
   public static float Remap ( float value, float from1, float to1, float from2, float to2) {
      return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
   }
}
