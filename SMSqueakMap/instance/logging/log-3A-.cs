log: anSMObject
	"Pick the newest logfile available and log the object in it."
	
	| file |
	[ file _ self openLogFile setToEnd.
	anSMObject logOn: file.
	self logIncrementedTransactionCounterOn: file ]
		ensure: [file close]
