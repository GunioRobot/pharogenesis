embedInWindow

	| window |
	window _ (SystemWindow labelled: self defaultLabelForInspector) model: nil.
	window bounds: ((self position - ((0@window labelHeight) + window borderWidth))
						corner: self bottomRight + window borderWidth).
	window addMorph: self frame: (0@0 extent: 1@1).
	window updatePaneColors.
	World addMorph: window.
	window activate