at: index put: value
	value isPoint
		ifTrue:[super at: index put: (B3DVector2 u: value x v: value y)]
		ifFalse:[super at: index put: value].
	^value