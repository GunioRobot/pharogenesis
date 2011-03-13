initializeForPlayer: aPlayer afterShallowCopyFrom: aDonorUserScript
	player _ aPlayer.
	formerScriptEditors _ nil.
	aDonorUserScript isTextuallyCoded
		ifFalse:
			[currentScriptEditor _ currentScriptEditor fullCopy.
			currentScriptEditor playerScripted: aPlayer.
			currentScriptEditor donorActor: aDonorUserScript player ownActor: aPlayer]
	
	