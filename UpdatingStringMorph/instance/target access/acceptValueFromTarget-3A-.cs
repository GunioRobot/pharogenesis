acceptValueFromTarget: v
	lastValue _ v.
	format = #string ifTrue: [^ v asString].
	(format = #default and: [v isNumber]) ifTrue:
		[v isInteger ifTrue: [^ v asInteger printString].
		(v isKindOf: Float) ifTrue: [^ (v roundTo: self floatPrecision) printString]].
	^ v printString
