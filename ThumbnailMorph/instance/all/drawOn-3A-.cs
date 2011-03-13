drawOn: aCanvas
	"Draw a small view of a morph in another place. Guard against infinite recursion if that morph has a thumbnail of itself inside."

	| actualViewee diag viewedMorphBox myBox scale c shrunkForm |
	super drawOn: aCanvas.
	actualViewee _ self actualViewee.
	actualViewee ifNil: [^ self]. 

	(RecursionDepth _ RecursionDepth + 1) > RecursionMax ifTrue: [^ self].

	(actualViewee isKindOf: SketchMorph)
		ifTrue:
			[diag _ actualViewee form extent r asInteger.
			viewedMorphBox _
				(actualViewee bounds center - (diag // 2)) extent: diag@diag]
		ifFalse:
			[viewedMorphBox _ actualViewee fullBounds].

	myBox _ self innerBounds.
	scale _ myBox width / (viewedMorphBox width max: viewedMorphBox
height).
	c _ FormCanvas extent: viewedMorphBox extent depth: aCanvas depth.
	c _ c copyOffset: viewedMorphBox topLeft negated.
	actualViewee fullDrawOn: c.		"recursion happens here"
	shrunkForm _ c form magnify: c form boundingBox by: scale smoothing: 1.
	aCanvas image: shrunkForm at: self center - shrunkForm boundingBox
center.
	RecursionDepth _ RecursionDepth - 1.	"up a level"
