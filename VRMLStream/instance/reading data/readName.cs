readName
	| out char |
	self skipSeparators.
	out := WriteStream on: (String new: 20).
	char := self firstChar.
	char ifNil:[^nil].
	out nextPut: char.
	[char := self restChar.
	char notNil] whileTrue:[
		out nextPut: char.
	].
	^out contents