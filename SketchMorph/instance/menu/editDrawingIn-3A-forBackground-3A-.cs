editDrawingIn: aPasteUpMorph forBackground: aBoolean
	| oldRotation aPaintWindow oldFwdDir w boundsToUse |
	w _ aPasteUpMorph world.
	w stopRunningAll; abandonAllHalos.
	w displayWorld.
	aPaintWindow _ SketchEditorMorph new.
	aBoolean ifTrue: [aPaintWindow setProperty: #background toValue: true].
	w addMorphFront: aPaintWindow.
	oldRotation _ rotationDegrees.
	oldFwdDir _ self forwardDirection.
	self rotationDegrees: 0.
	aBoolean
		ifTrue:
			[aPaintWindow initializeFor: self inPasteUpMorph: aPasteUpMorph]
		ifFalse:
			[boundsToUse _ (aPasteUpMorph paintingBoundsAround: self bounds center) merge: self bounds.
			aPaintWindow initializeFor: self inBounds: boundsToUse ofWorld: aPasteUpMorph world].
	self rotationDegrees: oldRotation.  "while drawing is still rotated. cancel leaves it right"
	aPaintWindow 
		afterNewPicDo: [:aForm :aRect |
			self form: aForm.
			self position: aRect origin.
			self forwardDirection: aPaintWindow forwardDirection.
			self rotationDegrees: oldRotation + (aPaintWindow forwardDirection - oldFwdDir).
				"add in any changes"
			self rotationStyle: aPaintWindow rotationStyle.
			aPasteUpMorph playfield ifNotNil: "Show the right viewer"
				[self presenter drawingJustCompleted: self].
			aBoolean ifTrue: [self goBehind].  "shouldn't be necessary"
			owner changed]
		ifNoBits: ["If no bits drawn.  Must keep old pic.  Can't have no picture"
			aPasteUpMorph standardPalette ifNotNil: [aPasteUpMorph standardPalette viewMorph: self]].
	aPaintWindow changed.
