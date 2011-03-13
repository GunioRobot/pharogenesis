justDroppedInto: newOwner event: evt
	| ownerTransform |
	ownerTransform := (newOwner transformFrom: newOwner world).
	ownerTransform isIdentity ifFalse:[
		ownerTransform := ownerTransform asMatrixTransform2x3 inverseTransformation.
		self transform: (self transform composedWithGlobal: ownerTransform).
	].
	super justDroppedInto: newOwner event: evt.