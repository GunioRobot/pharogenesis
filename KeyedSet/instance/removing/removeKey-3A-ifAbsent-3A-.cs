removeKey: key ifAbsent: aBlock

	| index obj |
	index := self findElementOrNil: key.
	(obj := array at: index) == nil ifTrue: [ ^ aBlock value ].
	array at: index put: nil.
	tally := tally - 1.
	self fixCollisionsFrom: index.
	^ obj