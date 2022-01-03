using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuildingController : MonoBehaviour
{
    [SerializeField] Transform headTransform;
    [SerializeField] GameObject block;
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
        Vector3 newBlockPosition = Vector3.down;

        RaycastHit hit;

        LayerMask defaultLayerMask = LayerMask.GetMask(new string[] { "Default" });
        LayerMask entityLayerMask = LayerMask.GetMask(new string[] { "Entity" });

        if (Physics.Raycast(headTransform.position, headTransform.forward, out hit, 3, defaultLayerMask))
        {
            Vector3 hitPlace = hit.point + hit.normal / 2;
            newBlockPosition = new Vector3(Mathf.Floor(hitPlace.x) + 0.5f, Mathf.Floor(hitPlace.y) + 0.5f, Mathf.Floor(hitPlace.z) + 0.5f);
            if (Physics.CheckBox(newBlockPosition, Vector3.one * 0.25f, Quaternion.identity, entityLayerMask))
            {
                newBlockPosition = Vector3.down;
            }

        }

        if (newBlockPosition != Vector3.down)
        {
            indicator.transform.position = newBlockPosition;
            indicator.SetActive(true);
        }
        else
            indicator.SetActive(false);


        if (Input.GetMouseButtonDown(1) && newBlockPosition != Vector3.down)
        {
            Instantiate(block, newBlockPosition, Quaternion.identity);
        }
    }
}
