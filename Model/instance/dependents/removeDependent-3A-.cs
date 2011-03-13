removeDependent: anObject
	"Remove the given object as one of the receiver's dependents."

	| newDependents |
	dependents == nil ifTrue: [^ self].
	newDependents _ dependents select: [:d | (d == anObject) not].
	newDependents isEmpty
		ifTrue: [dependents _ nil]
		ifFalse: [dependents _ newDependents].
