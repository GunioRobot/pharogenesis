utf8Char
	"Note: we silently clamp every char to US ASCII range"
	| firstByte lastByte maskValue prevByte |
	firstByte := lastByte := self nextByte.
	firstByte == nil ifTrue:[^nil].
	firstByte < 128 ifTrue:[^Character value: firstByte].
	self halt.
	"More than one byte"
	maskValue := 2r00100000.
	[prevByte := lastByte.
	lastByte := self nextByte.
	(firstByte bitAnd: maskValue) = 0] whileTrue:[
		maskValue := maskValue bitShift: -1.
	].
	^Character value: (lastByte bitAnd: 2r00111111) + ((prevByte bitAnd: 1) bitShift: 6).
