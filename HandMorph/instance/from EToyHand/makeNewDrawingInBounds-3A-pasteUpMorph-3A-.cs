makeNewDrawingInBounds: rect pasteUpMorph: aPasteUpMorph
	|  aPaintWindow  aSketchMorph aPlayer  aWorld |
	aWorld _ aPasteUpMorph world.
	aWorld stopRunningAll; abandonAllHalos.
	aSketchMorph _ self drawingClass new costumee: (aPlayer _ Player newUserInstance).
	aPlayer costume: aSketchMorph.
	aSketchMorph form: (Form extent: rect extent depth: aWorld assuredCanvas depth).
	aSketchMorph bounds: rect.
	aPaintWindow _ SketchEditorMorph new.
	aWorld addMorphFront: aPaintWindow.
	aPaintWindow initializeFor: aSketchMorph inBounds: rect ofWorld: aWorld.

	aPaintWindow 
		afterNewPicDo: [:aForm :aRect |
			owner fullRepaintNeeded.
			aSketchMorph form: aForm.
			aSketchMorph position: aRect origin.
			aSketchMorph forwardDirection: aPaintWindow forwardDirection.
			aSketchMorph rotationDegrees: aPaintWindow forwardDirection.	"Same orientation as she drew it"
			aSketchMorph rotationStyle: aPaintWindow rotationStyle.
			aPasteUpMorph addMorphFront: aSketchMorph.
			aWorld startSteppingSubmorphsOf: aSketchMorph.
			self presenter drawingJustCompleted: aSketchMorph]
		 ifNoBits: [aPasteUpMorph standardPalette ifNotNil: [aPasteUpMorph standardPalette showNoPalette]]