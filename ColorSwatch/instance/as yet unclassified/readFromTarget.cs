readFromTarget

	| v |
	((target == nil) or: [getSelector == nil]) ifTrue: [^ contents].
	v _ target scriptPerformer perform: getSelector with: argument.
	lastValue _ v.
	^ v 