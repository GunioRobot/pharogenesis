peekChar
	| pos char |
	pos := self position.
	char := self nextChar.
	self position: pos.
	^char