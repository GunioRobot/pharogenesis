backgroundSketch: aSketchMorphOrNil

	backgroundMorph ifNotNil: [backgroundMorph delete].  "replacing old background"

	aSketchMorphOrNil ifNil: [backgroundMorph _ nil.  ^ self].

	backgroundMorph _ StickySketchMorph new form: aSketchMorphOrNil form.
	backgroundMorph position: aSketchMorphOrNil position.
	self addMorphBack: backgroundMorph.
	aSketchMorphOrNil delete.
	backgroundMorph lock.
	^ backgroundMorph
