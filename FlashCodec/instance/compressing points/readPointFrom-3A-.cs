readPointFrom: aStream
	| sign x y |
	sign := aStream next.
	x := Integer readFrom: aStream.
	sign = $- ifTrue:[x := 0-x].
	sign := aStream next.
	y := Integer readFrom: aStream.
	sign = $- ifTrue:[y := 0-y].
	^x@y