remove: pointKey from: aSet
	self hasMultipleMatches ifFalse:[^aSet remove: pointKey].
	aSet copy do:[:obj|
		obj x = pointKey x ifTrue:[
			aSet remove: obj.
		] ifFalse:[
			obj y = pointKey y ifTrue:[
				aSet remove: obj.
			].
		]
	].
