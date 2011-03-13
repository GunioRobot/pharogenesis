revertScriptVersionFrom: anEditor
	"Let user choose which prior tile version to revert to, and revert to it"

	| aMenu result |
	formerScriptEditors isEmptyOrNil ifTrue: [^ self beep].
	formerScriptEditors size == 1
		ifTrue:
			[result _ formerScriptEditors first]
		ifFalse:
			[aMenu _ SelectionMenu labelList: (formerScriptEditors collect: [:e | e timeStamp])
				selections: formerScriptEditors.
			result _ aMenu startUp].
	result ifNotNil:
		[self revertScriptVersionFrom: anEditor installing: result]