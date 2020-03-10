using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCenter : MonoBehaviour
{
    public static ZoomCenter instance;

    public List<GameObject> AnimalTypes;
    public List<GameObject> SafeAnimalTypes;

    public List<GameObject> AnimalTypesWarehouse;

    void Awake() {
        instance = this;
        AnimalTypesWarehouse = new List<GameObject>(AnimalTypes);
    }

    public GameObject GetRandomAnimal(){
        GameObject result = AnimalTypesWarehouse[Random.Range(0, AnimalTypesWarehouse.Count)];
        AnimalTypesWarehouse.Remove(result);
        if(AnimalTypesWarehouse.Count == 0){
            AnimalTypesWarehouse = new List<GameObject>(AnimalTypes);
        }

        return result;
    }
}

public static class ExtentTransform {
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;

            foreach(Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }
}