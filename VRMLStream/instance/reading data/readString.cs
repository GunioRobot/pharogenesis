readString
	| out char |
	out := WriteStream on: (String new: 10).
	self peekChar = $" ifFalse:[ ^nil].
	self skip: 1.
	[char := self nextChar.
	char = $\ ifTrue:[char := self nextChar].
	char = $"] whileFalse:[out nextPut: char].
	^out contents