remove: oldObject ifAbsent: aBlock

	| index |
	index _ self findElementOrNil: oldObject.
	(array at: index) == nil ifTrue: [ ^ aBlock value ].
	array at: index put: nil.
	tally _ tally - 1.
	self fixCollisionsFrom: index.
	^ oldObject