isControlActive 
	super isControlActive ifTrue: [^ true].
	sensor blueButtonPressed ifTrue: [^ false].
	^ (scrollBar inside merge: view insetDisplayBox) containsPoint: sensor cursorPoint