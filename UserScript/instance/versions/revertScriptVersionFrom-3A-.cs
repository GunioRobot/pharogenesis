revertScriptVersionFrom: anEditor
	| aMenu result aPosition |
	formerScriptEditors size == 0 ifTrue: [^ self beep].
	aMenu _ SelectionMenu labelList: (formerScriptEditors collect: [:e | e timeStamp])
		selections: formerScriptEditors.
	result _ aMenu startUp.
	result ifNotNil:
		[aPosition _ anEditor position.
		anEditor delete.
		currentScriptEditor _ result bringUpToDate install.
		player costume viewAfreshShowingScript: selector at: aPosition]