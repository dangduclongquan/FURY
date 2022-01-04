using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorController : MonoBehaviour
{
    [SerializeField] Health blockHealth;

    Material material;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        blockHealth.damageReceivedEvent.AddListener(OnDamageReceived);
    }

    void OnDamageReceived(float damage)
    {
        float healthRatio = blockHealth.hp / blockHealth.maxHp;
        material.color = new Color(healthRatio, healthRatio, healthRatio);
    }
}
