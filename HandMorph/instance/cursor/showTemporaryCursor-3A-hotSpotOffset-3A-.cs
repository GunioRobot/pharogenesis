showTemporaryCursor: cursorOrNil hotSpotOffset: hotSpotOffset
	"Set the temporary cursor to the given Form.
	If the argument is nil, revert to the normal hardware cursor."

	self changed.
	cursorOrNil == nil
		ifTrue: [temporaryCursor _ temporaryCursorOffset _ nil]
		ifFalse: [temporaryCursor _ cursorOrNil asCursorForm.
				temporaryCursorOffset _ temporaryCursor offset - hotSpotOffset].
	bounds _ self cursorBounds.
	self 
		userInitials: userInitials andPicture: (self userPicture);
		layoutChanged;
		changed
