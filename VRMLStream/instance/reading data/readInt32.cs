readInt32
	| aStream value |
	self backup.
	aStream := ReadStream on: (theStream next: 33 "+/- plus 32 digits (if base 2)") asString.
	value _ self readInt32From: aStream.
	value ifNil:[self restore. ^nil].
	self discardTo: aStream position.
	^value