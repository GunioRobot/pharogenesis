nextFromStream: aStream

	| character1 |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 _ aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	^ self toSqueak: character1.
