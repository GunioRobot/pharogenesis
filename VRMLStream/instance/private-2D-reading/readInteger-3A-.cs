readInteger: base 
	"Optimized version of Integer>>readFrom:base: for the VRML stream"
	| digit value neg startPos aStream char |
	aStream _ self.
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
			neg ifTrue: [^ 0 - value].
			^ value
		] ifFalse: [value _ value * base + digit].
		char _ aStream next].
	neg ifTrue: [^ 0 - value].
	^ value