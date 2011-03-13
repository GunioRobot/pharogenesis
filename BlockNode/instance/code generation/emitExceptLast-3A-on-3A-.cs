emitExceptLast: stack on: aStream
	| nextToLast |
	nextToLast := statements size - 1.
	nextToLast < 1 ifTrue: [^ self].  "Only one statement"
	1 to: nextToLast do:
		[:i | (statements at: i) emitForEffect: stack on: aStream].
