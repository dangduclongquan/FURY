using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamageReceivedEvent : UnityEvent<float>
{
    
}

[System.Serializable]
public class EntityDyingEvent : UnityEvent
{

}

public class Health : MonoBehaviour
{
    public float maxHp;
    [SerializeField] float _hp;
    public float hp
    {
        get
        {
            return _hp;
        }
    }

    public DamageReceivedEvent damageReceivedEvent = new DamageReceivedEvent();
    public EntityDyingEvent entityDyingEvent = new EntityDyingEvent();

    public void DealDamage(float damage)
    {
        _hp -= damage;
        damageReceivedEvent.Invoke(damage);
        if(_hp<=0)
        {
            entityDyingEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
