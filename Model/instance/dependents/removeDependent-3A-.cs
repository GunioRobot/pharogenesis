removeDependent: anObject
	"Remove the given object as one of the receiver's dependents.
	: if dependents nil on entry, simply exit; workaround for confusing bug encountered in bringing Fabrik up on Squeak."

	| newDependents |
	dependents == nil ifTrue: [^ self].
	newDependents _ dependents select: [ :d | (d == anObject) not].
	newDependents isEmpty
		ifTrue: [dependents _ nil]
		ifFalse: [dependents _ newDependents]