readFromTarget

	| v |
	((target == nil) or: [getSelector == nil]) ifTrue: [^ contents].
	v _ target perform: getSelector.
	lastValue _ v.
	format = #string ifTrue: [^ v].
	(format = #default and: [v isNumber]) ifTrue:
		[v isInteger ifTrue: [^ v asInteger printString].
		(v isKindOf: Float) ifTrue: [^ (v roundTo: self floatPrecision) printString]].

	^ v printString  "default: use object's printString"
