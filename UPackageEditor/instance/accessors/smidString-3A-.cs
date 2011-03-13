smidString: aStringOrText 
	| id str |
	str := aStringOrText asString withBlanksTrimmed.
	id := str isEmpty ifTrue: [nil] ifFalse: [UUID fromString: str].
	package squeakMapID: id.
	self changed: #smidString