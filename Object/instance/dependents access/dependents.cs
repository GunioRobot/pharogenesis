dependents
	"Answer an OrderedCollection of the objects that are dependent on the 
	receiver, that is, the objects that should be notified if the receiver 
	changes."

	(DependentsFields includesKey: self)
		ifTrue: [^DependentsFields at: self]
		ifFalse: [^OrderedCollection new]