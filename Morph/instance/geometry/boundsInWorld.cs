boundsInWorld

	owner ifNil: [^ bounds].
	^ (owner transformFrom: self world) invertRect: bounds.
