using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Bullet")]
public class Bullet : ScriptableObject {
    public new string name;
    public float speed;
    public int damage;
}
