fullBoundsInWorld

	owner ifNil: [^ self fullBounds].
	^ (owner transformFrom: self world) localBoundsToGlobal: self fullBounds.
