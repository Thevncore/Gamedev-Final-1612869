using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundChecker : MonoBehaviour
{
    Bounds worldBound;

    // Start is called before the first frame update
    void Start()
    {
        //var world = GameObject.FindWithTag("WorldBounds");
        //var renderer = world.GetComponent<Renderer>();
        //worldBound = renderer.bounds;
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!worldBound.Contains(transform.position))
        //    Destroy(this.gameObject, 5);
    }
}
