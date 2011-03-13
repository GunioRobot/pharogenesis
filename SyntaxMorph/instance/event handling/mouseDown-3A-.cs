mouseDown: evt 
	| dup rootTile |
	evt yellowButtonPressed ifTrue: [^ self showMenu: evt].
	(rootTile _ self rootTile) isMethodNode ifTrue:
		[self currentSelectionDo:
			[:innerMorph :mouseDownLoc :outerMorph |
			(outerMorph notNil and: [self == innerMorph])
				ifTrue: ["Click on prior selection -- record click point."
						self setSelection: {self. evt cursorPoint. outerMorph}]
				ifFalse: ["A new selection sequence."
						self setSelection: {self. evt cursorPoint. nil}]].
		^ self].

	"Out in the world -- treat as a unit"
	rootTile isPartsDonor 
		ifTrue: [dup _ rootTile duplicate.
				dup setProperty: #beScript toValue: true]
		ifFalse: [dup _ rootTile].
	evt hand attachMorph: dup.
	^ dup align: dup topLeft with: evt hand position + self cursorBaseOffset.
