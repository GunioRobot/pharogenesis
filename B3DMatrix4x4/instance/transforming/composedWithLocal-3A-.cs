composedWithLocal: aB3DMatrix4x4
	| result |
	result _ self class new.
	self privateTransformMatrix: self with: aB3DMatrix4x4 into: result.
	^result