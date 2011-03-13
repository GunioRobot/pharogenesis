pointInWorld: aPoint

	owner ifNil: [^ aPoint].
	^ (owner transformFrom: self world) invert: aPoint.
