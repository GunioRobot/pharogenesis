freeUnreferencedSubclasses
	"Player classes may hold in their class instance variables references to instances of themselves that are otherwise unreachable. This method allows such loops to be garbage collected. This is done in three steps:
	1. Remove user-created subclasses from the 'subclasses' set and from Smalltalk. Only remove classes whose name begins with 'Player' and which have not references.
	2. Do a full garbage collection.
	3. Enumerate all Metaclasses and find those whose soleInstance's superclass is this class. Reset the subclasses set to this set of classes, and add back to Smalltalk."
	"Player freeUnreferencedSubclasses"

	| newSubclasses |
	subclasses _ subclasses select: [:c |
		((c name asString beginsWith: 'Player') and:
		 [(Smalltalk allCallsOn: (Smalltalk associationAt: c name)) size = 0])
			ifTrue: [Smalltalk removeKey: c name ifAbsent: []. false]
			ifFalse: [true]].
	Smalltalk garbageCollect.
	newSubclasses _ Set new.
	Metaclass allInstancesDo: [:mClass |
		c _ mClass soleInstance.
		((c superclass = self) and:
		 [(c name beginsWith: 'AnObsolete') not]) ifTrue: [
			newSubclasses add: c.
			Smalltalk at: c name put: c]].
	subclasses _ newSubclasses.
	SystemOrganization removeMissingClasses.
