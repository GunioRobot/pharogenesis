griddedPoint: ungriddedPoint

	| griddingContext |
	self flag: #arNote. "Used by event handling - should transform to pasteUp for gridding"
	(griddingContext _ self pasteUpMorph) ifNil: [^ ungriddedPoint].
	^ griddingContext gridPoint: ungriddedPoint