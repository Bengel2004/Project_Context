using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Organism : MonoBehaviour
{
    [SerializeField]
    protected OrganismObj thisObj;
    public OrganismObj thisOrganism { get { return thisObj; } }

    public bool isPlayed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isPlayed)
        {
            ExecuteBehaviour();
        }
        else
        {
            Move();
        }
    }

    protected virtual void Move()
    {

    }

    protected virtual void ExecuteBehaviour()
    {

    }

    public virtual void ChooseOrganism()
    {
        // on action this becomes either playable or an unplayable object
        isPlayed = !isPlayed;
    }
}
