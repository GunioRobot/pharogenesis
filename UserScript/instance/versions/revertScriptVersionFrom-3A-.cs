revertScriptVersionFrom: anEditor 
	"Let user choose which prior tile version to revert to, and revert to it"

	| aMenu result |
	formerScriptEditors isEmptyOrNil ifTrue: [^Beeper beep].
	result := formerScriptEditors size == 1 
		ifTrue: [formerScriptEditors first]
		ifFalse: 
			[aMenu := SelectionMenu 
						labelList: (formerScriptEditors collect: [:e | e timeStamp])
						selections: formerScriptEditors.
			aMenu startUp].
	result 
		ifNotNil: [self revertScriptVersionFrom: anEditor installing: result]