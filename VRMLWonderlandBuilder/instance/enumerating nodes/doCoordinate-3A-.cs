doCoordinate: node
	| attr points interpolator |
	(attr _ node attributeValueNamed: 'point') notNil ifTrue:[
		points _ self mfVec3fFrom: attr.
		(scene targetNodes includes: node) ifTrue:[
			interpolator _ nil.
			scene sourceNodes do:[:n|
				n actionsDo:[:set|
					set do:[:msg| msg receiver == node ifTrue:[interpolator _ n]]]].
			interpolator _ self mfVec3fFromInterpolator: interpolator.
		].
	].
	points == nil
		ifTrue:[attributes removeKey: #currentPoints]
		ifFalse:[attributes at: #currentPoints put: points].
	interpolator == nil
		ifTrue:[attributes removeKey: #interpolatorPoints ifAbsent:[]]
		ifFalse:[attributes at: #interpolatorPoints put: interpolator].
