fileOutChanges
	"File out changes to a file whose name is a function of the current date and time."

	Smalltalk changes fileOut.
	Transcript show: 'Changes filed out ', Date dateAndTimeNow printString; cr.
