at: key ifAbsent: aBlock

	| index |
	index _ self findElementOrNil: key.
	(self basicAt: index) == nil ifTrue: [ ^ aBlock value ].
	^ array at: index