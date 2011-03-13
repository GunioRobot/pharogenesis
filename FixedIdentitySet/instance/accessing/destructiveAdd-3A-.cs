destructiveAdd: anObject
	| index old |
	self isFull ifTrue: [^ false].
	index _ self indexOf: anObject.
	old _ self basicAt: index.
	self basicAt: index put: anObject.
	old ifNil: [tally _ tally + 1].
	^ true