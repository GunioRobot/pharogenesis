acceptScript: aScriptEditorMorph for: aSelector

	| classif |
	classif _ aScriptEditorMorph isAnonymous ifTrue: ['anonymous scripts'] ifFalse: ['named scripts'].
	self class
		compileUnlogged: aScriptEditorMorph methodString
		classified: classif
		notifying: nil.
	self class atSelector: aSelector putScriptEditor: aScriptEditorMorph