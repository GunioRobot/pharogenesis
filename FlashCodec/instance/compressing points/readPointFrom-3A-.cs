readPointFrom: aStream
	| sign x y |
	sign _ aStream next.
	x _ Integer readFrom: aStream.
	sign = $- ifTrue:[x _ 0-x].
	sign _ aStream next.
	y _ Integer readFrom: aStream.
	sign = $- ifTrue:[y _ 0-y].
	^x@y