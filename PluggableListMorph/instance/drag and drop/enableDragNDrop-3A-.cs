enableDragNDrop: aBoolean
	super enableDragNDrop: aBoolean.
	aBoolean ifTrue: [self installEventHandlerOn: scroller submorphs]