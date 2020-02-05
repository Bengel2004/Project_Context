using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Organism : MonoBehaviour
{
    [SerializeField]
    protected OrganismObj thisObj;
    public OrganismObj thisOrganism { get { return thisObj; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }
}
