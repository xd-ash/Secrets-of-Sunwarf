﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XNode;

public class NPCDialogue : DialogueNodeBase 
{
	[Input(typeConstraint =TypeConstraint.Strict)] public bool entry;
	[Output(dynamicPortList = true, connectionType =ConnectionType.Override)] public int exit;

    public override string GetDialogueType {get { return "NPC"; } }

}