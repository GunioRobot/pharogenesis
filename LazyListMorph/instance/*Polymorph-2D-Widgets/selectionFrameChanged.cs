selectionFrameChanged
	"Invalidate frame of the current selection if any."
	
	| frame |
	selectedRow ifNil: [ ^self ].
	selectedRow = 0 ifTrue: [ ^self ].
	frame := self selectionFrameForRow: selectedRow.
	self invalidRect: frame