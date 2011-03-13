writeHeader: bounds rate: frameRate
	"Read header information from the source stream.
	Return true if successful, false otherwise."
	self halt.
	self writeSignature.
	stream nextBytePut: 3. "Always write flash3"
	dataSize := stream nextLongPut: 0.	"Place holder for data size"
	stream nextRectPut: bounds.
	stream nextWordPut: (frameRate * 256) truncated.