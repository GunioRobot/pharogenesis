postCopy
	| props |
	myName _ myName copy.
	myMaterial _ myMaterial copy.
	myColor _ myColor copy.
	myReactions _ myReactions copy.
	myMesh _ myMesh shallowCopy.
	composite _ composite copy.
	scaleMatrix _ scaleMatrix copy.
	props _ myProperties.
	myProperties _ nil.
	props = nil ifFalse:[
		props keysAndValuesDo:[:k :v| self setProperty: k toValue: v]].