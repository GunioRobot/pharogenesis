logOn: aStream
	"Log me on the stream."

	aStream cr; nextChunkPut: (self definition: false)