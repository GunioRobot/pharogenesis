scrollBy: heightToMove
	"Move the paragraph by heightToMove, and reset the text selection."
	^ paragraph scrollBy: heightToMove withSelectionFrom: self pointBlock to: self markBlock