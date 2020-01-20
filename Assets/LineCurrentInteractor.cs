using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCurrentInteractor : MonoBehaviour, IInteractor
{

    public bool Inverse = false;
    public float Strength = 50.0f;

    public Vector3 Interact(Vector3 position)
    {
        var c = GetComponent<Collider>();
        var d = c.ClosestPoint(position) - position;

        float invDistance = 1 / d.sqrMagnitude;
        Vector3 r = new Vector3(
            -d.z / (d.x * d.x + d.z * d.z),
            0,
            d.x / (d.x * d.x + d.z * d.z));
        return Strength * invDistance * r.normalized * (Inverse ? -1 : 1);
    }

    public Vector3 InteractA(Vector3 position)
    {
        var c = GetComponent<Collider>();
        var d = c.ClosestPoint(position) - position;
        var e = new Vector2(d.x, d.z);
        var m = 1 / (e.sqrMagnitude);
        return m * Mathf.Sqrt(Strength) * new Vector3(0, Inverse ? -1 : 1, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
