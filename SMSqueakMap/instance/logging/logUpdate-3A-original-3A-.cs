logUpdate: anSMObject original: original
	"Pick the newest logfile available and log the updated object in it.
	<original> should be an editCopy created before the changes."
	
	| file |
	[ file _ self openLogFile setToEnd.
	anSMObject logUpdateOn: file original: original.
	self logIncrementedTransactionCounterOn: file ]
		ensure: [file close]
