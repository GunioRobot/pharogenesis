writeOn: aStream
	self trimTokenBags.
	categorizer writeOn: aStream elementWriter: [:s :token | s nextStringPut: token].