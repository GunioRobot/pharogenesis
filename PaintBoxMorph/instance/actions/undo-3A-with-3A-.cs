undo: undoButton with: undoSelector

	| ss |
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss undo]
		ifNil: [PopUpMenu notify: 
			'You are currently not painting.  Choose 
Parts and drag out a new object.'
			"Later have to change this for no EToy"].
	undoButton state: #off.