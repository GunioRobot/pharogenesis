enableDrop: aBoolean
	super enableDrop: aBoolean.
	aBoolean ifTrue: [self installEventHandlerOn: scroller submorphs]