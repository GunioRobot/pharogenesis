removeKey: key ifAbsent: aBlock

	| index obj |
	index _ self findElementOrNil: key.
	(obj _ array at: index) == nil ifTrue: [ ^ aBlock value ].
	array at: index put: nil.
	tally _ tally - 1.
	self fixCollisionsFrom: index.
	^ obj