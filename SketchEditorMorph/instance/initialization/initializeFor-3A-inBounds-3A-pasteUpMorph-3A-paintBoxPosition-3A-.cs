initializeFor: aSketchMorph inBounds: boundsToUse pasteUpMorph: aPasteUpMorph paintBoxPosition: aPosition
	"NB: if aPosition is nil, then it's assumed that the paintbox is obtained from a flap or some such, so do nothing special regarding a palette in this case.  The palette needs already to be in the world for this to work."
	| w  |
	(w _ aPasteUpMorph world) addMorphFront: self.
	enclosingPasteUpMorph _ aPasteUpMorph.
	hostView _ aSketchMorph.  "may be ownerless"
	self bounds: boundsToUse.
	canvasRectangle _ bounds.
	palette _ w paintBox focusMorph: self.
	aPosition ifNotNil:
		[w addMorphFront: palette.  "bring to front"
		palette position: aPosition].
	paintingForm _ Form extent: bounds extent depth: w assuredCanvas depth.
	self dimTheWindow.
	self addRotationScaleHandles.
	aSketchMorph ifNotNil:
		[aSketchMorph rotationDegrees: 0.
		aSketchMorph form
			displayOn: paintingForm
			at: (hostView boundsInWorld origin - bounds origin)
			clippingBox: (0@0 extent: paintingForm extent)
			rule: Form over
			fillColor: nil.  "assume they are the same depth"
		rotationCenter _ aSketchMorph rotationCenter]