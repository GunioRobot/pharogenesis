readFromTarget

	| v |
	((target == nil) or: [getSelector == nil]) ifTrue: [^ contents].
	target isInWorld ifFalse: [^ contents].
	v _ target scriptPerformer perform: getSelector.
	lastValue _ v.
	^ v 