upToEnd
	"Answer a subcollection from the current access position through the last element of the receiver."

	| newStream buffer |
	buffer := buffer1 species new: 1000.
	newStream := WriteStream on: (buffer1 species new: 100).
	[self atEnd] whileFalse: [newStream nextPutAll: (self nextInto: buffer)].
	^ newStream contents