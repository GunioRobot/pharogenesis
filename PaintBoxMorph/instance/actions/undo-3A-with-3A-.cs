undo: undoButton with: undoSelector
	| ss |
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss undo]
		ifNil: [self notCurrentlyPainting].
	undoButton state: #off.