nextFromStream: aStream 
	| character1 |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 _ aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	character1 charCode = 165 ifTrue: [^ (Character value: 183)].
	^ character1 squeakToIso.
