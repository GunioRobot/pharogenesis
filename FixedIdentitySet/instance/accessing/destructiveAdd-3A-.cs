destructiveAdd: anObject
	| index old |
	self isFull ifTrue: [^ false].
	index := self indexOf: anObject.
	old := self basicAt: index.
	self basicAt: index put: anObject.
	old ifNil: [tally := tally + 1].
	^ true