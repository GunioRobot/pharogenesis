addDependent: anObject
	"Make the given object one of the receiver's dependents."

	| dependents |
	dependents _ self dependents.
	dependents do: [:o | o == anObject ifTrue: [^ self]].  "anObject is already a dependent"
	DependentsFields at: self put: (dependents copyWith: anObject).
