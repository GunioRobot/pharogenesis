logDeleteOn: aStream
	"Log a deletion of me on the stream."

	aStream cr; nextChunkPut: 'self deleteObjectWithId: ', id asString storeString