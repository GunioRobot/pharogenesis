repaintEntry
	"Let the user enter into painting mode to repaint the item and save it back."

	| aWorld bnds sketchEditor aPaintBox formToEdit |
	
	(aWorld _ self world) assureNotPaintingElse: [^ self].

	aWorld prepareToPaint.
	aWorld displayWorld.
	formToEdit _ formChoices at: currentIndex.
	bnds _ (submorphs second boundsInWorld origin extent: formToEdit extent) intersect: aWorld bounds.
	bnds _ (aWorld paintingBoundsAround: bnds center) merge: bnds.
	sketchEditor _ SketchEditorMorph new.
	aWorld addMorphFront: sketchEditor.
	sketchEditor initializeFor: ((World drawingClass withForm: formToEdit) position: submorphs second positionInWorld)  inBounds: bnds pasteUpMorph: aWorld paintBoxPosition: bnds topRight.
	sketchEditor
		afterNewPicDo: [:aForm :aRect |
			formChoices at: currentIndex put: aForm.
			baseDictionary at: (entryNames at: currentIndex) put: aForm.
			self updateThumbnail.
			(aPaintBox _ aWorld paintBoxOrNil) ifNotNil: [aPaintBox delete]] 
		ifNoBits:
			[(aPaintBox _ aWorld paintBoxOrNil) ifNotNil: [aPaintBox delete]].
	
