balloonHelpTextForHandle: aHandle
	|  itsSelector |
	itsSelector _ aHandle eventHandler firstMouseSelector.
	itsSelector == #strokeMode ifTrue: [^'Create Pooh Object'].
	^ super balloonHelpTextForHandle: aHandle