innocuousName
	"Choose an innocuous name for the receiver -- one that does not end in the word Morph"

	| className |
	className _ self class name.
	(className size > 5 and: [className endsWith: 'Morph'])
		ifTrue: [className _ className copyFrom: 1 to: className size - 5].
	^ className asString