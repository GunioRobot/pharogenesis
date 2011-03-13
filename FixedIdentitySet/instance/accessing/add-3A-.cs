add: anObject
	| index old |
	self isFull ifTrue: [^ false].
	index := self indexOf: anObject.
	old := self basicAt: index.
	old == anObject ifTrue: [^ true].
	old ifNotNil: [^ false].
	self basicAt: index put: anObject.
	tally := tally + 1.
	^ true