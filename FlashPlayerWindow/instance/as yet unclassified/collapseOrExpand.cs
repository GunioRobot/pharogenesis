collapseOrExpand
	super collapseOrExpand.
	isCollapsed ifTrue:[
		startButton delete.
		stopButton delete.
		progress ifNotNil:[progress delete].
	] ifFalse:[
		self addMorph: startButton.
		self addMorph: stopButton.
		progress ifNotNil:[self addMorph: progress].
		self adjustBookControls.
	].