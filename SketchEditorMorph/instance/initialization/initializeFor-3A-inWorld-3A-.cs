initializeFor: aSketchMorph inWorld: aWorldMorph

	hostView _ aSketchMorph.
	self bounds: (aWorldMorph paintAreaFor: aSketchMorph).
	canvasRectangle _ bounds translateBy: aWorldMorph viewBox origin.
	palette _ aWorldMorph paintBox.
	aWorldMorph addMorphFront: palette.	"Bring it in front"
	aWorldMorph fullRepaintNeeded.
	paintingForm _ Form extent: bounds extent 
		depth: aWorldMorph canvas depth.
	self dimTheWindow.	"And set up the bitBlts"
	aSketchMorph ~~ nil ifTrue:
		[aSketchMorph form displayOn: paintingForm 
			at: (hostView bounds origin - bounds origin)
			clippingBox: (0@0 extent: paintingForm extent)
			rule: Form over
			fillColor: nil.  "assume they are the same depth"
		rotationCenter _ aSketchMorph rotationCenter].
	palette rememberColorsFrom: paintingForm.
	self resumePainting.
