privateFullMoveBy: delta

	| griddedDelta griddingMorph |
	selectedItems isEmpty ifTrue: [^ super privateFullMoveBy: delta].
	griddingMorph _ self pasteUpMorph.
	griddingMorph ifNil: [^ super privateFullMoveBy: delta].
	griddedDelta _ (griddingMorph gridPoint: self position + delta + slippage) -
					(griddingMorph gridPoint: self position).
	slippage _ slippage + (delta - griddedDelta).  "keep track of how we lag the true movement."
	griddedDelta = (0@0) ifTrue: [^ self].
	super privateFullMoveBy: griddedDelta.
	selectedItems do:
		[:m | m privateFullMoveBy: griddedDelta]
