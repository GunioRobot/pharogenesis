calculateKeyArray
	"Recalculate the KeyArray from the object being inspected"

	| sortedKeys |
	sortedKeys _ SortedCollection new: object size.
	sortedKeys sortBlock: [ :x :y |
		(((x isKindOf: String) & (y isKindOf: String))
		or: [(x isKindOf: Number) & (y isKindOf: Number)])
			ifTrue: [ x < y]
			ifFalse: [ (x class = y class)
				ifTrue: [ x printString < y printString]
				ifFalse: [ x class name < y class name ] ] ].
	object keysDo:
		[ :aKey | sortedKeys add: aKey. ].
	keyArray _ sortedKeys asArray.
	selectionIndex _ 0.
