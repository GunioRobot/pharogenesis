clear: clearButton with: clearSelector

	| ss |
	(ss _ self world findA: SketchEditorMorph) 
		ifNotNil: [ss clear]
		ifNil: [PopUpMenu notify: 
			'You are currently not painting.  Choose 
Parts and drag out a new object.'
			"Later have to change this for no EToy"].
	clearButton state: #off.