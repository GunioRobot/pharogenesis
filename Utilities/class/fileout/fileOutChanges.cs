fileOutChanges
	"File out the current change set to a file whose name is a function of the current date and time."

	Smalltalk changes fileOut.
	Transcript cr; show: 'Changes filed out ', Date dateAndTimeNow printString
