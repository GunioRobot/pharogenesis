labelGraphic: aForm
	| oldLabel graphicalMorph |
	(oldLabel _ self findA: SketchMorph)
		ifNotNil: [oldLabel delete].
	graphicalMorph _ SketchMorph withForm: aForm.
	self extent: graphicalMorph extent + (borderWidth + 6).
	graphicalMorph position: self center - (graphicalMorph extent // 2).
	self addMorph: graphicalMorph.
	graphicalMorph lock
