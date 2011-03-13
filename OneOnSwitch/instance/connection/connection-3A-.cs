connection: anObject 
	"Set anObject to be the connection among two or more Switches. Make the 
	receiver a dependent of the argument, anObject."

	connection := anObject.
	connection addDependent: self