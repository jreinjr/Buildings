using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Resource", menuName ="Construction/Resource")]
public class Resource : ScriptableObject
{
    [ReadOnly] [SerializeField]
    private int _current;
    public float Current { get { return _current; } }

    /// <summary>
    /// Occurs when Resource changed.
    /// </summary>
    public event Action resourceChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="Resource" /> class.
    /// </summary>
    public Resource(int startingResource)
    {
        ChangeResource(startingResource);
    }

    /// <summary>
    /// Adds the Resource.
    /// </summary>
    /// <param name="increment">the change in Resource</param>
    public void AddResource(int increment)
    {
        ChangeResource(increment);
    }

    /// <summary>
    /// Method for trying to purchase, returns false for insufficient funds
    /// </summary>
    /// <returns><c>true</c>, if purchase was successful i.e. enough Resource <c>false</c> otherwise.</returns>
    public bool TryPurchase(int cost)
    {
        // Cannot afford this item
        if (!CanAfford(cost))
        {
            return false;
        }
        ChangeResource(-cost);
        return true;
    }

    /// <summary>
    /// Determines if the specified cost is affordable.
    /// </summary>
    /// <returns><c>true</c> if this cost is affordable; otherwise, <c>false</c>.</returns>
    public bool CanAfford(int cost)
    {
        return _current >= cost;
    }

    /// <summary>
    /// Changes the Resource.
    /// </summary>
    /// <param name="increment">the change in Resource</param>
    protected void ChangeResource(int increment)
    {
        if (increment != 0)
        {
            _current += increment;
            if (resourceChanged != null)
            {
                resourceChanged();
            }
        }
    }
}
