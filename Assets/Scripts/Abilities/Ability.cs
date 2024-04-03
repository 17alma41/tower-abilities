using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField] string abilityName;
    public float cooldown;
    [HideInInspector] public float elapsedCooldown = 0f;
    protected bool isCooldown = false;
   
    protected Transform transform;
    public abstract void Trigger(Vector3 direction, MonoBehaviour mbCoroutine);

    public abstract void Transform(Transform player);


    //public Coroutine StartCoroutine(IEnumerator routine);

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
