printOn: aStream indent: level

	| shown |
	aStream nextPut: ${.
	shown _ elements size.
	1 to: shown do: 
		[:i | 
		(elements at: i) printOn: aStream indent: level.
		i < shown ifTrue: [aStream nextPut: $.; space]].
	aStream nextPut: $}