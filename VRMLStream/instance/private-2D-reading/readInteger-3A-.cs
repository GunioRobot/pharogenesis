readInteger: base 
	"Heavily optimized version of Integer>>readFrom:base: for the VRML stream"
	| digit value neg startPos aStream char pos |
	pos _ self position.
	aStream _ ReadStream on: (theStream next: 64 "more than enough") asString.
	char _ aStream next.
	char = $-
		ifTrue:[	neg _ true.
				char _ aStream next]
		ifFalse:[	neg _ false.
				char = $+ ifTrue:[char _ aStream next]].
	value _ 0.
	startPos _ aStream position-1.
	[char == nil] whileFalse:[
		digit _ self digitValueOf: char.
		(digit < 0 or: [digit >= base]) ifTrue:[
			aStream skip: -1.
			aStream position = startPos ifTrue: [self error: 'At least one digit expected here'].
			self position: pos + aStream position.
			neg ifTrue: [^ 0 - value].
			^ value
		] ifFalse: [value _ value * base + digit].
		char _ aStream next].
	self position: pos + aStream position.
	neg ifTrue: [^ 0 - value].
	^ value