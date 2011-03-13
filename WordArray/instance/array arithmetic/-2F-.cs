/ other

	| result |
	other isNumber ifTrue: [
		other isFloat ifTrue: [
			result _ KedamaFloatArray new: self size.
			^ self primDivScalar: self and: other into: result.
		] ifFalse: [
			result _ WordArray new: self size.
			^ self primDivScalar: self and: other into: result.
		].
	].
	(other isMemberOf: WordArray) ifTrue: [	
		result _ WordArray new: self size.
		^ self primDivArray: self and: other into: result.
	].
	(other isMemberOf: KedamaFloatArray) ifTrue: [	
		result _ KedamaFloatArray new: self size.
		^ self primDivArray: self and: other into: result.
	].
	^ super / other.
