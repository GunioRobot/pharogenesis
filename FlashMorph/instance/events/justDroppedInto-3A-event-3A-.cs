justDroppedInto: newOwner event: evt
	| ownerTransform |
	ownerTransform _ (newOwner transformFrom: newOwner world).
	ownerTransform isIdentity ifFalse:[
		ownerTransform _ ownerTransform asMatrixTransform2x3 inverseTransformation.
		self transform: (self transform composedWithGlobal: ownerTransform).
	].
	super justDroppedInto: newOwner event: evt.