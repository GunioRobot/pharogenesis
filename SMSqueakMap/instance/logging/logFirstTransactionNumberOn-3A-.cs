logFirstTransactionNumberOn: aStream
	"Log the transaction number as the first available in the logfile being produced."

	aStream cr; nextChunkPut: 'self firstTransactionNumber: ', transactionCounter storeString
