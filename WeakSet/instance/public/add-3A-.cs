add: newObject
	"Include newObject as one of the receiver's elements, but only if
	not already present. Answer newObject"

	| index |
	newObject ifNil: [self error: 'Sets cannot meaningfully contain nil as an element'].
	index _ self findElementOrNil: newObject.
	((array at: index) == flag or: [(array at: index) isNil])
		ifTrue: [self atNewIndex: index put: newObject].
	^newObject