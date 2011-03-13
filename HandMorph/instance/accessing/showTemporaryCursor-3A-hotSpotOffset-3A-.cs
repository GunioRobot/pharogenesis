showTemporaryCursor: cursorOrNil hotSpotOffset: hotSpotOffset
	"Set the temporary cursor to the given Form. If the argument is nil, revert to the normal cursor."

	self changed.
	cursorOrNil == nil ifTrue: [
		temporaryCursor _ nil.
		bounds _ self position extent: NormalCursor extent.
		temporaryCursorOffset _ 0@0.
	] ifFalse: [
		temporaryCursor _ ColorForm mappingWhiteToTransparentFrom: cursorOrNil.
		bounds _ self position - hotSpotOffset extent: temporaryCursor extent.
		temporaryCursorOffset _ hotSpotOffset].
	self userInitials: userInitials.
	self layoutChanged.
	self changed.
