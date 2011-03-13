add: anObject
	| index old |
	self isFull ifTrue: [^ false].
	index _ self indexOf: anObject.
	old _ self basicAt: index.
	old == anObject ifTrue: [^ true].
	old ifNotNil: [^ false].
	self basicAt: index put: anObject.
	tally _ tally + 1.
	^ true