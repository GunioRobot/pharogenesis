showTemporaryCursor: cursorOrNil hotSpotOffset: hotSpotOffset
	"Set the temporary cursor to the given Form. If the argument is nil, revert to the normal cursor."

	self changed.
	cursorOrNil == nil ifTrue: [
		temporaryCursor _ nil.
		temporaryCursorOffset _ 0@0.
		bounds _ self position extent: NormalCursor extent.
	] ifFalse: [
		temporaryCursor _ ColorForm mappingWhiteToTransparentFrom: cursorOrNil.
		temporaryCursorOffset _ hotSpotOffset.
		bounds _ self position extent: temporaryCursor extent].
	self userInitials: userInitials.
	self layoutChanged.
	self changed.

	UseHardwareCursor ifTrue: [
		(cursorOrNil isMemberOf: Cursor)
			ifTrue: [cursorOrNil show]
			ifFalse: [Cursor normal show]].
