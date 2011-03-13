getString
	| result |
	result := UIManager default  request:caption initialAnswer: answer contents.
	self newCaption.
	result isEmptyOrNil ifTrue:[ServiceCancelled signal].
	^ result