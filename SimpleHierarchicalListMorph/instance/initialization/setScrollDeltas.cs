setScrollDeltas
	| range delta |
	scroller hasSubmorphs ifFalse: [^ scrollBar interval: 1.0].
	range _ self leftoverScrollRange.
	delta _ scroller firstSubmorph height.
	range = 0 ifTrue: [^ scrollBar scrollDelta: 0.02 pageDelta: 0.2; interval: 1.0].
	"Set up for one line, or a full pane less one line"

	scrollBar scrollDelta: (delta / range) asFloat 
			pageDelta: (self innerBounds height - delta / range) asFloat.
	scrollBar interval: ((self innerBounds height - delta) / self totalScrollRange) asFloat.
