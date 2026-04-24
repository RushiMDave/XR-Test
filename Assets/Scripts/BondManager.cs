using System;
using System.Collections.Generic;
using UnityEngine;

public class BondManager : MonoBehaviour
{
    [SerializeField]
    MoleculeDatabase database;
    [SerializeField]
    Transform moleculeSpawnPoint;

    private List<AtomController> currentCluster = new();
    Dictionary<AtomType, int> atomCounts = new();

    void Start()
    {
        foreach (AtomType atomType in Enum.GetValues(typeof(AtomType)))
        {
            atomCounts.Add(atomType, 0);
        }
    }

    public void TryBond(AtomController a, AtomController b)
    {
        if (!currentCluster.Contains(a)) currentCluster.Add(a);
        if (!currentCluster.Contains(b)) currentCluster.Add(b);

        UpdateCounts(currentCluster);
        var molecule = database.FindMatch(atomCounts);

        if (molecule != null)
        {
            SpawnMolecule(molecule);
            ClearCluster();
        }
    }

    Dictionary<AtomType, int> UpdateCounts(List<AtomController> atoms)
    {
        atomCounts.ResetAllValues(0);
        foreach (var atom in atoms)
        {
            atomCounts[atom.atomType]++;
        }

        return atomCounts;
    }

    void SpawnMolecule(MoleculeData molecule)
    {
        Instantiate(molecule.moleculePrefab, moleculeSpawnPoint.position, Quaternion.identity);
        AudioManager.Instance.Play(molecule.successSound);

        foreach (var atom in currentCluster)
        {
            Destroy(atom.gameObject);
        }
    }

    void ClearCluster()
    {
        currentCluster.Clear();
    }
}
public enum BondType
{
    Covalent,
    SingleCovalent,
    DoubleCovalent,
    TripleCovalent

}