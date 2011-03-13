drawInvalidAreasOn: aCanvas
	"Redraw the damaged areas of the given canvas and clear the damage list. Return a collection of the areas that were redrawn."
	| rectList c i n intersectors done mm |
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: viewBox extent).
	damageRecorder reset.
	n _ self submorphs size.
	intersectors _ OrderedCollection new: n*2.
	rectList do: [:r |
		c _ aCanvas copyClipRect: r.
		true
		ifTrue:
			["Experimental top-down drawing"
			i _ 1. done _ false.
			[done or: [i > n]] whileFalse:
				[mm _ submorphs at: i.
				(mm fullBounds intersects: r) ifTrue:
					[intersectors addLast: mm.
					done _ mm drawOnFills: r].
				i _ i+1].
			done ifFalse: [c fillColor: color].
			intersectors reverseDo:
				[:m | m topDownDrawOn: c].
			intersectors reset]
		ifFalse: [c fillColor: color.
				submorphs reverseDo: [:m | m fullDrawOn: c]]
		].
	^ rectList