revertScriptVersionFrom: anEditor
	| aMenu result aPosition oldOwner |
	formerScriptEditors isEmptyOrNil ifTrue: [^ self beep].
	aMenu _ SelectionMenu labelList: (formerScriptEditors collect: [:e | e timeStamp])
		selections: formerScriptEditors.
	result _ aMenu startUp.
	result ifNotNil:
		[aPosition _ anEditor position.
		oldOwner _ anEditor topRendererOrSelf owner.
		anEditor delete.
		currentScriptEditor _ result bringUpToDate install.
		player costume viewAfreshIn: oldOwner showingScript: selector at: aPosition]