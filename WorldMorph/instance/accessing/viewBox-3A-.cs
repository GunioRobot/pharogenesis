viewBox: aRectangle

	(viewBox == nil or:
	 [viewBox extent ~= aRectangle extent])
		ifTrue: [self canvas: nil].
	viewBox _ aRectangle.
	bounds _ 0@0 extent: viewBox extent.
	"Paragraph problem workaround; clear selections to avoid screen droppings:"
	hands do: [:h | h newKeyboardFocus: nil].
	self fullRepaintNeeded.
