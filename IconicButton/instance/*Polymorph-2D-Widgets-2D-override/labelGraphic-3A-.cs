labelGraphic: aForm
	"Changed to look for any image morph rather than just a sketch."
	
	| oldLabel graphicalMorph |
	(oldLabel := self findA: ImageMorph)
		ifNotNil: [oldLabel delete].
	graphicalMorph := ImageMorph new image: aForm.
	self extent: graphicalMorph extent + (self borderWidth + 6).
	graphicalMorph position: self center - (graphicalMorph extent // 2).
	self addMorph: graphicalMorph.
	graphicalMorph lock
