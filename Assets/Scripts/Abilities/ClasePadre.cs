using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClasePadre : MonoBehaviour
{
    [SerializeField] string abilityName;
    public float cooldown;
    protected float elapsedCooldown = 0f;
    protected bool isCooldown = false;

    public abstract void Trigger(Vector3 direction);
   
    protected void StartCooldown()
    {
        isCooldown = true;
        elapsedCooldown = 0f;
        StartCoroutine(cooldownCouroutine());
    }

    public IEnumerator cooldownCouroutine()
    {
        while (elapsedCooldown <= cooldown)
        {
            elapsedCooldown += Time.deltaTime;
            yield return null;  
        }

        isCooldown = false;
    }

}
