using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseHija2 : ClasePadre
{
    public override void Trigger(Vector3 direction)
    {
        print("Clase Hija 2 heredado de Clase Padre");
    }
}
