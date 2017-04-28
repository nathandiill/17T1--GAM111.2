using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseCommand
{
    public bool HasStarted {get;set;}
    
    abstract public void Start();
    abstract public void Update();
    abstract public bool IsFinished();
}
