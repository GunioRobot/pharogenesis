handleMouseMove: evt
	"Dispatch a mouseMove event."
	clickState ~~ #idle ifTrue: [self checkForDoubleClick: evt].

	mouseDownMorph ifNotNil:
		[mouseDownMorph mouseMove: (self transformEvent: evt)].

	submorphs isEmpty
		ifTrue: [evt anyButtonPressed
				ifTrue: [self handleDragOver: evt]
				ifFalse: [self handleMouseOver: evt]]
		ifFalse: [self handleDragOver: evt]