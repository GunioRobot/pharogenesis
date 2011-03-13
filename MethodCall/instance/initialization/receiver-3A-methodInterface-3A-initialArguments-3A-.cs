receiver: aReceiver methodInterface: aMethodInterface initialArguments: initialArguments
	"Set up a method-call for the given receiver, method-interface, and initial arguments"

	receiver := aReceiver.
	selector := aMethodInterface selector.
	methodInterface := aMethodInterface.
	arguments := initialArguments ifNotNil: [initialArguments asArray]
