using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject
{
    [SerializeField] string abilityName;
    public float cooldown;
    [HideInInspector] public float elapsedCooldown = 0f;
    protected bool isCooldown = false;
   
    protected Transform transform;
    [SerializeField] protected Image abilityIcon;

    public abstract void Trigger(Vector3 direction, MonoBehaviour mbCoroutine);

    public abstract void Transform(Transform player);


    protected IEnumerator cooldownCouroutine()
    {
        isCooldown = true;
        elapsedCooldown = 0f;

        while (elapsedCooldown <= cooldown)
        {
            elapsedCooldown += Time.deltaTime;
            yield return null;  
        }

        isCooldown = false;
    }

}
