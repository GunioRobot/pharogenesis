makeNewDrawing

	| rect m aPaintWindow |
	self world stopRunningAll.
	rect _ self world paintArea.	"Let it tell us"
	m _ self drawingClass new
		form: (Form extent: rect extent depth: self world canvas depth).
	m bounds: rect.
	aPaintWindow _ SketchEditorMorph new.
	self world addMorphFront: aPaintWindow.
	aPaintWindow initializeFor: m inWorld: self world.
	aPaintWindow 
		afterNewPicDo: [:aForm :aRect |
			owner fullRepaintNeeded.
			m form: aForm.
			m position: aRect origin.
			m forwardDirection: aPaintWindow forwardDirection.
			m rotationDegrees: aPaintWindow forwardDirection.	"Same orientation as she drew it"
			m rotationStyle: aPaintWindow rotationStyle.
			self world addMorphFront: m]
		ifNoBits: ["If no bits drawn"].
