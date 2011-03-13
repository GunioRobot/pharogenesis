runAScript

	| d names reply |
	d _ self targetScriptDictionary.
	names _ d keys asSortedCollection.
	reply _ (SelectionMenu labelList: names selections: names) startUpWithCaption: 'Script to run?'.
	reply ifNil: [^ self].
	programmedMoves _ (d at: reply) veryDeepCopy.