printOn: aStream
	"Indirectly invokes an error during stepping in an Inspector"
	aStream error:'DrawErrorMorph>>printOn: invoked'