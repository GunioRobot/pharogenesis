restChar
	| char |
	self backup.
	char := self utf8Char.
	(char == nil or:[NonRestChars includes: char asciiValue]) ifTrue:[
		self restore.
		^nil
	] ifFalse:[
		self discard.
		^char
	].