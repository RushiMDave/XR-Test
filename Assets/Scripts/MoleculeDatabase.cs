using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoleculeDatabase", menuName = "XR/MoleculeDatabase")]
public class MoleculeDatabase : ScriptableObject
{
    public List<MoleculeData> molecules;

    public MoleculeData FindMatch(Dictionary<AtomType, int> atomCounts)
    {
        foreach (var molecule in molecules)
        {
            if (molecule.hydrogen == Get(atomCounts, AtomType.H) &&
                molecule.oxygen == Get(atomCounts, AtomType.O) &&
                molecule.carbon == Get(atomCounts, AtomType.C) &&
                molecule.nitrogen == Get(atomCounts, AtomType.N))
            {
                return molecule;
            }
        }
        return null;
    }

    int Get(Dictionary<AtomType, int> dict, AtomType type)
    {
        return dict.ContainsKey(type) ? dict[type] : 0;
    }
}