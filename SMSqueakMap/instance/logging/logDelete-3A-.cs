logDelete: anSMObject
	"Pick the newest logfile available and log the deletion in it."
	
	| file |
	[ file _ self openLogFile setToEnd.
	anSMObject logDeleteOn: file.
	self logIncrementedTransactionCounterOn: file ]
		ensure: [file close]
