using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/HeroConfig", order = 1)]
public class HeroConfig : ScriptableObject
{
    public float heroMoveSpeed = 4f;
    public float heroShootSpeed = 120f;
}