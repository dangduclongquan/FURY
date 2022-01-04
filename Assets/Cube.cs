using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    static GameObject prefab = (GameObject)Resources.Load("Cube");

    GameObject gameObject;
    public Cube(Vector3Int position)
    {
        gameObject = GameObject.Instantiate(prefab, position+Vector3.one*0.5f, Quaternion.identity);
    }
    public Vector3Int position
    {
        get
        {
            return Vector3Int.FloorToInt(gameObject.transform.position);
        }
        set
        {
            gameObject.transform.position = value + Vector3.one * 0.5f;
        }
    }
}
