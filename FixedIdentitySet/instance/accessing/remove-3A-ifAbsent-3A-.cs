remove: anObject ifAbsent: aBlock
	| index |
	index _ self indexOf: anObject.
	^ (self basicAt: index) == anObject 
		ifTrue: [self basicAt: index put: nil. tally _ tally - 1. anObject]
		ifFalse: [aBlock value].