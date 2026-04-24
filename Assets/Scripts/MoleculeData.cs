using UnityEngine;

[CreateAssetMenu(fileName = "Molecule", menuName = "XR/Molecule")]
public class MoleculeData : ScriptableObject
{
    public string moleculeName;
    public string formula;

    public int hydrogen;
    public int oxygen;
    public int carbon;
    public int nitrogen;

    public BondType bondType;

    public GameObject moleculePrefab;
    public AudioClip successSound;
}