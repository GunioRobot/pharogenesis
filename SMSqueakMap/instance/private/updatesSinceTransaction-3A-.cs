updatesSinceTransaction: lastTransaction
	"Produce a String with all transactions from the logfile
	since <lastTransaction>. We go to the end of the file,
	then we search backwards for the text 'transactionCounter: xxx'.
	The implementation uses the new method #findStringFromEnd: which
	should be reasonably fast. If we find no such marker it means that
	this logfile has been condensed and does not have enough transactions
	to return, then we return 'DO FULL!'.
	The client will have to ask for the whole file instead.
	If the server has a lower transaction counter than the one sent
	the server is stale, let the client know this."

	| file found result key |
	lastTransaction = transactionCounter ifTrue:[^''].
	lastTransaction > transactionCounter ifTrue:[^'STALE SERVER!'].
	lastTransaction = firstTransactionNumber ifTrue:[^self updatesSinceFirstTransaction ].
	[ file _ self openLogFileReadOnly setToEnd.
	key _ 'self transactionCounter: ', lastTransaction storeString, '!'.
	found _ file findStringFromEnd: key.
	found = 0 ifTrue:[result _ 'DO FULL!'] ifFalse: [ file skip: key size. result _ file upToEnd ]]
		ensure: [file close].
	^result
