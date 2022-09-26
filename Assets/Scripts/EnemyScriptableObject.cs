using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy/Create new enemy", order = 51)]

public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;

    [SerializeField] private float _baseHealth;
    [SerializeField] private float _baseArmor;
    [SerializeField] private float _baseMoveSpeed;
    [SerializeField] private float _basePercentDamage;
    [SerializeField] private float _baseStartPercentScale;
    [SerializeField] private float _baseGrowTime;

    public Mesh Mesh => _mesh;
    public Material Material => _material;
    public float BaseHealth => _baseHealth;
    public float BaseArmor => _baseArmor;
    public float BaseMoveSpeed => _baseMoveSpeed;
    public float BasePercentDamage => _basePercentDamage;
    public float BaseStartPercentScale => _baseStartPercentScale;
    public float BaseGrowTime => _baseGrowTime;
}