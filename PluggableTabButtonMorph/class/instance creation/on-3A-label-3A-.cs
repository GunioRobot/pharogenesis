on: anObject label: getTextSelector
	| instance |
	instance _ super new.
	instance model: anObject.
	instance textSelector: getTextSelector.
	^ instance 