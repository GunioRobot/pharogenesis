clear: clearButton with: clearSelector

	| ss |
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss clear]
		ifNil: [self notCurrentlyPainting].
	clearButton state: #off.