loadUpdatesFromLog
	"Pick the current logfile - if there is none, create a new and return.
	Otherwise check the last recorded transaction and compare it with
	our own counter. If the counter is less (meaning there are new
	transactions in the logfile) we read them into the model thus bringing
	the model in synch with the logfile.
	The implementation uses the new method #findStringFromEnd: which
	should be reasonably fast. If we find no such marker it means that
	this logfile has been condensed and does not have enough transactions
	to return, then we call #reloadLog which will reload the log completely
	and return false.
	Note: This is used because multiple images can share the same logfile
	and the other images may have added transactions to the logfile."
	
	| file key found |
	[ file _ self openLogFileReadOnly.
	file ifNil: [^self createNewLog].
	file setToEnd.
	key _ 'self transactionCounter: ', transactionCounter storeString, '!'.
	found _ file findStringFromEnd: key.
	found = 0 ifFalse: [file skip: key size. self loadUpdatesFrom: file log: false]]
		ensure: [file ifNotNil: [file close]].
	found = 0 ifTrue:[self reloadLog]