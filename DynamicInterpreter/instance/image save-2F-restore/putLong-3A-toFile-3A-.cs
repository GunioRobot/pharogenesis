putLong: n toFile: f
	"Append the given 4-byte long word to the given file in this platforms 'natural' byte order. (Bytes will be swapped, if necessary, when the image is read on a different platform.) Set successFlag to false if the write fails."

	| wordsWritten |
	self var: #f declareC: 'sqImageFile f'.

	wordsWritten _ self cCode: 'sqImageFileWrite(&n, sizeof(int), 1, f)'.
	self success: wordsWritten = 1.
