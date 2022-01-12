using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletDetailsList", menuName = "Assets/Scriptable Objects/Bullet/BulletDetailsList.asset")]
public class SO_bulletDetailsList : ScriptableObject
{
    [SerializeField] public List<bulletDetails> bulletDetails;

    public bulletDetails GetBulletDetailsByName(string bulletName)
    {
        return bulletDetails.Find(x => x.bulletName == bulletName);
    }
}
