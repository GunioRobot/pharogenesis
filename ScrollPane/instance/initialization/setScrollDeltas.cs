setScrollDeltas
	| range delta |
	self hideOrShowScrollBar.
	scroller hasSubmorphs ifFalse: [scrollBar interval: 1.0.  ^ self].
	range _ self leftoverScrollRange.
	delta _ self scrollDeltaHeight.
	range = 0 ifTrue: [^ scrollBar scrollDelta: 0.02 pageDelta: 0.2; interval: 1.0].

	"Set up for one line (for arrow scrolling), or a full pane less one line (for paging)."
	scrollBar scrollDelta: (delta / range) asFloat 
			pageDelta: ((self innerBounds height - delta) / range) asFloat.
	scrollBar interval: ((self innerBounds height - delta) / self totalScrollRange) asFloat.
