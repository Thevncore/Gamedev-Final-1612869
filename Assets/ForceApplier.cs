using System.Linq;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    GameObject[] spheres;
    IInteractor[] sphereInteractors;
    bool excluded = false;
    public float coefficient = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        spheres = GameObject.FindGameObjectsWithTag("Interactor");
        sphereInteractors = (from GameObject go in spheres select go.GetComponent<IInteractor>()).ToArray();
        Invoke("Die", 4);
    }

    void Die()
    {
        excluded = true;
    }

    // Update is called once per frame
    void Update()
    {
        var r = GetComponent<Rigidbody>();
        if (excluded)
        {
            r.velocity = Vector3.zero;
        }
        else
        {
            Vector3 aggregate = Vector3.zero;
            foreach (IInteractor i in sphereInteractors)
            {
                aggregate += i.Interact(transform.position);
            }

            if (float.IsNaN(aggregate.x)) aggregate.x = 0;
            if (float.IsNaN(aggregate.y)) aggregate.y = 0;
            if (float.IsNaN(aggregate.z)) aggregate.z = 0;

            r.velocity = aggregate;
        }
    }
}
