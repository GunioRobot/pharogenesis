getMessage: msgID at: start textLength: textSize
	"Retrieve the message with the given ID, location, and text size."

	self ensureFileIsOpen.
	self assertValidMessageAt: start id: msgID.
	^file next: textSize