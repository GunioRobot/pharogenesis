postCopy
	| props |
	composite _ composite copy.
	scaleMatrix _ scaleMatrix copy.
	props _ myProperties.
	myProperties _ nil.
	props = nil ifFalse:[
		props keysAndValuesDo:[:k :v| self setProperty: k toValue: v]].