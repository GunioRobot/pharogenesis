unadjustedScrollRange
	"Return the difference between the height extent of the receiver's submorphs and its own height extent (plus an extra 1/2 line height)."
	scroller submorphBounds ifNil: [^ 0].
	^ self totalScrollRange - bounds height + (self scrollDeltaHeight / 2) max: 0