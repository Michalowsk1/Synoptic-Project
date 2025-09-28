using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Upgrades : MonoBehaviour
{

    int DamageUpgradeCost = 10;
    int ArmourUpgradeCost = 10;
    int HealingUpgradeCost = 10;

    int hpupgradeCount = 0;

    [SerializeField] TextMeshProUGUI damageCost;
    [SerializeField] TextMeshProUGUI armourCost;
    [SerializeField] TextMeshProUGUI HealingCost;
    public void DamageUpgrade()
    {
        if (Player.crystalCount >= DamageUpgradeCost)
        {
            Player.crystalCount -= DamageUpgradeCost;
            Player.dmg = Player.dmg * 2;
            DamageUpgradeCost = DamageUpgradeCost + 15;
            damageCost.text = "x " + DamageUpgradeCost + " crystals";
        }
    }

    public void ArmourUpgrade()
    {

        if (Player.crystalCount >= ArmourUpgradeCost)
        {
            Player.crystalCount -= ArmourUpgradeCost;
            Player.armour = Player.armour * 1.25f;
            ArmourUpgradeCost = ArmourUpgradeCost + 20;
            armourCost.text = "x " + ArmourUpgradeCost + " crystals";
        }
    }

    public void HealingUpgrade()
    {
        if (Player.crystalCount >= HealingUpgradeCost)
        {

            if (hpupgradeCount >= 0 && hpupgradeCount <= 3)
            {
                Player.hpRecover = Player.hpRecover - 5;
                Player.crystalCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost + " crystals";
                hpupgradeCount++;
            }

            if (hpupgradeCount >= 3 && hpupgradeCount <= 6)
            {
                Player.hpRecover = Player.hpRecover - 3;
                Player.crystalCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost;
                hpupgradeCount++;
            }

            else if (hpupgradeCount >= 6 && hpupgradeCount < 8)
            {
                Player.hpRecover = Player.hpRecover - 2;
                Player.crystalCount -= HealingUpgradeCost;
                HealingUpgradeCost = HealingUpgradeCost + 50;
                HealingCost.text = "x " + HealingUpgradeCost;
                hpupgradeCount++;
            }

            else if (hpupgradeCount >= 8)
            {

            }


        }
    }
}
