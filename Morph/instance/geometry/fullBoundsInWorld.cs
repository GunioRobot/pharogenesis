fullBoundsInWorld

	owner ifNil: [^ self fullBounds].
	^ (owner transformFrom: self world) invertRect: self fullBounds.
