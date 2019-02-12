﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public CharacterStats_SO characterDefinition;
	public CharacterInventory charInv;
	public GameObject characterWeaponSlot;

	#region Constructors
	public CharacterStats(){
		charInv = CharacterInventory.instance; 
	}
	#endregion

	#region Initialization
	void Start(){
		if (!characterDefinition.setManually)
		{
			characterDefinition.maxHealth = 100;
			characterDefinition.currentHealth = 50;

			characterDefinition.maxMana = 25;
			characterDefinition.currentMana = 10;

			characterDefinition.maxWealth = 500;
			characterDefinition.currentWealth = 0;

			characterDefinition.baseDamage = 2;
			characterDefinition.currentDamage = characterDefinition.baseDamage;

			characterDefinition.baseResistance = 0;
			characterDefinition.currentResistance = 0;

			characterDefinition.maxEncumbrance = 50f;
			characterDefinition.currentEncumbrance = 0f;

			characterDefinition.charExperience = 0;
			characterDefinition.charLevel = 1;
		}
	}
	#endregion

	#region Save Data
		private void Update(){
			//Este método debe ser detonado por el GameManager
			//provisionalemente lo asignamos al scrollweel
			if (Input.GetMouseButtonDown(2))
			{
				characterDefinition.saveCharacterData();
			}
		}
	#endregion

	#region Stat Increasers
		public void ApplyHealth(int healthAmount){
			characterDefinition.ApplyHealth(healthAmount);
		}
		
		public void ApplyMana(int manaAmount){
			characterDefinition.ApplyHealth(manaAmount);
		}

		public void GiveWealth(int wealthAmount){
			characterDefinition.ApplyHealth(wealthAmount);
		}
	#endregion

	#region Weapon and Armor Change
		public void CangeWeapon(ItemPickUp weaponPickUp){
			if (!characterDefinition.UnEquipWeapon(weaponPickUp, charInv, characterWeaponSlot))
			{
				characterDefinition.EquipWeapon(weaponPickUp, charInv, characterWeaponSlot);
			}
		}

		public void ChangeArmor(ItemPickUp armorPickUp){
			if (!characterDefinition.UnEquipArmor(armorPickUp, charInv))
			{
				characterDefinition.EquipArmor(armorPickUp, charInv);
			}
		}
	#endregion

	#region Stat Reducers
		public void TakeDamage(int amount){
			characterDefinition.TakeDamage(amount);
		}

		public void TakeMana(int amount){
			characterDefinition.TakeMana(amount);
		}
	#endregion

	#region Reporters
		public int GetHealth(){
			return characterDefinition.currentHealth;
		}

		public ItemPickUp GetCurrentWeapon(){
			return characterDefinition.weapon;
		}
	#endregion

}
