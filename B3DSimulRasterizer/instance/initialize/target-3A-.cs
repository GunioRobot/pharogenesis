target: destForm
	| bb span sourceForm |
	super target: destForm.
	span _ Bitmap new: 2048.
	sourceForm _ Form extent: span size@1 depth: 32 bits: span.
	bb _ BitBlt current toForm: destForm.
	bb sourceForm: sourceForm.
	bb isFXBlt ifTrue:[
		bb colorMap: (sourceForm colormapIfNeededFor: destForm).
		bb combinationRule: 34 "Form paint". "Later we'll change this to 34 for alpha blending"
	] ifFalse:[
		bb colorMap: (sourceForm colormapIfNeededForDepth: destForm depth).
		bb combinationRule: 34 "Form paint". "Later we'll change this to 34 for alpha blending"
	].
	bb destX: 0; destY: 0; sourceX: 0; sourceY: 0; width: 1; height: 1.
	scanner spanBuffer: span.
	scanner bitBlt: bb.