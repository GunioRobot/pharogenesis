pointFromWorld: aPoint

	owner ifNil: [^ aPoint].
	^ (owner transformFrom: self world) globalPointToLocal: aPoint.
