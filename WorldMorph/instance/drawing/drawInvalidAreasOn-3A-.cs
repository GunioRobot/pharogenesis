drawInvalidAreasOn: aCanvas
	"Redraw the damaged areas of the given canvas and clear the damage list. Return a collection of the areas that were redrawn."

	| rectList c |
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: aCanvas extent).
	damageRecorder reset.
	rectList do: [:r |
		c _ aCanvas copyClipRect: r.
		"** change to true to try out optimized drawing **"
		"Fails currently for Transforms and ScreeningMorphs"
		false
		ifTrue: [(self visibleMorphsIn: r)
					do: [:m | m == self ifTrue: [c fillColor: color]
									ifFalse: [m drawOn: c]]]
		ifFalse: [c fillColor: color.
				submorphs reverseDo: [:m | m fullDrawOn: c]
				"Used to be..."
				"submorphs reverseDo: [:m |
					(m fullBounds intersects: r)
					ifTrue: [m drawOn: c]]."
				].
		hands reverseDo: [:h | h fullDrawOn: c]].
	^ rectList