storeOn: aStream 
	"Store the model condensed on the stream.
	First chunk is current date. Categories are saved first (in a top down
	manner so that loading will be able to resolve parents directly),
	then all the objects. At the end we tack on the last known transactionId."

	self topCategories do: [:cat | cat logRecursivelyOn: aStream].
	objects valuesDo: [:package | package logOn: aStream].
	self logFirstTransactionNumberOn: aStream