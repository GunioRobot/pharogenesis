privateMoveBy: delta

	editor == nil
		ifTrue: [super privateMoveBy: delta.
				paragraph ifNotNil: [paragraph moveBy: delta]]
		ifFalse: ["When moving text with an active editor, save and restore all state."
				super privateMoveBy: delta.
				paragraph moveBy: delta.
				self installEditorToReplace: editor]
