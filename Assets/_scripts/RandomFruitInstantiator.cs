using System.Collections.Generic;
using UnityEngine;

public class RandomFruitInstantiator : MonoBehaviour
{
    public List<GameObject> fruitList;

    private void Start()
    {
        // Instanciation aléatoire d'un objet de la liste
        int randomIndex = Random.Range(0, fruitList.Count);
        GameObject randomObject = fruitList[randomIndex];
        Instantiate(randomObject, transform.position, Quaternion.identity, transform);
    }
}
