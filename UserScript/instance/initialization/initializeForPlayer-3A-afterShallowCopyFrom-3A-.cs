initializeForPlayer: aPlayer afterShallowCopyFrom: aDonorUserScript
	player _ aPlayer.
	formerScriptEditors _ nil.
	aDonorUserScript isTextuallyCoded
		ifFalse:
			[currentScriptEditor _ currentScriptEditor fullCopy.
				"We have a rule that ScriptEditors can't have Players in them"
			currentScriptEditor playerScripted: aPlayer.
			currentScriptEditor donorActor: aDonorUserScript player ownActor: aPlayer]
	
	