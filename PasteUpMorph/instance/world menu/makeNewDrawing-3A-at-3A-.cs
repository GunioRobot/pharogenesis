makeNewDrawing: evt at: aPoint
	"make a new drawing, triggered by the given event, with the painting area centered around the given point"

	| w newSketch newPlayer sketchEditor aPaintBox aPalette tfx whereToPresent rect ownerBeforeHack aPaintTab aWorld |
	w _ self world.
	w assureNotPaintingElse: [^ self].
	rect _ self paintingBoundsAround: aPoint.
	aPalette _ self standardPalette.
	aPalette ifNotNil: [aPalette showNoPalette; layoutChanged].
	w prepareToPaint.

	newSketch _ self drawingClass new player: (newPlayer _ UnscriptedPlayer newUserInstance).
	newPlayer costume: newSketch.
	newSketch nominalForm: (Form extent: rect extent depth: w assuredCanvas depth).
	newSketch bounds: rect.
	sketchEditor _ SketchEditorMorph new.
	w addMorphFront: sketchEditor.
	sketchEditor initializeFor: newSketch inBounds: rect pasteUpMorph: self.
	sketchEditor
		afterNewPicDo: [:aForm :aRect |
			whereToPresent _ self presenter.
			newSketch form: aForm.
			tfx _ self transformFrom: w.
			newSketch position: (tfx globalPointToLocal: aRect origin).
			newSketch rotationStyle: sketchEditor rotationStyle.
			newSketch forwardDirection: sketchEditor forwardDirection.

			ownerBeforeHack _ newSketch owner.	"about to break the invariant!!"
			newSketch privateOwner: self. "temp for halo access"
			newPlayer setHeading: sketchEditor forwardDirection.
			(aPaintTab _ (aWorld _ self world) paintingFlapTab)
				ifNotNil:[aPaintTab hideFlap]
				ifNil:[(aPaintBox _ aWorld paintBox) ifNotNil:[aPaintBox delete]].

			"Includes  newSketch rotationDegrees: sketchEditor forwardDirection."
			newSketch privateOwner: ownerBeforeHack. "probably nil, but let's be certain"

			self addMorphFront: newPlayer costume.
			w startSteppingSubmorphsOf: newSketch.
			whereToPresent drawingJustCompleted: newSketch]
		 ifNoBits:[
			(aPaintTab _ (aWorld _ self world) paintingFlapTab)
				ifNotNil:[aPaintTab hideFlap]
				ifNil:[(aPaintBox _ aWorld paintBox) ifNotNil:[aPaintBox delete]].
			aPalette ifNotNil: [aPalette showNoPalette].]