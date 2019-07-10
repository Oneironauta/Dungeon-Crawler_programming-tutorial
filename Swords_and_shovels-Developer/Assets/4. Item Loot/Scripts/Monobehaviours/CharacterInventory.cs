using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    #region Variable Declarations
    public static CharacterInventory instance;
    #endregion

    #region Initializations
    void Start()
    {
        instance = this;
    }
    #endregion

    //Si se necesita saber si el Item fue agregado con éxito, 
    //se debe cambiar el valor de retorno a bool
    public void StoreItem(ItemPickUp ItemToStore){

    }
}