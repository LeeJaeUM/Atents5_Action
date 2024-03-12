using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject weapons;
    [SerializeField]Transform weaponParent;
    [SerializeField] Transform shieldParent;
    private void Start()
    {
        weaponParent = FindChildRecursive(transform, "weapon_l");
        shieldParent = FindChildRecursive(transform, "weapon_r");
    }
    public void ShowWeaponAndShield(bool isShow = true)
    {
        weaponParent.gameObject.SetActive(isShow);
        shieldParent.gameObject.SetActive(isShow);
    }
    // 재귀적으로 자식을 검색하는 함수
    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }

            Transform found = FindChildRecursive(child, name);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }
}
