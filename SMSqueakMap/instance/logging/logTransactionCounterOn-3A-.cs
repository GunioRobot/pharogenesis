logTransactionCounterOn: aStream
	"Log the current transaction number."

	aStream cr; nextChunkPut: 'self transactionCounter: ', transactionCounter storeString
