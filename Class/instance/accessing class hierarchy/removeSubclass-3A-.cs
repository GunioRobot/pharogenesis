removeSubclass: aSubclass 
	"If the argument, aSubclass, is one of the receiver's subclasses, remove it."

	subclasses == nil ifFalse:
		[subclasses _  subclasses copyWithout: aSubclass.
		subclasses isEmpty ifTrue: [subclasses _ nil]].
