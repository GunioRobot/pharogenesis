addDependent: anObject
	"Make the given object one of the receiver's dependents."

	dependents == nil
		ifTrue: [dependents _ Array with: anObject]
		ifFalse: [
			"done if anObject is already a dependent"
			dependents do: [:o | o == anObject ifTrue: [^ self]].
			"otherwise, add it"
			dependents _ dependents copyWith: anObject].
