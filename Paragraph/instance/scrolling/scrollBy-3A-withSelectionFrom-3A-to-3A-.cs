scrollBy: heightToMove withSelectionFrom: startBlock to: stopBlock 
	"Translate the composition rectangle up (dy<0) by heightToMove.
	Repainting text as necessary, and selection if blocks not nil.
	Return true unless scrolling limits have been reached."
	| max min amount |
	max _ 0 max: "cant scroll up more than dist to (top of) bottom line"
		compositionRectangle bottom - textStyle lineGrid - clippingRectangle top.
	min _ 0 min: "cant scroll down more than top is above clipRect"
		compositionRectangle top - clippingRectangle top.
	amount _ ((heightToMove truncateTo: textStyle lineGrid) min: max) max: min.
	amount ~= 0
		ifTrue: [destinationForm deferUpdatesIn: clippingRectangle while: [
					self scrollUncheckedBy: amount
						withSelectionFrom: startBlock to: stopBlock].
				^ true]
		ifFalse: [^ false]