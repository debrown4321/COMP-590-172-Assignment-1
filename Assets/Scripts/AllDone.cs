using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDone : MonoBehaviour
{
    bool allDone;
    public GameObject white, black, blue, red, yellow;

    // Start is called before the first frame update
    void Start()
    {
        allDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        allDone = white.GetComponent<MeshRenderer>().enabled == true &&
            black.GetComponent<MeshRenderer>().enabled == true &&
            blue.GetComponent<MeshRenderer>().enabled == true &&
            red.GetComponent<MeshRenderer>().enabled == true &&
            yellow.GetComponent<MeshRenderer>().enabled == true;
    }

    public bool CheckDone()
    {
        return allDone;
    }
}
