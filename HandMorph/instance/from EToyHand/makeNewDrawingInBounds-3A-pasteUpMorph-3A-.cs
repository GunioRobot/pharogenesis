makeNewDrawingInBounds: rect pasteUpMorph: aPasteUpMorph

	| w newSketch newPlayer sketchEditor aPaintBox aPalette |
	self world assureNotPaintingElse: [^ self].

	aPalette _ aPasteUpMorph standardPalette.
	aPalette ifNotNil: [aPalette showNoPalette; layoutChanged].
	w _ aPasteUpMorph world.
	w stopRunningAll; abandonAllHalos.
	newSketch _ self drawingClass new player: (newPlayer _ UnscriptedPlayer newUserInstance).
	newPlayer costume: newSketch.
	newSketch form: (Form extent: rect extent depth: w assuredCanvas depth).
	newSketch bounds: rect.
	sketchEditor _ SketchEditorMorph new.
	w addMorphFront: sketchEditor.
	sketchEditor initializeFor: newSketch inBounds: rect pasteUpMorph: aPasteUpMorph.
	sketchEditor
		afterNewPicDo: [:aForm :aRect |
			newSketch form: aForm.
			newSketch position: aRect origin.
			newSketch rotationStyle: sketchEditor rotationStyle.
			newSketch setupAngle: sketchEditor forwardDirection.
			newSketch privateOwner: aPasteUpMorph.  "temp for halo access"
			newPlayer setHeading: sketchEditor forwardDirection.
			"Includes  newSketch rotationDegrees: sketchEditor forwardDirection."
			aPasteUpMorph addMorphFront: newPlayer costume.
			w startSteppingSubmorphsOf: newSketch.
			self presenter drawingJustCompleted: newSketch]
		 ifNoBits:
			[(aPaintBox _ self world paintBox) ifNotNil:
				[aPaintBox delete].
			aPalette ifNotNil: [aPalette showNoPalette].]