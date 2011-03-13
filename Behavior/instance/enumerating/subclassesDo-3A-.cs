subclassesDo: aBlock 
	"Evaluate the argument, aBlock, for each of the receiver's immediate subclasses."
	subclasses == nil ifFalse:
		[subclasses do: [:cl | aBlock value: cl]]