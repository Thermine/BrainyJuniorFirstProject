using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGame : MonoBehaviour
{
    public Material _red;
    public Material _yellow;
    public Material _green;

    private bool IsTrueColor = false;

    private void Start()
    {
        StartCoroutine(ChangingColor());
    }

    public void OnTriggerStay(Collider other)
    {
        if((this.gameObject.CompareTag("Ball") && other.gameObject.CompareTag("Player")) && (IsTrueColor == true))
        {
                Destroy(this.gameObject);
        }
    }

    IEnumerator ChangingColor()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        this.gameObject.GetComponent<Renderer>().material = _red;
        IsTrueColor = false;
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        this.gameObject.GetComponent<Renderer>().material = _yellow;
        IsTrueColor = false;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        this.gameObject.GetComponent<Renderer>().material = _green;
        IsTrueColor = true;
        StartCoroutine(ChangingColor());
    }
}
