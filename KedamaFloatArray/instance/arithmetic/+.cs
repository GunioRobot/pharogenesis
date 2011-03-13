+ other

	| result |
	other isNumber ifTrue: [
		result _ KedamaFloatArray new: self size.
		^ self primAddScalar: self and: other into: result.
	].
	((other isMemberOf: WordArray) or: [other isMemberOf: KedamaFloatArray]) ifTrue: [	
		result _ KedamaFloatArray new: self size.
		^ self primAddArray: self and: other into: result.
	].
	^ super + other.
