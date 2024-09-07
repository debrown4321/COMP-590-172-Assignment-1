using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHit : MonoBehaviour
{
    MeshRenderer meshRend;
    public GameObject white, blue, red, yellow;
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
            Debug.Log("Yay it hit black!");
            meshRend.enabled = true;
            yellow.GetComponent<MeshCollider>().enabled = false;
            blue.GetComponent<MeshCollider>().enabled = false;
            red.GetComponent<MeshCollider>().enabled = false;
            white.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(ReinableMeshes());
        }
    }

    IEnumerator ReinableMeshes()
    {
        yield return new WaitForSeconds(.5f);
        yellow.GetComponent<MeshCollider>().enabled = true;
        blue.GetComponent<MeshCollider>().enabled = true;
        red.GetComponent<MeshCollider>().enabled = true;
        white.GetComponent<MeshCollider>().enabled = true;
    }
}
