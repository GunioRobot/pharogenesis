putForm: aForm onStream: aWriteStream
	"Store the given form on a file of the given name."

	| writer |
	writer _ self on: aWriteStream.
	Cursor write showWhile: [writer nextPutImage: aForm].
	writer close.
