submorphsBehind: aMorph do: aBlock
	| behind |
	behind _ false.
	submorphs do:
		[:m | m == aMorph ifTrue: [behind _ true]
						ifFalse: [behind ifTrue: [aBlock value: m]]].
