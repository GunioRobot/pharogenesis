remove: anObject ifAbsent: aBlock
	| index |
	index := self indexOf: anObject.
	^ (self basicAt: index) == anObject 
		ifTrue: [self basicAt: index put: nil. tally := tally - 1. anObject]
		ifFalse: [aBlock value].