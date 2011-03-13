viewBox: newViewBox

	| vb |
	((vb _ self viewBox) == nil or: [vb extent ~= newViewBox extent])
		ifTrue: [worldState canvas: nil].

	worldState viewBox: newViewBox.
	super position: newViewBox topLeft.

"23 may 2000 - RAA - let's see if this is ok"

	bounds _ newViewBox.	"0@0 extent: newViewBox extent."
	"Paragraph problem workaround; clear selections to avoid screen droppings:"
	self flag: #arNote. "Probably unnecessary"
	worldState handsDo: [:h | h releaseKeyboardFocus].
	self fullRepaintNeeded.

