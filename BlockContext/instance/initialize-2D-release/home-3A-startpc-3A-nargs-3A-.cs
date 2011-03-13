home: aContextPart startpc: position nargs: anInteger 
	"This is the initialization message. The receiver has been initialized with 
	the correct size only."

	home _ aContextPart.
	pc _ startpc _ position.
	nargs _ anInteger.
	stackp _ 0.