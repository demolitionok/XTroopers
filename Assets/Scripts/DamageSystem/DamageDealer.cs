using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    private float dmgValue;
    
    public Damage DealDamage()
    {
        return new Damage
        {
            DmgValue = dmgValue
        };
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
