acceptScript: aScriptEditorMorph for: aSelector

	| classif |
	classif _ aScriptEditorMorph isAnonymous ifTrue: ['anonymous scripts'] ifFalse: ['named scripts'].
	self class
		compile: aScriptEditorMorph methodString
		classified: classif
		notifying: nil.
	self class atSelector: aSelector putScriptEditor: aScriptEditorMorph