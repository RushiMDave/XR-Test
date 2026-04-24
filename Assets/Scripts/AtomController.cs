using UnityEngine;


public class AtomController : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    public AtomType atomType;
    private BondManager bondManager;

    protected override void Awake()
    {
        base.Awake();
        bondManager = FindFirstObjectByType<BondManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AtomController otherAtom = other.GetComponent<AtomController>();
        if (otherAtom != null)
        {
            bondManager.TryBond(this, otherAtom);
        }
    }
}