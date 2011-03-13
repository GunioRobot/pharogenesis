codeString

	| s |
	s _ WriteStream on: ''.
	self storeCodeOn: s.
	^ s contents
