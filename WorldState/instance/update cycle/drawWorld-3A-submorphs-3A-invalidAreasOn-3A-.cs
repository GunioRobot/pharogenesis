drawWorld: aWorld submorphs: submorphs invalidAreasOn: aCanvas 
	"Redraw the damaged areas of the given canvas and clear the damage list. Return a collection of the areas that
were redrawn."
	| rectList c i n mm morphs rects rectToFill remnants rect |

	rectList _ damageRecorder invalidRectsFullBounds: aWorld viewBox.
	damageRecorder reset.
	n _ submorphs size.
	morphs _ OrderedCollection new: n*2.
	rects _ OrderedCollection new: n*2.
	rectList do: [:r |
		true
		ifTrue:
			["Experimental top-down drawing --
			Traverses top to bottom, stopping if the entire area is filled.
			If only a single rectangle remains, then continue with the reduced rectangle."
			rectToFill _ r.
			i _ 1.
			[rectToFill == nil or: [i > n]] whileFalse:
				[mm _ submorphs at: i.
				((mm fullBounds intersects: r) and: [mm visible]) ifTrue:
					[morphs addLast: mm.  rects addLast: rectToFill.
					remnants _ mm areasRemainingToFill: rectToFill.
					remnants size = 1 ifTrue: [rectToFill _ remnants first].
					remnants size = 0 ifTrue: [rectToFill _ nil]].
				i _ i+1].

			"Now paint from bottom to top, but using the reduced rectangles."
			rectToFill ifNotNil:[aWorld drawOn: (c _ aCanvas copyClipRect: rectToFill)].
			[morphs isEmpty] whileFalse:
				[(rect _ rects removeLast) == rectToFill ifFalse:
					[c _ aCanvas copyClipRect: (rectToFill _ rect)].
				c fullDrawMorph: morphs removeLast].
			morphs reset.  rects reset]
		ifFalse: [rectToFill ifNotNil:[aWorld drawOn: (aCanvas copyClipRect: rectToFill)].
				submorphs reverseDo: [:m | c fullDrawMorph: m]].
	].
	^ rectList