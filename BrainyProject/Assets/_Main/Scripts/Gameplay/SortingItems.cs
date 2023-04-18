using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingItems : MonoBehaviour
{
    [SerializeField] private int _metalCount;
    [SerializeField] private int _glassCount;
    [SerializeField] private GameObject _metalCase;
    [SerializeField] private GameObject _glassCase;
    [SerializeField] private GameObject _finalResponse;

    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.CompareTag("MetalZone") && other.gameObject.CompareTag("Metal"))
        {
            _metalCount++;
            if(_metalCount >= 5)
            {
                Destroy(_metalCase);
            }
            Destroy(other.gameObject);
        }
        if(this.gameObject.CompareTag("GlassZone") && other.gameObject.CompareTag("Glass"))
        {
            _glassCount++;
            if(_glassCount >= 2)
            {
                Destroy(_glassCase);
            }
            Destroy(other.gameObject);
            _finalResponse.SetActive(true);
        }
    }
}
