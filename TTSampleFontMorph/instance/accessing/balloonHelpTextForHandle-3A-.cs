balloonHelpTextForHandle: aHandle
	aHandle eventHandler firstMouseSelector == #createSample
		ifTrue:[^'Create a sample string'].
	^super balloonHelpTextForHandle: aHandle