firstChar
	| char |
	self backup.
	char := self utf8Char.
	(char == nil or:[NonFirstChars includes: char asciiValue]) ifTrue:[
		self restore.
		^nil
	] ifFalse:[
		self discard.
		^char
	].