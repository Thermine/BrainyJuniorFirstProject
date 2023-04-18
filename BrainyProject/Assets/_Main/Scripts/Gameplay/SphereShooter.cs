using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR;
using HurricaneVR.Framework.Core.Player;
public class SphereShooter : MonoBehaviour
{
    Transform camera; // голова
    Vector3 ShootPosition; // позиция куда будет выстреливать сфера
    GameObject ShootingSphere; 
    public GameObject SpherePrefab; // префаб сферы
    public GameObject[] SpawnPivots; // случайные точки для спавна
    Transform currentPivot; // точка для спавна сферы
    public float ShootTime; // время подлета сферы
    public void PrepareToShoot()
    {        
        camera = GameObject.Find("Camera").transform;
        currentPivot = SpawnPivots[Random.Range(0, SpawnPivots.Length)].transform; // находим точку для спавна
        ShootPosition = camera.position; // фиксируем позицию для выстрела
        ShootingSphere = GameObject.Instantiate(SpherePrefab, currentPivot.position, Quaternion.identity); // спавним сферу
        StartCoroutine(Shoot(ShootTime, ShootPosition)); // стреляем
    }
    private IEnumerator Shoot(float time, Vector3 targetPosition)
    {
        Vector3 startPosition = ShootingSphere.transform.position;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0f;
        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / time);
            ShootingSphere.transform.position = Vector3.Lerp(startPosition, targetPosition, fraction);
            yield return null;
        }
        Destroy(ShootingSphere);
    }
}
