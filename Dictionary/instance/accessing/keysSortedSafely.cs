keysSortedSafely
	"Answer a SortedCollection containing the receiver's keys."
	| sortedKeys |
	sortedKeys _ SortedCollection new: self size.
	sortedKeys sortBlock:
		[ :x :y |  "Should really be use <obj, string, num> compareSafely..."
		(((x isKindOf: String) & (y isKindOf: String))
		or: [(x isKindOf: Number) & (y isKindOf: Number)])
			ifTrue: [ x < y]
			ifFalse: [ (x class = y class)
				ifTrue: [ x printString < y printString]
				ifFalse: [ x class name < y class name ] ] ].
	self keysDo:
		[ :aKey | sortedKeys add: aKey. ].
	^ sortedKeys
