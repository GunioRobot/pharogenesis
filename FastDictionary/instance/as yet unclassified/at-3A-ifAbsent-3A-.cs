at: key ifAbsent: aBlock
	"Answer the value associated with the key.  Look in cache first.  Remember to invalidate when removing.  7/10/96 tk"

	| index which |
	key == key1 ifTrue: [^ assoc1 value].
	key == key2 ifTrue: [^ assoc2 value].
	key == key3 ifTrue: [^ assoc3 value].
	key == key4 ifTrue: [^ assoc4 value].

	index _ self findElementOrNil: key.
	(array at: index) == nil ifTrue: [^ aBlock value].

	which _ ((Time millisecondClockValue) bitAnd: 3) + 1.
	which = 1 ifTrue: [key1 _ key.  assoc1 _ array at: index. ^ assoc1 value].
	which = 2 ifTrue: [key2 _ key.  assoc2 _ array at: index. ^ assoc2 value].
	which = 3 ifTrue: [key3 _ key.  assoc3 _ array at: index. ^ assoc3 value].
	which = 4 ifTrue: [key4 _ key.  assoc4 _ array at: index. ^ assoc4 value].
	self error: 'had to be one of those!'