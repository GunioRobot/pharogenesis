veryDeepCopyWith: deepCopier
	"See storeDataOn:"

	self isWorldMorph
		ifTrue: ["maybe ^ self later?  For now, catch all offenders."
				^ self error: 'Worlds should not be copied']
		ifFalse: [^ super veryDeepCopyWith: deepCopier]