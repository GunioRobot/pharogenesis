arrowSetterButtonFor: partName type: partType

	| m |
	m _ RectangleMorph new
		color: (TilePadMorph colorForType: #command);
		extent: 24@TileMorph defaultH;
		borderWidth: 1.
	m addMorphCentered: (ImageMorph new image: (ScriptingSystem formAtKey: 'Gets')).
	m on: #mouseDown send: #makeSetter:from:forPart:
		to: self
		withValue: (Array with: partName with: partType).
	^ m
