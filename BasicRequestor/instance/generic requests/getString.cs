getString
	| result |
	result _ FillInTheBlank  request:caption  initialAnswer:answer contents.
	self newCaption.
	result isEmpty  |result isNil  ifTrue:[ServiceCancelled signal].
	^ result