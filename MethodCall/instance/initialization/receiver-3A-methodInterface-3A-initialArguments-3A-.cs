receiver: aReceiver methodInterface: aMethodInterface initialArguments: initialArguments
	"Set up a method-call for the given receiver, method-interface, and initial arguments"

	receiver _ aReceiver.
	selector _ aMethodInterface selector.
	methodInterface _ aMethodInterface.
	arguments _ initialArguments ifNotNil: [initialArguments asArray]
