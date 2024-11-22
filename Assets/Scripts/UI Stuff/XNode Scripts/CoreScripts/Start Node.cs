using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StartNode : CoreNode 
{
	[Output(connectionType = ConnectionType.Override)] public bool exit;
}