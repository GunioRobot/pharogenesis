arrowSetterButton: sel args: argArray

	| m |
	m _ RectangleMorph new
		color: (ScriptingSystem colorForType: #command);
		extent: 24@TileMorph defaultH;
		borderWidth: 0.
	m addMorphCentered: (ImageMorph new image: (ScriptingSystem formAtKey: 'Gets')).
	m setBalloonText: 'drag from here to obtain an assignment phrase.'.
	m on: #mouseDown send: sel
		to: self
		withValue: argArray.
	^ m
