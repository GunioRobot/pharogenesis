composedWithGlobal: aB3DMatrix4x4
	| result |
	result _ self class new.
	self privateTransformMatrix: aB3DMatrix4x4 with: self into: result.
	^result