tab: anInteger 
	"Append anInteger tab characters to the receiver."

	anInteger timesRepeat: [self nextPut: Character tab]