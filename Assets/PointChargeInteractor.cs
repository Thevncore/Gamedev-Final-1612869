using UnityEngine;

public class PointChargeInteractor : MonoBehaviour, IInteractor
{
    public float Strength = 50.0f;
    public bool Inverse = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //
    public Vector3 Interact(Vector3 position)
    {
        Vector3 d = position - transform.position;
        float invDistance = 1 / d.sqrMagnitude;
        Vector3 r = new Vector3(
            -d.z / (d.x * d.x + d.z * d.z),
            0,
            d.x / (d.x * d.x + d.z * d.z));
        return Strength * invDistance * r.normalized * (Inverse ? -1 : 1);
    }

    Vector3 IInteractor.InteractA(Vector3 position)
    {
        var c = GetComponent<Collider>();
        var d = c.ClosestPoint(position) - position;
        var m = 1 / (d.sqrMagnitude);
        return m * Mathf.Sqrt(Strength) * new Vector3(0, Inverse?-1:1, 0);
    }
}
