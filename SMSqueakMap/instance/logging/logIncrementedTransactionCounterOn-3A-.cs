logIncrementedTransactionCounterOn: aStream
	"Increment the transaction counter and
	log the current number."

	transactionCounter _ transactionCounter + 1.
	self logTransactionCounterOn: aStream
