copy

	| obj |
	obj _ super copy.
	obj lastScriptEditor: obj lastAcceptedScript.	
		"lastScriptEditor would not have been copied, as it is owned by the world, not me.  Can't allow mine to creep into the copy." 
	^ obj