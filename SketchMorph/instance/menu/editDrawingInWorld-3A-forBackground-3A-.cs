editDrawingInWorld: w forBackground: aBoolean

	| oldRotation aPaintWindow oldFwdDir |
	w stopRunningAll.
	w displayWorld.
	aPaintWindow _ SketchEditorMorph new.
	aBoolean ifTrue: [aPaintWindow setProperty: #background toValue: true].
	w addMorphFront: aPaintWindow.
	oldRotation _ rotationDegrees.
	oldFwdDir _ self forwardDirection.
	self rotationDegrees: 0.
	aPaintWindow initializeFor: self inWorld: w.
	self rotationDegrees: oldRotation.  "while drawing is still rotated. cancel leaves it right"
	aPaintWindow 
		afterNewPicDo: [:aForm :aRect |
			self form: aForm.
			self position: aRect origin.
			self forwardDirection: aPaintWindow forwardDirection.
			self rotationDegrees: oldRotation + (aPaintWindow forwardDirection - oldFwdDir).
				"add in any changes"
			self rotationStyle: aPaintWindow rotationStyle.
			owner changed]
		ifNoBits: ["If no bits drawn.  Must keep old pic.  Can't have no picture"
			].
	aPaintWindow changed.
