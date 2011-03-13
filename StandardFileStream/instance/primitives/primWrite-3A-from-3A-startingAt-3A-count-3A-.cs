primWrite: id from: byteArray startingAt: startIndex count: count
	"Write into the receiver's file from the given area of storage, starting at the given index, as many as count bytes; return the number of bytes actually written. 2/12/96 sw"

	<primitive: 158>

	closed ifTrue: [^ self halt: 'Write error: File not open'].
	rwmode ifFalse: [^ self halt: 'Error-attempt to write to a read-only file.'].
	self halt: 'File write error'