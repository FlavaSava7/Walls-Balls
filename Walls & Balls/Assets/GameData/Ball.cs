using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Ball")]
public class Ball : ScriptableObject {
    public new string name;
    public int speed;
    public int damage;
    public int hp;
    public int points;
    public BallType type;
}
