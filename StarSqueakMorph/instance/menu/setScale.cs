setScale

	| reply |
	reply := FillInTheBlank
		request: 'Set the number of pixels per patch (a number between 1 and 10)?'
		 initialAnswer: pixelsPerPatch printString.
	reply isEmpty ifTrue: [^ self].
	pixelsPerPatch := ((reply asNumber rounded) max: 1) min: 10.
	self changed.
	super extent: dimensions * pixelsPerPatch.
	self clearAll.  "be sure this is done once in case setup fails to do it"
	self setup.
	self startOver.
