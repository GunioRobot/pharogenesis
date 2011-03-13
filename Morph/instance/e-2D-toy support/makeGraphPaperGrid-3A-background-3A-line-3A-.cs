makeGraphPaperGrid: smallGrid background: backColor line: lineColor

	| gridForm |
	gridForm _ self gridFormOrigin: 0@0 grid: smallGrid asPoint background: backColor line: lineColor.
	self color: gridForm.
	self world ifNotNil: [self world fullRepaintNeeded].
	self changed: #newColor.  "propagate to view"
