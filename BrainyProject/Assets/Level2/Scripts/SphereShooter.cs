using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR;
using HurricaneVR.Framework.Core.Player;
public class SphereShooter : MonoBehaviour
{
    Transform camera; // ������
    Vector3 ShootPosition; // ������� ���� ����� ������������ �����
    GameObject ShootingSphere; 
    public GameObject SpherePrefab; // ������ �����
    public GameObject[] SpawnPivots; // ��������� ����� ��� ������
    Transform currentPivot; // ����� ��� ������ �����
    public float ShootTime; // ����� ������� �����
    public void PrepareToShoot()
    {        
        camera = GameObject.Find("Camera").transform;
        currentPivot = SpawnPivots[Random.Range(0, SpawnPivots.Length)].transform; // ������� ����� ��� ������
        ShootPosition = camera.position; // ��������� ������� ��� ��������
        ShootingSphere = GameObject.Instantiate(SpherePrefab, currentPivot.position, Quaternion.identity); // ������� �����
        StartCoroutine(Shoot(ShootTime, ShootPosition)); // ��������
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
