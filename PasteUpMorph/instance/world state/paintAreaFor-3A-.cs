paintAreaFor: aSketchMorph
	"Answer the area to comprise the onion-skinned canvas for painting/repainting aSketchMorph"
	| itsOwner |
	((itsOwner _ aSketchMorph owner) ~~ nil and: [itsOwner isPlayfieldLike])
		ifTrue: [^ itsOwner bounds].  "handles every plausible situation"

	^ self paintArea