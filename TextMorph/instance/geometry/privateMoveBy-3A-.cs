privateMoveBy: delta 
	super privateMoveBy: delta.
	editor isNil 
		ifTrue: [paragraph ifNotNil: [paragraph moveBy: delta]]
		ifFalse: 
			["When moving text with an active editor, save and restore all state."

			paragraph moveBy: delta.
			self installEditorToReplace: editor]