drawOn: aCanvas
	"Draw a small view of a morph in another place. Guard against infinite recursion if that morph has a thumbnail of itself inside."

	| actualViewee viewedMorphBox myBox scale c shrunkForm aWorld |
	super drawOn: aCanvas.
	((((actualViewee _ self actualViewee) ~~ nil and: [(aWorld _ actualViewee world) ~~ nil])
			and: [aWorld ~~ actualViewee or: [lastFormShown == nil]]) and: [RecursionDepth + 1 < RecursionMax])
		ifTrue:
			[RecursionDepth _ RecursionDepth + 1.
			viewedMorphBox _ actualViewee fullBounds.

			myBox _ self innerBounds.
			scale _ myBox width / (viewedMorphBox width max: viewedMorphBox
		height).
			c _ Display defaultCanvasClass extent: viewedMorphBox extent depth: aCanvas depth.
			c translateBy: viewedMorphBox topLeft negated 
				"recursion happens here"
				during:[:tempCanvas| actualViewee fullDrawOn: tempCanvas].
			shrunkForm _ c form magnify: c form boundingBox by: scale smoothing: 1.
			lastFormShown _ shrunkForm.
			RecursionDepth _ RecursionDepth - 1]
		ifFalse:  "This branch used if we've recurred, or if the thumbnail views a World that's already been rendered once, or if the referent is not in a world at the moment"
			[lastFormShown ifNotNil: [shrunkForm _ lastFormShown]].


	shrunkForm ifNotNil:
		[aCanvas paintImage: shrunkForm at: self center - shrunkForm boundingBox
center]

	"sw 12/20/1999 13:35 special-case code for SketchMorph commented out, since it seems to have done more harm than good:
 			((actualViewee isKindOf: SketchMorph) and: [false])
				ifTrue:
					[diag _ actualViewee form extent  asInteger.
					viewedMorphBox _
						(actualViewee bounds center - (diag // 2)) extent: diag@diag]
				ifFalse:
					[viewedMorphBox _ actualViewee fullBounds]."