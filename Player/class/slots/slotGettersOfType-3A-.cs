slotGettersOfType: aType
	"Answer a list of gettter selectors for slots of mine of the given type"

	| aList |
	aList _ OrderedCollection new.
	self slotInfo associationsDo:
		[:assoc |
			(assoc value type = aType) ifTrue:
				[aList add: (Utilities getterSelectorFor: assoc key)]].
	^ aList