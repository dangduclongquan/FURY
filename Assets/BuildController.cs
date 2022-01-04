using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] Transform headTransform;
    //[SerializeField] GameObject block;
    [SerializeField] GameObject blockIndicator;
    GameObject indicator;

    // Start is called before the first frame update
    void Awake()
    {
        indicator = Instantiate(blockIndicator, Vector3.down, Quaternion.identity);
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int newBlockPosition = Vector3Int.down;

        RaycastHit hit;

        LayerMask defaultLayerMask = LayerMask.GetMask(new string[] { "Default" });
        LayerMask entityLayerMask = LayerMask.GetMask(new string[] { "Entity" });

        if (Physics.Raycast(headTransform.position, headTransform.forward, out hit, 3, defaultLayerMask))
        {
            Vector3 hitPlace = hit.point + hit.normal / 2;
            newBlockPosition = Vector3Int.FloorToInt(hitPlace);
            if (Physics.CheckBox(newBlockPosition, Vector3.one * 0.25f, Quaternion.identity, entityLayerMask))
            {
                newBlockPosition = Vector3Int.down;
            }

        }

        if (newBlockPosition != Vector3.down)
        {
            indicator.transform.position = newBlockPosition+Vector3.one*0.5f;
            indicator.SetActive(true);
        }
        else
            indicator.SetActive(false);


        if (Input.GetMouseButtonDown(1) && newBlockPosition != Vector3.down)
        {
            new Cube(newBlockPosition);
        }
    }
}
