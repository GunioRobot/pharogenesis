vLeftoverScrollRange
	"Return the entire scrolling range minus the currently viewed area."
	| h |

	scroller hasSubmorphs ifFalse:[^0].
	h _ self vScrollBarHeight.
	^ (self vTotalScrollRange - h roundTo: self scrollDeltaHeight) max: 0
