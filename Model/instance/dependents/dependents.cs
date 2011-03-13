dependents
	"Answer an OrderedCollection of the objects that are dependent on the receiver, that is, the objects that should be notified if the receiver changes.  Always returns a collection, even if empty. 1/23/96 sw"

	dependents == nil ifTrue: [dependents _ OrderedCollection new].
	^ dependents