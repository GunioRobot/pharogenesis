pointInWorld: aPoint

	owner ifNil: [^ aPoint].
	^ (owner transformFrom: self world) localPointToGlobal: aPoint.
