editDrawingIn: aPasteUpMorph forBackground: forBackground

	| w oldRotation bnds sketchEditor pal aPaintTab aWorld aPaintBox |
	self world assureNotPaintingElse: [^ self].

	w _ aPasteUpMorph world.
	w stopRunningAll; abandonAllHalos.
	w displayWorld.
	oldRotation _ rotationDegrees.
	forBackground
		ifTrue:
			[bnds _ aPasteUpMorph boundsInWorld]
		ifFalse:
			[bnds _ (self boundsInWorld expandBy: (60 @ 60)) intersect: self world bounds.
			bnds _ (aPasteUpMorph paintingBoundsAround: bnds center) merge: bnds].
	sketchEditor _ SketchEditorMorph new.
	forBackground ifTrue: [sketchEditor setProperty: #background toValue: true].
	w addMorphFront: sketchEditor.
	sketchEditor initializeFor: self inBounds: bnds pasteUpMorph: aPasteUpMorph.
		"self rotationDegrees: 0.  inside the init"
	self rotationDegrees: oldRotation.  "restore old rotation so that cancel leaves it right"
	sketchEditor
		afterNewPicDo: [:aForm :aRect |
			self form: aForm.
			self topRendererOrSelf position: aRect origin.
			self rotationStyle: sketchEditor rotationStyle.
			self setupAngle: sketchEditor forwardDirection.
			self rotationDegrees: sketchEditor forwardDirection.
			self presenter drawingJustCompleted: self.
			forBackground ifTrue: [self goBehind]]  "shouldn't be necessary"
		ifNoBits: ["If no bits drawn.  Must keep old pic.  Can't have no picture"
			aWorld _ self currentWorld.
				"sometimes by now I'm no longer in a world myself, but we still need
				 to get ahold of the world so that we can deal with the palette"
			((pal _ aPasteUpMorph standardPalette) notNil and: [pal isInWorld])
				ifTrue:
					[(aPaintBox _ aWorld paintBox) ifNotNil: [aPaintBox delete].
					pal viewMorph: self]
				ifFalse:
					[(aPaintTab _ aWorld paintingFlapTab)
						ifNotNil:
							[aPaintTab hideFlap]
						ifNil:
							[(aPaintBox _ aWorld paintBox) ifNotNil: [aPaintBox delete]]]]
