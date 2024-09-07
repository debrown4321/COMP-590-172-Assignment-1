using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHit : MonoBehaviour
{
    MeshRenderer meshRend;
    public GameObject black, white, red, yellow;
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

        }
        else
        {
            Debug.Log("Yay it hit blue!");
            meshRend.enabled = true;
            black.GetComponent<MeshCollider>().enabled = false;
            yellow.GetComponent<MeshCollider>().enabled = false;
            red.GetComponent<MeshCollider>().enabled = false;
            white.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(ReinableMeshes());
        }
    }

    IEnumerator ReinableMeshes()
    {
        yield return new WaitForSeconds(.5f);
        yellow.GetComponent<MeshCollider>().enabled = true;
        black.GetComponent<MeshCollider>().enabled = true;
        red.GetComponent<MeshCollider>().enabled = true;
        white.GetComponent<MeshCollider>().enabled = true;
    }
}
