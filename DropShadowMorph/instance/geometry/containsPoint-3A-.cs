containsPoint: pt

	self hasSubmorphs ifFalse: [^ super containsPoint: pt].
	^ self firstSubmorph containsPoint: pt