using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager instance;
    public Transform rotator;
    public GameObject gun1;
    public GameObject gun2;

    private bool flagGun1;

    void Awake()
    {
        instance = this;
        gun1 = rotator.transform.GetChild(0).gameObject;
        gun2 = rotator.transform.GetChild(1).gameObject;
        flagGun1 = true;
    }

    public void GunSwap()
    {
        if (flagGun1)
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            flagGun1 = !flagGun1;
        }
        else
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            flagGun1 = !flagGun1;
        }
    }

}
