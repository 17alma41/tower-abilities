using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    bool playerIsDead = false;

    [SerializeField] List<Ability> abilities;
    int selectedAbilityIndex = 0;

    [SerializeField] Image[] selectionBackground;
    [SerializeField] List<Image> abilityIcon;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i].Transform(transform);
        }

        GameEvents.PlayerDead.AddListener(OnPlayerDeath);
    }

    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                selectedAbilityIndex = 0;
            if (Input.GetKeyDown(KeyCode.Alpha2))
                selectedAbilityIndex = 1;
            if (Input.GetKeyDown(KeyCode.Alpha3))
                selectedAbilityIndex = 2;
            if (Input.GetKeyDown(KeyCode.Alpha4))
                selectedAbilityIndex = 3;
            if (Input.GetKeyDown(KeyCode.Alpha5))
                selectedAbilityIndex = 4;

            Vector3 mousePos = new Vector3(0, 0, 0);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 targetDir = (mousePos - transform.position).normalized;
            float angle = Vector3.SignedAngle (Vector3.up, targetDir, Vector3.forward);
            transform.rotation = Quaternion.Euler(0, 0, angle);

            if (Input.GetMouseButtonDown(0))
            {
                Image selectedIcon = abilityIcon[selectedAbilityIndex];

                print("using " + abilities[selectedAbilityIndex].name);
                abilities[selectedAbilityIndex].Trigger(targetDir, this, abilityIcon);

                //Tiene fallos!!
                StartCoroutine(abilities[selectedAbilityIndex].cooldownCouroutine(selectedIcon));
            }
        }


        //La selección para cada índice de habilidad
        for (int i = 0; i < abilities.Count; i++)
        {
            if (i == selectedAbilityIndex)
            {
                if (selectionBackground[i] != null)
                    selectionBackground[i].gameObject.SetActive(true);
            }
            else
            {
                selectionBackground[i].gameObject.SetActive(false);
            }
        }

    }
}
