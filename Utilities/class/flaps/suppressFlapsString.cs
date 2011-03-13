suppressFlapsString
	"Answer the string to be shown in a menu to represent the suppress-flaps-in-this-project status"

	^ (CurrentProjectRefactoring currentFlapsSuppressed)
		ifFalse: ['<yes>show flaps']
		ifTrue: ['<no>show flaps']
