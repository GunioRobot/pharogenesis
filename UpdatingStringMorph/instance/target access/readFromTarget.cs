readFromTarget

	| v |
	((target == nil) or: [getSelector == nil]) ifTrue: [^ contents].
	v _ target scriptPerformer perform: getSelector.
	^ self acceptValueFromTarget: v