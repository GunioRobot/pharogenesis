removeDependent: anObject
	"Remove the given object as one of the receiver's dependents."

	| dependents newDependents |
	dependents _ self dependents.
	newDependents _ dependents select: [ :d | (d == anObject) not].
	newDependents isEmpty
		ifTrue: [DependentsFields removeKey: self ifAbsent: []]
		ifFalse: [DependentsFields at: self put: newDependents].
