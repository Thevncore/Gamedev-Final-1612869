using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject prefabToCreate;
    Bounds worldBound;
    GameObject[] spheres;
    IInteractor[] sphereInteractors;

    // Start is called before the first frame update
    void Start()
    {
        worldBound = GameObject.FindWithTag("WorldBounds").GetComponent<Renderer>().bounds;
        Physics.gravity = new Vector3(0, 0, 0);
        InvokeRepeating("CreateCube", 0, 0.05f);

        spheres = GameObject.FindGameObjectsWithTag("Interactor");
        sphereInteractors = (from GameObject go in spheres select go.GetComponent<IInteractor>()).ToArray();

    }

    void CreateCube()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(
            prefabToCreate,
            //new Vector3(Random.value * 20 - 10, Random.value * 20 - 10, Random.value * 20), 
            new Vector3(Random.Range(worldBound.min.x, worldBound.max.x),
                        Random.Range(worldBound.min.y, worldBound.max.y),
                        Random.Range(worldBound.min.z, worldBound.max.z)),
            Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for (var x = worldBound.min.x; x < worldBound.max.x; x += worldBound.size.x / 10)
        //{
        //    for (var y = worldBound.min.y; y < worldBound.max.y; y += worldBound.size.y / 10)
        //    {
        //        for (var z = worldBound.min.x; z < worldBound.max.z; z += worldBound.size.z / 10)
        //        {
        //            Vector3 pos = new Vector3(x, y, z);
        //            foreach (var sphereInteractor in sphereInteractors)
        //            {
        //                DrawArrow.ForDebug(pos, sphereInteractor.Interact(pos), new Color32(255, 255, 255, 64));
        //            }
        //            //DrawArrow.ForDebug(pos, sphereInteractor.Interact(pos), new Color32(255, 255, 255, 64));
        //        }
        //    }
        //}

        //foreach (var sphere in spheres)
        //{
        //    DrawArrow.ForDebug(sphere.transform.position, Vector3.up * 5, Color.yellow);
        //}
    }
}
