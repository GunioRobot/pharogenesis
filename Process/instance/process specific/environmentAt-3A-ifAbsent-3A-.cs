environmentAt: key  ifAbsent: aBlock
	env ifNil: [ ^ aBlock value ].
	^env at: key ifAbsent: aBlock.