viewBox: newViewBox

	| vb |

	self damageRecorder reset.	"since we may have moved, old data no longer valid"
	((vb _ self viewBox) == nil or: [vb ~= newViewBox])
		ifTrue: [self canvas: nil].

	worldState viewBox: newViewBox.

	bounds _ newViewBox.
	self assuredCanvas.
	"Paragraph problem workaround; clear selections to avoid screen droppings:"
	self handsDo: [:h | h newKeyboardFocus: nil].
	self fullRepaintNeeded.

