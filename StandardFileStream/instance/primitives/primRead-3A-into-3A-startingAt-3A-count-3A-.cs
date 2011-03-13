primRead: id into: byteArray startingAt: startIndex count: count
	"read from the receiver's file into the given area of storage, starting at the given index, as many as count bytes; return the number of bytes actually read.  2/12/96 sw"

	<primitive: 154>

	self halt: 'error reading file'