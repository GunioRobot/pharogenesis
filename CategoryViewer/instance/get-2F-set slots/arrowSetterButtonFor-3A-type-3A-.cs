arrowSetterButtonFor: partName type: partType

	| m |
	m _ RectangleMorph new
		color: (ScriptingSystem colorForType: #command);
		extent: 24@TileMorph defaultH;
		borderWidth: 0.
	m addMorphCentered: (ImageMorph new image: (ScriptingSystem formAtKey: 'Gets')).
	m setBalloonText: 'drag from here to obtain an assignment phrase.'.
	m on: #mouseDown send: #makeSetter:from:forPart:
		to: self
		withValue: (Array with: partName with: partType).
	^ m
