viewBox: newViewBox

	| vb |
	((vb _ self viewBox) == nil or: [vb extent ~= newViewBox extent])
		ifTrue: [self canvas: nil].

	worldState viewBox: newViewBox.

	bounds _ 0@0 extent: newViewBox extent.
	"Paragraph problem workaround; clear selections to avoid screen droppings:"
	self handsDo: [:h | h newKeyboardFocus: nil].
	self fullRepaintNeeded.

