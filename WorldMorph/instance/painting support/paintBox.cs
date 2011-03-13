paintBox
	"Return the painting controls widget (PaintBoxMorph) to be used for painting in this world. If there is not already a PaintBox morph, or if it has been deleted from this world, create a new one."

	| newPaintBox |
	self allMorphsDo: [:m | (m isKindOf: PaintBoxMorph) ifTrue: [^ m]].
	self allMorphsDo: [:m | (m isKindOf: EToyPalette) ifTrue: [
		^ m showPaintPaletteNoSelection]].	"Does not create an object"
	newPaintBox _ PaintBoxMorph new.
	newPaintBox position: (self topRight - (newPaintBox width @ 0)). 
	self addMorph: newPaintBox.
	^ newPaintBox
