boundsInWorld

	owner ifNil: [^ bounds].
	^ (owner transformFrom: self world) localBoundsToGlobal: bounds.
