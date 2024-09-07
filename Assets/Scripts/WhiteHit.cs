using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHit : MonoBehaviour
{

    MeshRenderer meshRend;
    public GameObject black, blue, red, yellow;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (meshRend.enabled == true)
        {

        } else
        {
            Debug.Log("Yay it hit white!");
            meshRend.enabled = true;
            black.GetComponent<MeshCollider>().enabled = false;
            blue.GetComponent<MeshCollider>().enabled = false;
            red.GetComponent<MeshCollider>().enabled = false;
            yellow.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(ReinableMeshes());
        }

    }

    IEnumerator ReinableMeshes()
    {
        yield return new WaitForSeconds(.5f);
        yellow.GetComponent<MeshCollider>().enabled = true;
        blue.GetComponent<MeshCollider>().enabled = true;
        red.GetComponent<MeshCollider>().enabled = true;
        black.GetComponent<MeshCollider>().enabled = true;
    }

    public void Reset()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yellow.GetComponent<MeshRenderer>().enabled = false;
        blue.GetComponent<MeshRenderer>().enabled = false;
        red.GetComponent<MeshRenderer>().enabled = false;
        black.GetComponent<MeshRenderer>().enabled = false;
    }
}
