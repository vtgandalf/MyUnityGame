using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceList : MonoBehaviour {
    private Resource gold = new Resource("gold");
    private Resource wood = new Resource("wood");
	// Use this for initialization
	public Resource Gold
    {
        get { return this.gold; }
    }
    public Resource Wood
    {
        get { return this.gold; }
    }
}
