floatValueOf: oop
	self returnTypeC:'double'.
	oop class == Float
		ifTrue:[^oop]
		ifFalse:[self primitiveFail. ^0.0].