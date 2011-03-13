setScrollDeltas
	| range |
	scroller hasSubmorphs ifFalse: [^ self].
	range _ self totalScrollRange.
	range = 0 ifTrue: [^ scrollBar scrollDelta: 0.02 pageDelta: 0.2].
	scrollBar scrollDelta: (scroller firstSubmorph height / range) asFloat 
			pageDelta: (self innerBounds height / range) asFloat 