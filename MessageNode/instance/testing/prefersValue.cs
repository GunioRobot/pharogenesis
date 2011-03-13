prefersValue
	"return true of this node generates shorter code when it leaves a value
	on the stack"
	^ (special =3 or: [special =4]) and: [self isReturningIf not]